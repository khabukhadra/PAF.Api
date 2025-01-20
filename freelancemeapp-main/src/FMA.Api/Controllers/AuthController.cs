using System.ComponentModel;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Intrinsics.X86;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FMA.Contracts.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using FMA.Application.NewEntities;
using FMA.Contracts.Requests;
using System.Text;
using FMA.Application.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using FMA.Application.NewEntities;

namespace FMA.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IConfiguration _configuration;
    private readonly PingAFreelancerContext _db;

    public AuthController(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IConfiguration configuration,
        PingAFreelancerContext context)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
        _db = context;
    }

 [HttpPost("register")]
public async Task<ActionResult<RegisterResponse>> Register(RegisterModel registerModel)
{
    try
    {
        var existing = await _userManager.FindByEmailAsync(registerModel.Username);
        if (existing != null)
        {
            return Conflict(new { Message = "Email already in use." });
        }

        var isFreelancer = registerModel.HourlyRate.HasValue;
        
        var user = new ApplicationUser
        {
            UserType = isFreelancer ? UserType.Freelancer : UserType.Client,
            UserName = registerModel.Username,
            Email = registerModel.Username,
            FirstName = registerModel.FirstName,
            LastName = registerModel.LastName,
            Latitude = registerModel.Latitude,                        
            PhotoPath = "https://freelanceme.blob.core.windows.net/container1/anonymous",
            Longitude = registerModel.Longitude,
            PhoneNumber = registerModel.PhoneNumber,
            DateRegistered = registerModel.DateRegistered,
            IsActive = true
        };

        var result = await _userManager.CreateAsync(user, registerModel.Password);
        if (!result.Succeeded)
        {
            return BadRequest(new RegisterResponse
            {
                Success = false,
                Errors = result.Errors.Select(e => new Error 
                { 
                    Code = e.Code, 
                    Description = e.Description 
                }).ToList()
            });
        }

        if (isFreelancer)
        {
            var expertise = await _db.Expertises
                .FirstOrDefaultAsync(e => e.ExpertiseName == registerModel.ExpertiseName);
                
            if (expertise == null)
            {
                return BadRequest(new { Message = "Invalid expertise selected." });
            }

            var newFreelancer = new FreelancerUser
            {
                Id = user.Id,
                DomainId = expertise.DomainId,
                MainExpertiseId = expertise.Id,
                HourlyRate = registerModel.HourlyRate.Value,
                Rating = 0,
                FulfilledContracts = 0,
                HoursBilled = 0,
            };
            await _userManager.AddToRoleAsync(user, "Freelancer");
            await _userManager.AddClaimAsync(user, new Claim("CanStartContract", "true"));
            _db.Freelancers.Add(newFreelancer);
        }
        else
        {
            var newClient = new ClientUser
            {
                Id = user.Id,
                TotalHires = 0
            };
            await _userManager.AddToRoleAsync(user, "Client");
            await _userManager.AddClaimAsync(user, new Claim("CanPing", "true"));
            await _userManager.AddClaimAsync(user, new Claim("CanEndContract", "true"));
            _db.Clients.Add(newClient);
        }

        await _db.SaveChangesAsync();
        return Ok(new RegisterResponse { Success = true });

    }
    catch (Exception ex)
    {
        return StatusCode(500, new { Message = $"Error during registration: {ex.Message}" });
    }
}


    [HttpPost("login")]
    public async Task<ActionResult<TokenResponse>> Login(LoginModel loginModel)
    {
        try
        {
            var user = await _userManager.FindByEmailAsync(loginModel.Username);
            if (user == null)
            {
                return Unauthorized(new { Message = "Invalid username or password." });
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginModel.Password, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var token = await GenerateJwtToken(user);

                return new TokenResponse
                {
                    Token = token,
                    Expiration = DateTime.Now.AddMinutes(30)
                };
            }
            return Unauthorized(new { Message = "Login failed." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "An error occurred during Login." });
        }

    }

    [Authorize]
    [HttpPost("logout")]
    public async Task<ActionResult> Logout()
    {
        try
        {
            await _signInManager.SignOutAsync();
            return Ok(new { Message = "Logged out." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "Failed to logout." });
        }
    }

    [HttpPost("ping")]
    public async Task<IActionResult> Ping(PingRequest pingRequest)
    {
        FMA.Application.NewEntities.Ping ping = new FMA.Application.NewEntities.Ping
            {
                ClientId = pingRequest.ClientId,
                FreelancerId = pingRequest.FreelancerId,
                DatePinged = pingRequest.DatePinged    
            };
        _db.Pings.Add(ping);
        await _db.SaveChangesAsync();
        return Ok();
    }

    [HttpGet("pings/{userId}")]
    public async Task<ActionResult<List<FMA.Application.NewEntities.Ping>>> GetPings(string userId)
    {
        return await _db.Pings
            .Where(p => p.ClientId == userId || p.FreelancerId == userId)
            .ToListAsync();
    }

    [HttpGet("contracts/{userId}")]
    public async Task<ActionResult<List<FMA.Application.NewEntities.Contract>>> GetContracts(string userId)
    {
        return await _db.Contracts
            .Where(c => c.ClientId == userId || c.FreelancerId == userId)
            .ToListAsync();
    }

    [HttpPost("contract")]
    public async Task<IActionResult> ContractClient(Contract contract)
    {
        var client = await _db.Clients
            .Include(c => c.User)
            .Where(c => c.User.PhoneNumber == contract.PhoneNumber)
            .FirstOrDefaultAsync();

        var toRemove = await _db.Pings
            .Where(e => e.ClientId == client.Id && e.FreelancerId == contract.FreelancerId)
            .ToListAsync();
        _db.Pings.RemoveRange(toRemove);
        await _db.SaveChangesAsync();

        var newContract = new Contract
        {
            ClientId = client.Id,
            FreelancerId = contract.FreelancerId,
            PhoneNumber = contract.PhoneNumber,
            DateStarted = contract.DateStarted
        };
        await _db.Contracts.AddAsync(newContract);
        await _db.SaveChangesAsync();

        return Ok();
    }

    [HttpPost("complete")]
    public async Task<IActionResult> CompleteContract(Contract contract)
    {
        var freelancer = await _db.Freelancers
            .Include(c => c.User)
            .Where(c => c.User.PhoneNumber == contract.PhoneNumber)
            .FirstOrDefaultAsync(); 
        var contractFound = await _db.Contracts
            .Where(c => c.ClientId == contract.ClientId && c.FreelancerId == freelancer.Id)
            .FirstOrDefaultAsync();

        contractFound.Rating = contract.Rating;
        contractFound.AmountPaid = contract.AmountPaid;
        contractFound.HoursContracted = contract.HoursContracted;
        contractFound.DateCompleted = DateTime.Now;
        contractFound.ClientId = contract.ClientId;
        contractFound.FreelancerId = freelancer.Id;

        freelancer.HoursBilled += contract.HoursContracted ?? 0;
        var points = freelancer.Rating * freelancer.FulfilledContracts;
        points += contract.Rating ?? 0;
        freelancer.FulfilledContracts += 1;
        freelancer.Rating = points / freelancer.FulfilledContracts;

        await _db.SaveChangesAsync();

        return Ok();
    }

    private async Task<string> GenerateJwtToken(ApplicationUser user)
    {
        var userClaims = await _userManager.GetClaimsAsync(user);
        var userRoles = await _userManager.GetRolesAsync(user);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Email, user.Email)
        };


        claims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));
        claims.AddRange(userClaims);

        var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("kkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddMinutes(20),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
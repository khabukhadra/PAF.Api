using System.Net.NetworkInformation;
using FMA.Api.Mappings;
using FMA.Application.NewEntities;
using FMA.Application.Repositories;
using Microsoft.AspNetCore.Mvc;
using FMA.Contracts.Responses;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using FMA.Contracts.Requests;
using Geolocation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace FMA.Api.Controllers;
[ApiController]
[Route("api")]
public class FreelanceMeController : ControllerBase
{
    private readonly IFreelanceMeRepository _repository;
    private readonly UserManager<ApplicationUser> _userManager;

    public FreelanceMeController(IFreelanceMeRepository repository,
        UserManager<ApplicationUser> userManager)
    {
        _repository = repository;
        _userManager = userManager;
    }

    [Route("domains")]
    [HttpGet]
    // Landing page
    public async Task<ActionResult<DomainsResponse>> GetDomains()
    {
        var entities = await _repository.GetDomainsAsync();
        return entities.MapDomains();
    }

    [Route("domains/{id}")]
    [HttpGet]
    // Title of domain page. Its font, perhaps the photo. And number of frelancers
    public async Task<ActionResult<DomainResponse>> GetDomain(int id)
    {
        var entity = await _repository.GetDomainAsync(id);
        return entity.MapDomain();
    }

    // Get Freelancers under specific domain. All of them. Before expertise filtering
    [Route("domains/{id}/freelancers")]
    [HttpGet]
    public async Task<ActionResult<FreelancersResponse>> GetFreelancers(int id)
    {
        var freelancers = (await _repository.GetFreelancersAsync(id)).ToList();
        return freelancers.MapFreelancers();
    }

    // View freelancer page, contact me button
    [Route("domains/{domainId}/freelancers/{freelancerId}")]
    [HttpGet]
    public async Task<ActionResult<FreelancerResponse>> GetFreelancerById(
        int domainId, string freelancerId)
    {
        var freelancer = await _repository.GetFreelancerByIdAsync(domainId, freelancerId);
        return freelancer.MapFreelancer();
    }

    // Filter by name, expertise page
    [Route("freelancers")]
    [HttpGet]
    public async Task<ActionResult<FreelancersResponse>> GetAllFreelancers()
    {
        var freelancers = (await _repository.GetAllFreelancersAsync()).ToList();
        return freelancers.MapFreelancers();
    }

    [Route("images/expertise/{id}")]
    [HttpGet]
    public async Task<IActionResult> GetExpertisePhoto(int id)
    {
        var expertise = await _repository.GetExpertiseAsync(id);
        Byte[] bytes = System.IO.File.ReadAllBytes(expertise.PhotoPath);
        return File(bytes, "image/jpeg");
    }

    [Route("images/domain/{id}")]
    [HttpGet]
    public async Task<IActionResult> GetDomainPhoto(int id)
    {
        var domain = await _repository.GetDomainAsync(id);
        Byte[] bytes = System.IO.File.ReadAllBytes(domain.PhotoPath);
        return File(bytes, "image/jpeg");
    }

    [HttpGet]
    [Route("expertises")]
    public async Task<ActionResult<ExpertisesResponse>> GetExpertises()
    {
        var expertises = await _repository.GetExpertisesAsync();
        return expertises.MapExpertises();
    }

    [HttpPost]
    [Route("filter")]
    public async Task<ActionResult<FreelancersResponse>> Filter(FreelancerRequest request)
    {
        var freelancers = await _repository.FilterFreelancers(request);
        return freelancers.ToList().MapFreelancers();
    }

    [HttpGet]
    [Route("pings/{userId}")]
    public async Task<ActionResult<IEnumerable<
        FMA.Application.NewEntities.Ping>>> GetPings(string userId)
    {
        return Ok(await _repository.GetPings(userId));
    }

    [HttpGet]
    [Route("contracts/{userId}")]
    public async Task<ActionResult<IEnumerable<
        FMA.Application.NewEntities.Contract>>> GetContracts(string userId)
    {
        return Ok(await _repository.GetContracts(userId));
    }


    [HttpGet]
    [Route("interactiondetails/{freelancerId}/{userId}")]
    public async Task<ActionResult<InteractionDetails>> GetInteractionDetails(
        string freelancerId, string userId)
    {
        var client = await _userManager.FindByIdAsync(userId);
        var freelancer = await _userManager.FindByIdAsync(freelancerId);
        var distance = GeoCalculator.GetDistance(
            client.Latitude, client.Longitude, freelancer.Latitude, freelancer.Longitude);
        return Ok(new InteractionDetails
        {
            FreelancerFirstName = freelancer.FirstName,
            FreelancerLastName = freelancer.LastName,
            FreelancerPhotoPath = freelancer.PhotoPath,
            FreelancerPhoneNumber = freelancer.PhoneNumber,
            Distance = distance,
            InteractionDate = null!,
            IsActive = freelancer.IsActive,
            ClientFirstName = client.FirstName,
            ClientLastName = client.LastName,
            ClientPhoneNumber = client.PhoneNumber
        });
    }

    // [HttpGet]
    // [Route("getclientid/{phone}")]
    // public async Task
}
using System.Security.AccessControl;
using System.Reflection.Emit;
using System.Security.Principal;
using FMA.Application.Data;
using FMA.Application.NewEntities;
using Microsoft.EntityFrameworkCore;
using FMA.Contracts.Requests;
using Geolocation;

namespace FMA.Application.Repositories;

public class FreelanceMeRepository : IFreelanceMeRepository
{
    private readonly PingAFreelancerContext _db;
    public FreelanceMeRepository(PingAFreelancerContext context)
    {
        _db = context;
    }

    public async Task<IEnumerable<Domain>> GetDomainsAsync()
    {
        var domains = await _db.Domains
            .Include(d => d.Freelancers)
                .ThenInclude(f => f.User)
            .Include(d => d.Freelancers)
                .ThenInclude(f => f.Expertise)
            .Include(d => d.Expertises)
                .ThenInclude(e => e.Freelancers)
                    .ThenInclude(f => f.User)
            .ToListAsync();

        foreach (var domain in domains)
        {
            foreach (var freelancer in domain.Freelancers)
            {
                if (freelancer.Expertise == null)
                {
                    freelancer.Expertise = await _db.Expertises
                        .FirstOrDefaultAsync(e => e.Id == freelancer.MainExpertiseId);
                }
            }
        }
        return domains;
    }

    public async Task<Domain> GetDomainAsync(int domainId)
    {
        return await _db.Domains
            .Include(d => d.Freelancers)
            .SingleOrDefaultAsync(d => d.Id == domainId);
    }

    public async Task<IEnumerable<FreelancerUser>> GetFreelancersAsync(int domainId)
    {
        var freelancers = await _db.Freelancers
            .Include(f => f.User)
            .Include(f => f.Expertise)
            .Include(f => f.Domain)
            .Where(f => f.DomainId == domainId)
            .Select(f => new FreelancerUser
            {
                Id = f.Id,
                DomainId = f.DomainId,
                User = f.User,
                MainExpertiseId = f.MainExpertiseId,
                Expertise = _db.Expertises.FirstOrDefault(e => e.Id == f.MainExpertiseId),
                HourlyRate = f.HourlyRate,
                Rating = f.Rating,
                FulfilledContracts = f.FulfilledContracts,
                HoursBilled = f.HoursBilled
            })
            .ToListAsync();

        return freelancers;
    }

    public async Task<FreelancerUser> GetFreelancerByIdAsync(
        int domainId, string freelancerId)
    {
        var freelancer = await _db.Freelancers
            .Where(f => f.DomainId == domainId)
            .Where(f => f.Id == freelancerId)
            .Select(f => new FreelancerUser
            {
                Id = f.Id,
                DomainId = f.DomainId,
                User = f.User,
                MainExpertiseId = f.MainExpertiseId,
                Expertise = _db.Expertises.FirstOrDefault(e => e.Id == f.MainExpertiseId),
                HourlyRate = f.HourlyRate,
                Rating = f.Rating,
                FulfilledContracts = f.FulfilledContracts,
                HoursBilled = f.HoursBilled 
            })
            .SingleOrDefaultAsync();
        return freelancer;
    }

    public async Task<IEnumerable<FreelancerUser>> GetAllFreelancersAsync()
    {
        return await _db.Freelancers.Include(f => f.Expertise).ToListAsync();
    }

    public async Task<IEnumerable<Expertise>> GetExpertisesAsync()
    {
        return await _db.Expertises
            .Include(e => e.Freelancers)
            .ToListAsync();
    }
    public async Task<Expertise> GetExpertiseAsync(int id)
    {
        return await _db.Expertises.SingleOrDefaultAsync(e => e.Id == id);

    }

    public async Task<IEnumerable<Ping>> GetPings(string userId)
    {
        return await _db.Pings
            .Include(p => p.Client)
            .Include(p => p.Freelancer)
            .Where(p => p.ClientId == userId || p.FreelancerId == userId).ToListAsync();
    }

    public async Task<IEnumerable<Contract>> GetContracts(string userId)
    {
        return await _db.Contracts
            .Include(c => c.Client)
            .Include(c => c.Freelancer)
            .Where(c => c.ClientId == userId || c.FreelancerId == userId).ToListAsync();
    }

    public async Task<IEnumerable<FreelancerUser>> FilterFreelancers(FreelancerRequest request)
    {
        IQueryable<FreelancerUser> freelancers = _db.Freelancers.Include(f => f.Expertise).AsQueryable();

        freelancers = freelancers.Include(f => f.User).Where(freelancer =>
            request.Name.ToLower().Contains(freelancer.User.FirstName.ToLower()) 
            || 
            request.Name.ToLower().Contains(freelancer.User.LastName.ToLower()) 
            ||
            freelancer.Expertise.ExpertiseName.Contains(request.ExpertiseName)
        );

		freelancers = freelancers.Where(freelancer =>
			freelancer.Rating >= request.MinRating 
			&& 
			freelancer.HourlyRate <= request.MaxHourlyRate
		);

        // freelancers = freelancers.Where(freelancer => 
        //     GetDistance(request.Latitude, request.Longitude, freelancer.Latitude, freelancer.Longitude).CompareTo(request.MaxDistance) < 0);

        var result =  freelancers.AsEnumerable();

        var freelancersFilteredByDistance = new List<FreelancerUser>();

        foreach (var freelancer in result)
        {
            if (GetDistance(request.Latitude, request.Longitude, freelancer.User.Latitude, freelancer.User.Longitude) <= request.MaxDistance)
            {
                freelancersFilteredByDistance.Add(freelancer);
            }
        }
        return freelancersFilteredByDistance;
    }

    public double GetDistance(double requestLatitude, double requestLongitude, double freelancerLatitude, double freelancerLongitude)
    {
        return GeoCalculator.GetDistance(requestLatitude, requestLongitude, freelancerLatitude, freelancerLongitude, 1, DistanceUnit.Kilometers);
    }
}


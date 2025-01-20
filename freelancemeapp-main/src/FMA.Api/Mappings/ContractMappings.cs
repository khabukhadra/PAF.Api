using System.Threading;
using System.Security.Cryptography;
using System.Reflection.Emit;
using FMA.Application.NewEntities;
using FMA.Contracts.Responses;

namespace FMA.Api.Mappings;

public static class ContractMappings
{
    public static DomainsResponse MapDomains(this IEnumerable<Domain> domains)
    {
        return new DomainsResponse
        {
            Items = domains.Select(MapDomain).ToList()
        };
    }

    public static DomainResponse MapDomain(this Domain domain)
    {
        var response = new DomainResponse
        {
            Id = domain.Id,
            DomainName = domain.DomainName,
            PhotoPath = domain.PhotoPath,
            BorderColor = domain.BorderColor,
            Freelancers = new FreelancersResponse
            {
                Items = domain.Freelancers?
                    .Select(f => MapFreelancer(f))
                    .Where(f => f != null)
                    .ToList()
            },
            Expertises = new ExpertisesResponse
            {
                Items = domain.Expertises?
                    .Select(e => MapExpertise(e))
                    .Where(e => e != null)
                    .ToList()
            }
        };

        // foreach (var freelancer in domain.Freelancers)
        // {
        //     response.Freelancers.Items.Add(freelancer.MapFreelancer());
        // }
        // foreach (var expertise in domain.Expertises)
        // {
        //     response.Expertises.Items.Add(expertise.MapExpertise());
        // }
        return response;
    }

    public static FreelancersResponse MapFreelancers(this List<FreelancerUser> freelancers)
    {
        return new FreelancersResponse
        {
            Items = freelancers.Select(MapFreelancer).ToList()
        };
    }

    public static FreelancerResponse MapFreelancer(this FreelancerUser freelancer)
    {
        var response = new FreelancerResponse
        {
            Id = freelancer.Id,
            DomainId = freelancer.DomainId,
            FirstName = freelancer.User.FirstName,
            LastName = freelancer.User.LastName,
            DateRegistered = freelancer.User.DateRegistered,
            PhotoPath = freelancer.User.PhotoPath,
            Email = freelancer.User.Email,
            PhoneNumber = freelancer.User.PhoneNumber,
            HourlyRate = freelancer.HourlyRate,
            Rating = freelancer.Rating,
            FulfilledContracts = freelancer.FulfilledContracts,
            HoursBilled = freelancer.HoursBilled,
            Latitude = freelancer.User.Latitude,
            Longitude = freelancer.User.Longitude,
            IsActive = freelancer.User.IsActive,
            Expertise = new ExpertiseResponse
            {
                Id = freelancer.Expertise.Id,
                ExpertiseName = freelancer.Expertise.ExpertiseName,
                PhotoPath = freelancer.Expertise.PhotoPath,
                BorderColor = freelancer.Expertise.BorderColor,
                Freelancers = null!
            }
        };
        return response;
    }

    public static ExpertiseResponse MapExpertise(this Expertise expertise)
    {
        return new ExpertiseResponse
        {
            Id = expertise.Id,
            ExpertiseName = expertise.ExpertiseName,
            // Freelancers = expertise.Freelancers.MapFreelancers()
        };
    }

    public static ExpertisesResponse MapExpertises(this IEnumerable<Expertise> expertises)
    {
        return new ExpertisesResponse
        {
            Items = expertises.Select(MapExpertise).ToList()
        };
    }
}
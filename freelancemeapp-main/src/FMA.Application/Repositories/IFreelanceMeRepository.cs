using FMA.Application.NewEntities;
using FMA.Contracts.Requests;
using FMA.Contracts.Responses;

namespace FMA.Application.Repositories;

public interface IFreelanceMeRepository
{
    Task<IEnumerable<Domain>> GetDomainsAsync();
    Task<Domain> GetDomainAsync(int domainId);
    Task<IEnumerable<FreelancerUser>> GetFreelancersAsync(int domainId);
    Task<FreelancerUser> GetFreelancerByIdAsync(int domainId, string freelancerId);
    Task<IEnumerable<FreelancerUser>> GetAllFreelancersAsync();
    Task<IEnumerable<Expertise>> GetExpertisesAsync();
    Task<Expertise> GetExpertiseAsync(int id);
    Task<IEnumerable<FreelancerUser>> FilterFreelancers(FreelancerRequest request);
    Task<IEnumerable<FMA.Application.NewEntities.Ping>> GetPings(string userId);
    Task<IEnumerable<FMA.Application.NewEntities.Contract>> GetContracts(string userId);
}
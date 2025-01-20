namespace FMA.Contracts.Responses;

public class DomainResponse
{
    public required int Id { get; set; }

    public required string DomainName { get; set; }

    public required string PhotoPath { get; set; }

    public required string BorderColor { get; set; }

    public FreelancersResponse Freelancers { get; set; } = new();
    public int FreelancerCount => Freelancers.Items.Count();

    public ExpertisesResponse Expertises { get; set; } = new();
    public int ExpertiseCount => Expertises.Items.Count();
};
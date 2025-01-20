using System.Collections.ObjectModel;

namespace FMA.Application.NewEntities;

public class Domain
{
    public required int Id { get; set; }

    public required string DomainName { get; set; }

    public required string PhotoPath { get; set; }

    public required string BorderColor { get; set; }

    public ICollection<FreelancerUser> Freelancers { get; set; }  = new Collection<FreelancerUser>();
    public ICollection<Expertise> Expertises { get; set; } = new Collection<Expertise>();
};

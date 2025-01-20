using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace FMA.Application.NewEntities;

public class Expertise
{
    public required int Id { get; set; }

    public required int DomainId { get; set; }
    [ForeignKey("DomainId")]
    public  Domain? Domain { get; set; }

    public required string ExpertiseName { get; set; }

    public string BorderColor { get; set; }

    public string PhotoPath {get; set;  }

    public List<FreelancerUser> Freelancers { get; set; } = new();
}

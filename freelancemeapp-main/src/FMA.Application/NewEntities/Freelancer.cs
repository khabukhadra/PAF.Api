using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMA.Application.NewEntities
{
    public class FreelancerUser 
    {
        public string Id { get; set; }
        [ForeignKey("Id")]
        public virtual ApplicationUser User { get; set; }

        public required int DomainId { get; set; }
        [ForeignKey("DomainId")]
        public Domain? Domain { get; set; }
        [ForeignKey("MainExpertiseId")]
        public Expertise? Expertise { get; set; }
        public int MainExpertiseId { get; set; }
        public required double HourlyRate { get; set; }
        public required double Rating { get; set; }
        public required int FulfilledContracts { get; set; }
        public required int HoursBilled { get; set; }
        public UserType UserType { get; set; } = UserType.Freelancer;

        public ICollection<Contract> Contracts { get; set; } = new List<Contract>();
        public ICollection<Ping> ReceivedPings { get; set; } = new List<Ping>();
    }
}
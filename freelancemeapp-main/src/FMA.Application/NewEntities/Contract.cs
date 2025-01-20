using System.Security.AccessControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMA.Application.NewEntities
{
    public class Contract
    {
        [Key]
        public int? Id { get; set; }

        public string? ClientId { get; set; }

        public string? FreelancerId { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime DateStarted { get; set; }

        public DateTime? DateCompleted { get; set; }

        public int? Rating { get; set; }

        public int? HoursContracted { get; set; }

        public int? AmountPaid { get; set; }

        [ForeignKey("ClientEmail")]
        public ClientUser? Client { get; set; }

        [ForeignKey("FreelancerEmail")]
        public FreelancerUser? Freelancer { get; set; }
    }
}
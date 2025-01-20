using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FMA.Application.NewEntities
{
    public class Ping
    {
        [Key]
        public int Id { get; set; }

        public string ClientId { get; set; } = string.Empty;

        public string FreelancerId { get; set; } = string.Empty;

        public DateTime DatePinged { get; set; }

        public ClientUser? Client { get; set; }

        public FreelancerUser? Freelancer { get; set; }
    }
}
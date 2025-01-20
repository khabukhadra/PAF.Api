using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMA.Contracts.Requests
{
    public class StartContract
    {
        public string? PhoneNumber { get; set; }

        public DateTime DateContracted { get; set; }

        public string? ClientId { get; set; }

        public string FreelancerId { get; set; }
    }
}
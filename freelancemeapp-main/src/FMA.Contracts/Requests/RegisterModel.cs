using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMA.Contracts.Requests
{
    public class RegisterModel
    {
        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string PhoneNumber { get; set; } = string.Empty;

        public DateTime DateRegistered { get; set; }

        public string? ExpertiseName { get; set; }

        public double? HourlyRate { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Npgsql.TypeMapping;

namespace FMA.Application.NewEntities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime DateRegistered { get; set; }
        public string PhotoPath { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public UserType UserType { get; set; }
        
    }

    public enum UserType
    {
        Freelancer,
        Client
    }
}
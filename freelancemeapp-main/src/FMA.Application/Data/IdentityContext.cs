using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using FMA.Application.NewEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace FMA.Application.Data
{
    // public class IdentityContextFactory : IDesignTimeDbContextFactory<IdentityContext>
    // {
    //     public IdentityContext CreateDbContext(string[] args)
    //     {
    //         var optionsBuilder = new DbContextOptionsBuilder<IdentityContext>();
    //         optionsBuilder.UseSqlServer("Server=localhost,1433;Database=pafdb;User Id=sa;Password=Kanaan123!;TrustServerCertificate=True");
            
    //         return new IdentityContext(optionsBuilder.Options);
    //     }
    // }
    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) 
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

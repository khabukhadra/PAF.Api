// using System.Threading.Tasks;
// using System.Security.Cryptography;
// using System.Reflection.Emit;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
// using FMA.Application.Entities;

// namespace FMA.Application.Data;

// public class FreelancerContext : DbContext
// {
//     public FreelancerContext(DbContextOptions<FreelancerContext> options) : base(options)
//     {
//     }

//     public DbSet<Domain> Domains { get; set; }
//     public DbSet<Freelancer> Freelancers { get; set; }
//     public DbSet<Expertise> Expertises { get; set; }
//     public DbSet<Ping> Pings { get; set; }

//     protected override void OnModelCreating(ModelBuilder modelBuilder)
//     {
//         modelBuilder.Entity<Domain>(etb =>
//         {
//             etb
//                 .HasMany(d => d.Freelancers)
//                 .WithOne(f => f.Domain)
//                 .HasForeignKey(f => f.DomainId);

//             etb
//                 .HasMany(d => d.Expertises)
//                 .WithOne(e => e.Domain)
//                 .HasForeignKey(e => e.DomainId);
//         });

//         modelBuilder.Entity<Freelancer>(etb =>
//         {
//             etb
//                 .HasMany(f => f.Expertises)
//                 .WithMany(e => e.Freelancers)
//                 .UsingEntity<Dictionary<string, object>>(
//                     l => l.HasOne<Expertise>().WithMany().HasForeignKey("ExpertiseId"),
//                     r => r.HasOne<Freelancer>().WithMany().HasForeignKey("FreelancerId"),
//                     j => 
//                         {
//                             j.ToTable("ExpertiseFreelancer");
//                             j.HasKey("FreelancerId", "ExpertiseId");
//                             j.HasData(
//                                 // new { FreelancerId = 1, ExpertiseId = 1 },
//                                 // new { FreelancerId = 1, ExpertiseId = 2 },
//                                 new { FreelancerId = 1, ExpertiseId = 3 }
//                             );
//                         });
//         });


//         // modelBuilder.SeedDomains();
//         // modelBuilder.SeedExpertises();
//         // modelBuilder.SeedFreelancers();
//         // modelBuilder.SeedFreelancerExpertise();

//     }

// }
using System.Data;
using System.Threading;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FMA.Application.NewEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace FMA.Application.Data
{
    // public class PingAFreelancerContextFactory : IDesignTimeDbContextFactory<PingAFreelancerContext>
    // {
    //     public PingAFreelancerContext CreateDbContext(string[] args)
    //     {
    //         var optionsBuilder = new DbContextOptionsBuilder<PingAFreelancerContext>();
    //         optionsBuilder.UseSqlServer("Server=localhost,1433;Database=pafdb;User Id=sa;Password=Kanaan123!;TrustServerCertificate=True");
            
    //         return new PingAFreelancerContext(optionsBuilder.Options);
    //     }
    // }
    public class PingAFreelancerContext : IdentityDbContext<ApplicationUser>
    {
        public PingAFreelancerContext(
            DbContextOptions<PingAFreelancerContext> options) : base(options)
        { 
        }

        public DbSet<Domain> Domains { get; set; }
        public DbSet<FreelancerUser> Freelancers { get; set; }
        public DbSet<ClientUser> Clients { get; set; }
        public DbSet<Expertise> Expertises { get; set; }
        public DbSet<Ping> Pings { get; set; }
        public DbSet<Contract> Contracts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var hasher = new PasswordHasher<ApplicationUser>();

            modelBuilder.Entity<ApplicationUser>(etb =>
            {
                etb.ToTable("AspNetUsers");
                
                etb.Property(u => u.FirstName).IsRequired();
                etb.Property(u => u.LastName).IsRequired();
                etb.Property(u => u.Latitude).IsRequired();
                etb.Property(u => u.Longitude).IsRequired();
                etb.Property(u => u.DateRegistered)
                    .HasColumnType("datetime2")
                    .IsRequired();
                etb.Property(u => u.PhotoPath).IsRequired();
                etb.Property(u => u.Email).IsRequired();
                etb.Property(u => u.UserType).IsRequired();
                
                etb.HasIndex(u => u.Email).IsUnique();
            });

            modelBuilder.Entity<FreelancerUser>(etb =>
            {
                etb.HasKey(f => f.Id);

                etb.ToTable("Freelancers");
                
                etb.Property(f => f.HourlyRate).IsRequired();
                etb.Property(f => f.Rating).IsRequired();
                etb.Property(f => f.FulfilledContracts).IsRequired();
                etb.Property(f => f.HoursBilled).IsRequired();
                etb.Property(f => f.MainExpertiseId).IsRequired();

                etb.HasOne(f => f.Domain)
                    .WithMany(d => d.Freelancers)
                    .HasForeignKey(f => f.DomainId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .IsRequired();
                
                etb.HasOne(f => f.User)
                    .WithOne()
                    .HasForeignKey<FreelancerUser>(f => f.Id)
                    .OnDelete(DeleteBehavior.NoAction);

                etb.HasOne(f => f.Expertise)
                    .WithMany()
                    .HasForeignKey(f => f.MainExpertiseId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .IsRequired();
            });

            modelBuilder.Entity<ClientUser>(etb =>
            {
                etb.ToTable("Clients");

                etb.HasKey(c => c.Id);
                
                etb.Property(c => c.TotalHires).IsRequired();
                
                etb.HasOne(f => f.User)
                    .WithOne()
                    .HasForeignKey<ClientUser>(f => f.Id);
            });

            modelBuilder.Entity<Domain>(etb =>
            {
                etb
                    .HasMany(d => d.Freelancers)
                    .WithOne(f => f.Domain)
                    .HasForeignKey(f => f.DomainId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .IsRequired();

                etb
                    .HasMany(d => d.Expertises)
                    .WithOne(e => e.Domain)
                    .HasForeignKey(e => e.DomainId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .IsRequired();
            });
            modelBuilder.Entity<Expertise>(etb =>
            {
                etb.HasKey(e => e.Id);
                
                etb.HasOne(e => e.Domain)
                    .WithMany(d => d.Expertises)
                    .HasForeignKey(e => e.DomainId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .IsRequired();

                etb.HasMany(e => e.Freelancers)
                    .WithOne(f => f.Expertise)
                    .HasForeignKey(f => f.MainExpertiseId)
                    .OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<Contract>(etb =>
            {
                etb.HasKey(c => c.Id);

                etb.Property(c => c.AmountPaid)
                    .HasColumnType("int"); 
                
                etb.Property(c => c.DateStarted)
                    .HasColumnType("datetime2")
                    .IsRequired();
                    
                etb.Property(c => c.DateCompleted)
                    .HasColumnType("datetime2");

                etb.Property(c => c.Rating)
                    .HasColumnType("int");

                etb.HasOne(c => c.Client)
                    .WithMany(client => client.Contracts)  
                    .HasForeignKey(c => c.ClientId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .IsRequired();

                etb.HasOne(c => c.Freelancer)
                    .WithMany(f => f.Contracts) 
                    .HasForeignKey(c => c.FreelancerId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .IsRequired();
            });

            modelBuilder.Entity<Ping>(etb =>
            {
                etb.HasKey(p => p.Id);

                etb.Property(p => p.DatePinged)
                    .HasColumnType("datetime2")
                    .IsRequired();

                etb.HasOne(p => p.Client)
                    .WithMany(c => c.SentPings) 
                    .HasForeignKey(p => p.ClientId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .IsRequired();

                etb.HasOne(p => p.Freelancer)
                    .WithMany(f => f.ReceivedPings)  
                    .HasForeignKey(p => p.FreelancerId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .IsRequired();
            });

            modelBuilder.Entity<Expertise>().HasData(
                new Expertise { Id = 1, ExpertiseName = "Furniture assembler", DomainId = 1,  PhotoPath = "https://freelanceme.blob.core.windows.net/container1/furniture_assembler", BorderColor = "#fdf1d3" },
                new Expertise { Id = 2, ExpertiseName = "Chauffeur", DomainId = 1, PhotoPath = "https://freelanceme.blob.core.windows.net/container1/chauffeur", BorderColor = "#f3fee7" },
                new Expertise { Id = 3, ExpertiseName = "Painter", DomainId = 1, PhotoPath = "https://freelanceme.blob.core.windows.net/container1/painter", BorderColor = "#fee7e7" },
                new Expertise { Id = 4, ExpertiseName = "Carpenter", DomainId = 1, PhotoPath = "https://freelanceme.blob.core.windows.net/container1/carpenter", BorderColor ="#e7edfe" },
                new Expertise { Id = 5, ExpertiseName = "Roof repairer", DomainId = 1,PhotoPath = "https://freelanceme.blob.core.windows.net/container1/roof_repairer", BorderColor = "#ffeab5" },
                new Expertise { Id = 6, ExpertiseName = "Packer", DomainId = 1, PhotoPath = "https://freelanceme.blob.core.windows.net/container1/packing_service", BorderColor = "#dcffb5" },
                new Expertise { Id = 7, ExpertiseName = "Window cleaner", DomainId = 1, PhotoPath = "https://freelanceme.blob.core.windows.net/container1/window_cleaner", BorderColor = "#fdf1d3" },
                new Expertise { Id = 8, ExpertiseName = "Yard worker", DomainId = 1, PhotoPath = "https://freelanceme.blob.core.windows.net/container1/yard_worker", BorderColor = "#f3fee7" },
                
                new Expertise { Id = 9, ExpertiseName = "Housekeeper", DomainId = 2, PhotoPath = "https://freelanceme.blob.core.windows.net/container1/housekeeper", BorderColor = "#fee7e7" },
                new Expertise { Id = 10, ExpertiseName = "Housesitter", DomainId = 2, PhotoPath = "https://freelanceme.blob.core.windows.net/container1/housesitter", BorderColor = "#e7edfe" },
                new Expertise { Id = 11, ExpertiseName = "Babysitter", DomainId = 2, PhotoPath = "https://freelanceme.blob.core.windows.net/container1/babysitter", BorderColor = "#ffeab5" },
                new Expertise { Id = 12, ExpertiseName = "Nanny", DomainId = 2, PhotoPath = "https://freelanceme.blob.core.windows.net/container1/nanny", BorderColor = "#dcffb5" },
                new Expertise { Id = 13, ExpertiseName = "Caregiver", DomainId = 2, PhotoPath = "https://freelanceme.blob.core.windows.net/container1/caregiver", BorderColor = "#fdf1d3" },
                new Expertise { Id = 14, ExpertiseName = "Cook", DomainId = 2, PhotoPath = "https://freelanceme.blob.core.windows.net/container1/cook", BorderColor = "#f3fee7" }, 
                new Expertise { Id = 15, ExpertiseName = "Kitchen cleaner", DomainId = 2, PhotoPath = "https://freelanceme.blob.core.windows.net/container1/kitchen_cleaner", BorderColor = "#fee7e7" },
                new Expertise { Id = 16, ExpertiseName = "Gardener", DomainId = 2, PhotoPath = "https://freelanceme.blob.core.windows.net/container1/gardener", BorderColor = "#e7edfe" },
                new Expertise { Id = 17, ExpertiseName = "Grocery shopper", DomainId = 2, PhotoPath = "https://freelanceme.blob.core.windows.net/container1/grocery_shopper", BorderColor = "#ffeab5" },
                new Expertise { Id = 18, ExpertiseName = "Errand runner", DomainId = 2, PhotoPath = "https://freelanceme.blob.core.windows.net/container1/errand_runner", BorderColor = "#dcffb5" },
                new Expertise { Id = 19, ExpertiseName = "Bartender", DomainId = 2, PhotoPath = "https://freelanceme.blob.core.windows.net/container1/bartender", BorderColor = "#fdf1d3" },

                new Expertise { Id = 20, ExpertiseName = "Chiropractor", DomainId = 3, PhotoPath = "https://freelanceme.blob.core.windows.net/container1/chiropractor", BorderColor = "#f3fee7" },
                new Expertise { Id = 21, ExpertiseName = "Health aide", DomainId = 3, PhotoPath = "https://freelanceme.blob.core.windows.net/container1/health_aide", BorderColor = "#fee7e7" },
                new Expertise { Id = 22, ExpertiseName = "Personal trainer", DomainId = 3, PhotoPath = "https://freelanceme.blob.core.windows.net/container1/personal_trainer", BorderColor = "#e7edfe" },
                new Expertise { Id = 23, ExpertiseName = "Physiotherapist", DomainId = 3, PhotoPath = "https://freelanceme.blob.core.windows.net/container1/physiotherapist", BorderColor = "#ffeab5" },
                new Expertise { Id = 24, ExpertiseName = "Yoga instructor", DomainId = 3, PhotoPath = "https://freelanceme.blob.core.windows.net/container1/yoga_instructor", BorderColor = "#dcffb5" },
                new Expertise { Id = 25, ExpertiseName = "Elderly companion", DomainId = 3, PhotoPath = "https://freelanceme.blob.core.windows.net/container1/elderly_companion", BorderColor = "#fdf1d3" }, 

                new Expertise { Id = 26, ExpertiseName = "Tutor", DomainId = 4, PhotoPath = "https://freelanceme.blob.core.windows.net/container1/tutor", BorderColor = "#f3fee7" },
                new Expertise { Id = 27, ExpertiseName = "Personal assistant", DomainId = 4, PhotoPath = "https://freelanceme.blob.core.windows.net/container1/personal_assistant", BorderColor = "#fee7e7" },
                new Expertise { Id = 28, ExpertiseName = "Interior designer", DomainId = 4, PhotoPath = "https://freelanceme.blob.core.windows.net/container1/interior_designer", BorderColor = "#e7edfe" },
                new Expertise { Id = 29, ExpertiseName = "Stylist", DomainId = 4, PhotoPath = "https://freelanceme.blob.core.windows.net/container1/stylist", BorderColor = "#ffeab5" },
                new Expertise { Id = 30, ExpertiseName = "Photographer", DomainId = 4, PhotoPath = "https://freelanceme.blob.core.windows.net/container1/photographer", BorderColor = "#dcffb5" },
                new Expertise { Id = 31, ExpertiseName = "Life Coach", DomainId = 4, PhotoPath = "https://freelanceme.blob.core.windows.net/container1/life_coach", BorderColor = "#fdf1d3" },

                new Expertise { Id = 32, ExpertiseName = "WiFi technician", DomainId = 5, PhotoPath = "https://freelanceme.blob.core.windows.net/container1/wifi_technician", BorderColor = "#f3fee7" },
                new Expertise { Id = 33, ExpertiseName = "Computer repair technician", DomainId = 5, PhotoPath = "https://freelanceme.blob.core.windows.net/container1/computer_repair_technician", BorderColor = "#fee7e7" },
                new Expertise { Id = 34, ExpertiseName = "Electrical appliance installer", DomainId = 5, PhotoPath = "https://freelanceme.blob.core.windows.net/container1/electrical_appliance_installer", BorderColor = "#e7edfe" },
                new Expertise { Id = 35, ExpertiseName = "Smart home device installer", DomainId = 5, PhotoPath = "https://freelanceme.blob.core.windows.net/container1/smart_home_device_installer", BorderColor = "#ffeab5" },
                new Expertise { Id = 36, ExpertiseName = "Home security system installer", DomainId = 5, PhotoPath = "https://freelanceme.blob.core.windows.net/container1/home_security_system_installer", BorderColor = "#dcffb5" },

                new Expertise { Id = 37, ExpertiseName = "Pet sitter", DomainId = 6, PhotoPath = "https://freelanceme.blob.core.windows.net/container1/pet_sitter", BorderColor = "#fdf1d3" },
                new Expertise { Id = 38, ExpertiseName = "Dog walker", DomainId = 6, PhotoPath = "https://freelanceme.blob.core.windows.net/container1/dog_walker", BorderColor = "#f3fee7" },
                new Expertise { Id = 39, ExpertiseName = "Pet groomer", DomainId = 6, PhotoPath = "https://freelanceme.blob.core.windows.net/container1/pet_groomer", BorderColor = "#fee7e7" },

                new Expertise { Id = 40, ExpertiseName = "Music teacher", DomainId = 7, PhotoPath = "https://freelanceme.blob.core.windows.net/container1/music_teacher", BorderColor = "#e7edfe" },
                new Expertise { Id = 41, ExpertiseName = "Dance instructor", DomainId = 7, PhotoPath = "https://freelanceme.blob.core.windows.net/container1/dance_instructor", BorderColor = "#ffeab5" },
                new Expertise { Id = 42, ExpertiseName = "Live music performer", DomainId = 7, PhotoPath = "https://freelanceme.blob.core.windows.net/container1/live_music_performer", BorderColor = "#dcffb5" }
            ); 

            modelBuilder.Entity<Domain>().HasData(
                new Domain { Id = 1, DomainName = "Manual Labor", PhotoPath = "https://freelanceme.blob.core.windows.net/container1/manual_labor", BorderColor = "#fdf1d3" },
                new Domain { Id = 2, DomainName = "Domestic Services", PhotoPath = "https://freelanceme.blob.core.windows.net/container1/domestic_services", BorderColor = "#f3fee7" },
                new Domain { Id = 3, DomainName = "Health & Wellness ", PhotoPath = "https://freelanceme.blob.core.windows.net/container1/health_and_wellness", BorderColor = "#fee7e7" },
                new Domain { Id = 4, DomainName = "Business Services", PhotoPath = "https://freelanceme.blob.core.windows.net/container1/business_services", BorderColor ="#e7edfe" },
                new Domain { Id = 5, DomainName = "Home Technology", PhotoPath = "https://freelanceme.blob.core.windows.net/container1/home_technology", BorderColor = "#ffeab5" },
                new Domain { Id = 6, DomainName = "Pet Care", PhotoPath = "https://freelanceme.blob.core.windows.net/container1/pets", BorderColor="#dcffb5" },
                new Domain { Id = 7, DomainName = "Performing Arts", PhotoPath = "https://freelanceme.blob.core.windows.net/container1/performing_arts", BorderColor = "#fdf1d3" }
            );

            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "id-kanaan-abukhadra",
                    UserType = UserType.Client,
                    FirstName = "Kanaan",
                    LastName = "Abukhadra",
                    DateRegistered = DateTime.UtcNow,
                    PhotoPath = "https://freelanceme.blob.core.windows.net/container1/kanaan",
                    Email = "kanaanabukhadra@gmail.com",
                    UserName = "kanaanabukhadra@gmail.com",
                    NormalizedUserName = "KANAANABUKHADRA@GMAIL.COM",
                    NormalizedEmail = "KANAANABUKHADRA@GMAIL.COM",
                    PhoneNumber = "+966503725354",
                    Latitude = 26.33,
                    Longitude = 50.13,
                    IsActive = true,
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Kanaan123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new ApplicationUser
                {
                    Id = "id-abdullah-alsaud",
                    UserType = UserType.Freelancer,
                    FirstName = "Abdullah",
                    LastName = "AlSaud",
                    DateRegistered = DateTime.UtcNow.Date.AddDays(-60),
                    PhotoPath = "https://freelanceme.blob.core.windows.net/container1/a1",
                    Email = "abdullah@pingafreelancer.com",
                    UserName = "abdullah@pingafreelancer.com",
                    NormalizedUserName = "ABDULLAH@PINGAFREELANCER.COM",
                    NormalizedEmail = "ABDULLAH@PINGAFREELANCER.COM",
                    PhoneNumber = "+966501234567",
                    Latitude = 24.7136,
                    Longitude = 46.6753,
                    IsActive = true,
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Abdullah123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new ApplicationUser
                {
                    Id = "id-mohammed-alghamdi",
                    UserType = UserType.Freelancer,
                    FirstName = "Mohammed",
                    LastName = "AlGhamdi",
                    DateRegistered = DateTime.UtcNow.Date.AddDays(-55),
                    PhotoPath = "https://freelanceme.blob.core.windows.net/container1/a2",
                    Email = "mohammed@pingafreelancer.com",
                    UserName = "mohammed@pingafreelancer.com",
                    NormalizedUserName = "MOHAMMED@PINGAFREELANCER.COM",
                    NormalizedEmail = "MOHAMMED@PINGAFREELANCER.COM",
                    PhoneNumber = "+966502345678",
                    Latitude = 21.4858,
                    Longitude = 39.1925,
                    IsActive = true,
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Mohammed123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                }
            );
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "id-ahmed-alshehri",
                    UserType = UserType.Freelancer,
                    FirstName = "Ahmed",
                    LastName = "AlShehri",
                    DateRegistered = DateTime.UtcNow.Date.AddDays(-50),
                    PhotoPath = "https://freelanceme.blob.core.windows.net/container1/a3",
                    Email = "ahmed@pingafreelancer.com",
                    UserName = "ahmed@pingafreelancer.com",
                    NormalizedUserName = "AHMED@PINGAFREELANCER.COM",
                    NormalizedEmail = "AHMED@PINGAFREELANCER.COM",
                    PhoneNumber = "+966503456789",
                    Latitude = 26.2361,
                    Longitude = 50.0393,
                    IsActive = true,
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Ahmed123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new ApplicationUser
                {
                    Id = "id-khalid-alqahtani",
                    UserType = UserType.Freelancer,
                    FirstName = "Khalid",
                    LastName = "AlQahtani",
                    DateRegistered = DateTime.UtcNow.Date.AddDays(-45),
                    PhotoPath = "https://freelanceme.blob.core.windows.net/container1/a4",
                    Email = "khalid@pingafreelancer.com",
                    UserName = "khalid@pingafreelancer.com",
                    NormalizedUserName = "KHALID@PINGAFREELANCER.COM",
                    NormalizedEmail = "KHALID@PINGAFREELANCER.COM",
                    PhoneNumber = "+966504567890",
                    Latitude = 24.4667,
                    Longitude = 39.6000,
                    IsActive = true,
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Khalid123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new ApplicationUser
                {
                    Id = "id-omar-aldosari",
                    UserType = UserType.Freelancer,
                    FirstName = "Omar",
                    LastName = "AlDosari",
                    DateRegistered = DateTime.UtcNow.Date.AddDays(-40),
                    PhotoPath = "https://freelanceme.blob.core.windows.net/container1/a5",
                    Email = "omar@pingafreelancer.com",
                    UserName = "omar@pingafreelancer.com",
                    NormalizedUserName = "OMAR@PINGAFREELANCER.COM",
                    NormalizedEmail = "OMAR@PINGAFREELANCER.COM",
                    PhoneNumber = "+966505678901",
                    Latitude = 26.4207,
                    Longitude = 50.0888,
                    IsActive = true,
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Omar123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new ApplicationUser
                {
                    Id = "id-saad-alharbi",
                    UserType = UserType.Freelancer,
                    FirstName = "Saad",
                    LastName = "AlHarbi",
                    DateRegistered = DateTime.UtcNow.Date.AddDays(-35),
                    PhotoPath = "https://freelanceme.blob.core.windows.net/container1/a6",
                    Email = "saad@pingafreelancer.com",
                    UserName = "saad@pingafreelancer.com",
                    NormalizedUserName = "SAAD@PINGAFREELANCER.COM",
                    NormalizedEmail = "SAAD@PINGAFREELANCER.COM",
                    PhoneNumber = "+966506789012",
                    Latitude = 21.2707,
                    Longitude = 40.4167,
                    IsActive = true,
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Saad123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new ApplicationUser
                {
                    Id = "id-faisal-alotaibi",
                    UserType = UserType.Freelancer,
                    FirstName = "Faisal",
                    LastName = "AlOtaibi",
                    DateRegistered = DateTime.UtcNow.Date.AddDays(-30),
                    PhotoPath = "https://freelanceme.blob.core.windows.net/container1/a7",
                    Email = "faisal@pingafreelancer.com",
                    UserName = "faisal@pingafreelancer.com",
                    NormalizedUserName = "FAISAL@PINGAFREELANCER.COM",
                    NormalizedEmail = "FAISAL@PINGAFREELANCER.COM",
                    PhoneNumber = "+966507890123",
                    Latitude = 26.0851,
                    Longitude = 43.9731,
                    IsActive = true,
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Faisal123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new ApplicationUser
                {
                    Id = "id-majid-alahmadi",
                    UserType = UserType.Freelancer,
                    FirstName = "Majid",
                    LastName = "AlAhmadi",
                    DateRegistered = DateTime.UtcNow.Date.AddDays(-25),
                    PhotoPath = "https://freelanceme.blob.core.windows.net/container1/a8",
                    Email = "majid@pingafreelancer.com",
                    UserName = "majid@pingafreelancer.com",
                    NormalizedUserName = "MAJID@PINGAFREELANCER.COM",
                    NormalizedEmail = "MAJID@PINGAFREELANCER.COM",
                    PhoneNumber = "+966508901234",
                    Latitude = 18.2164,
                    Longitude = 42.5053,
                    IsActive = true,
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Majid123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new ApplicationUser
                {
                    Id = "id-turki-alsultan",
                    UserType = UserType.Freelancer,
                    FirstName = "Turki",
                    LastName = "AlSultan",
                    DateRegistered = DateTime.UtcNow.Date.AddDays(-20),
                    PhotoPath = "https://freelanceme.blob.core.windows.net/container1/a9",
                    Email = "turki@pingafreelancer.com",
                    UserName = "turki@pingafreelancer.com",
                    NormalizedUserName = "TURKI@PINGAFREELANCER.COM",
                    NormalizedEmail = "TURKI@PINGAFREELANCER.COM",
                    PhoneNumber = "+966509012345",
                    Latitude = 25.3841,
                    Longitude = 49.5876,
                    IsActive = true,
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Turki123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new ApplicationUser
                {
                    Id = "id-fahad-almalki",
                    UserType = UserType.Freelancer,
                    FirstName = "Fahad",
                    LastName = "AlMalki",
                    DateRegistered = DateTime.UtcNow.Date.AddDays(-15),
                    PhotoPath = "https://freelanceme.blob.core.windows.net/container1/a10",
                    Email = "fahad@pingafreelancer.com",
                    UserName = "fahad@pingafreelancer.com",
                    NormalizedUserName = "FAHAD@PINGAFREELANCER.COM",
                    NormalizedEmail = "FAHAD@PINGAFREELANCER.COM",
                    PhoneNumber = "+966510123456",
                    Latitude = 27.5236,
                    Longitude = 41.6954,
                    IsActive = true,
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Fahad123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new ApplicationUser
                {
                    Id = "id-hassan-alzahrani",
                    UserType = UserType.Freelancer,
                    FirstName = "Hassan",
                    LastName = "AlZahrani",
                    DateRegistered = DateTime.UtcNow.Date.AddDays(-10),
                    PhotoPath = "https://freelanceme.blob.core.windows.net/container1/a11",
                    Email = "hassan@pingafreelancer.com",
                    UserName = "hassan@pingafreelancer.com",
                    NormalizedUserName = "HASSAN@PINGAFREELANCER.COM",
                    NormalizedEmail = "HASSAN@PINGAFREELANCER.COM",
                    PhoneNumber = "+966511234567",
                    Latitude = 17.4933,
                    Longitude = 44.1290,
                    IsActive = true,
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Hassan123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new ApplicationUser
                {
                    Id = "id-nasser-alyami",
                    UserType = UserType.Freelancer,
                    FirstName = "Nasser",
                    LastName = "AlYami",
                    DateRegistered = DateTime.UtcNow.Date.AddDays(-5),
                    PhotoPath = "https://freelanceme.blob.core.windows.net/container1/a12",
                    Email = "nasser@pingafreelancer.com",
                    UserName = "nasser@pingafreelancer.com",
                    NormalizedUserName = "NASSER@PINGAFREELANCER.COM",
                    NormalizedEmail = "NASSER@PINGAFREELANCER.COM",
                    PhoneNumber = "+966512345678",
                    Latitude = 24.5247,
                    Longitude = 39.5692,
                    IsActive = true,
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Nasser123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new ApplicationUser
                {
                    Id = "id-sami-alomairi",
                    UserType = UserType.Freelancer,
                    FirstName = "Sami",
                    LastName = "AlOmairi",
                    DateRegistered = DateTime.UtcNow.Date.AddDays(-1),
                    PhotoPath = "https://freelanceme.blob.core.windows.net/container1/a13",
                    Email = "sami@pingafreelancer.com",
                    UserName = "sami@pingafreelancer.com",
                    NormalizedUserName = "SAMI@PINGAFREELANCER.COM",
                    NormalizedEmail = "SAMI@PINGAFREELANCER.COM",
                    PhoneNumber = "+966513456789",
                    Latitude = 30.0984,
                    Longitude = 40.2854,
                    IsActive = true,
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Sami123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new ApplicationUser
                {
                    Id = "id-yasser-alsubaie",
                    UserType = UserType.Freelancer,
                    FirstName = "Yasser",
                    LastName = "AlSubaie",
                    DateRegistered = DateTime.UtcNow.Date.AddDays(-2),
                    PhotoPath = "https://freelanceme.blob.core.windows.net/container1/a14",
                    Email = "yasser@pingafreelancer.com",
                    UserName = "yasser@pingafreelancer.com",
                    NormalizedUserName = "YASSER@PINGAFREELANCER.COM",
                    NormalizedEmail = "YASSER@PINGAFREELANCER.COM",
                    PhoneNumber = "+966514567890",
                    Latitude = 28.3998,
                    Longitude = 36.5714,
                    IsActive = true,
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Yasser123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new ApplicationUser
                {
                    Id = "id-waleed-alsaif",
                    UserType = UserType.Freelancer,
                    FirstName = "Waleed",
                    LastName = "AlSaif",
                    DateRegistered = DateTime.UtcNow.Date.AddDays(-3),
                    PhotoPath = "https://freelanceme.blob.core.windows.net/container1/a15",
                    Email = "waleed@pingafreelancer.com",
                    UserName = "waleed@pingafreelancer.com",
                    NormalizedUserName = "WALEED@PINGAFREELANCER.COM",
                    NormalizedEmail = "WALEED@PINGAFREELANCER.COM",
                    PhoneNumber = "+966515678901",
                    Latitude = 25.6640,
                    Longitude = 42.6996,
                    IsActive = true,
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Waleed123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new ApplicationUser
                {
                    Id = "id-abdulaziz-alrashid",
                    UserType = UserType.Freelancer,
                    FirstName = "Abdulaziz",
                    LastName = "AlRashid",
                    DateRegistered = DateTime.UtcNow.Date.AddDays(-4),
                    PhotoPath = "https://freelanceme.blob.core.windows.net/container1/a16",
                    Email = "abdulaziz@pingafreelancer.com",
                    UserName = "abdulaziz@pingafreelancer.com",
                    NormalizedUserName = "ABDULAZIZ@PINGAFREELANCER.COM",
                    NormalizedEmail = "ABDULAZIZ@PINGAFREELANCER.COM",
                    PhoneNumber = "+966516789012",
                    Latitude = 27.5236,
                    Longitude = 41.6954,
                    IsActive = true,
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Abdulaziz123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new ApplicationUser
                {
                    Id = "id-bandar-aldakhil",
                    UserType = UserType.Freelancer,
                    FirstName = "Bandar",
                    LastName = "AlDakhil",
                    DateRegistered = DateTime.UtcNow.Date.AddDays(-5),
                    PhotoPath = "https://freelanceme.blob.core.windows.net/container1/a17",
                    Email = "bandar@pingafreelancer.com",
                    UserName = "bandar@pingafreelancer.com",
                    NormalizedUserName = "BANDAR@PINGAFREELANCER.COM",
                    NormalizedEmail = "BANDAR@PINGAFREELANCER.COM",
                    PhoneNumber = "+966517890123",
                    Latitude = 21.4858,
                    Longitude = 39.1925,
                    IsActive = true,
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Bandar123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new ApplicationUser
                {
                    Id = "id-meshal-alfahad",
                    UserType = UserType.Freelancer,
                    FirstName = "Meshal",
                    LastName = "AlFahad",
                    DateRegistered = DateTime.UtcNow.Date.AddDays(-6),
                    PhotoPath = "https://freelanceme.blob.core.windows.net/container1/a18",
                    Email = "meshal@pingafreelancer.com",
                    UserName = "meshal@pingafreelancer.com",
                    NormalizedUserName = "MESHAL@PINGAFREELANCER.COM",
                    NormalizedEmail = "MESHAL@PINGAFREELANCER.COM",
                    PhoneNumber = "+966518901234",
                    Latitude = 26.2361,
                    Longitude = 50.0393,
                    IsActive = true,
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Meshal123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new ApplicationUser
                {
                    Id = "id-john-smith",
                    UserType = UserType.Freelancer,
                    FirstName = "John",
                    LastName = "Smith",
                    DateRegistered = DateTime.UtcNow.Date.AddDays(-7),
                    PhotoPath = "https://freelanceme.blob.core.windows.net/container1/n1",
                    Email = "john@pingafreelancer.com",
                    UserName = "john@pingafreelancer.com",
                    NormalizedUserName = "JOHN@PINGAFREELANCER.COM",
                    NormalizedEmail = "JOHN@PINGAFREELANCER.COM",
                    PhoneNumber = "+966519012345",
                    Latitude = 24.4667,
                    Longitude = 39.6000,
                    IsActive = true,
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "John123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new ApplicationUser
                {
                    Id = "id-michael-johnson",
                    UserType = UserType.Freelancer,
                    FirstName = "Michael",
                    LastName = "Johnson",
                    DateRegistered = DateTime.UtcNow.Date.AddDays(-8),
                    PhotoPath = "https://freelanceme.blob.core.windows.net/container1/n2",
                    Email = "michael@pingafreelancer.com",
                    UserName = "michael@pingafreelancer.com",
                    NormalizedUserName = "MICHAEL@PINGAFREELANCER.COM",
                    NormalizedEmail = "MICHAEL@PINGAFREELANCER.COM",
                    PhoneNumber = "+966520123456",
                    Latitude = 26.4207,
                    Longitude = 50.0888,
                    IsActive = true,
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Michael123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new ApplicationUser
                {
                    Id = "id-david-brown",
                    UserType = UserType.Freelancer,
                    FirstName = "David",
                    LastName = "Brown",
                    DateRegistered = DateTime.UtcNow.Date.AddDays(-9),
                    PhotoPath = "https://freelanceme.blob.core.windows.net/container1/n3",
                    Email = "david@pingafreelancer.com",
                    UserName = "david@pingafreelancer.com",
                    NormalizedUserName = "DAVID@PINGAFREELANCER.COM",
                    NormalizedEmail = "DAVID@PINGAFREELANCER.COM",
                    PhoneNumber = "+966521234567",
                    Latitude = 21.2707,
                    Longitude = 40.4167,
                    IsActive = true,
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "David123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new ApplicationUser
                {
                    Id = "id-christopher-davis",
                    UserType = UserType.Freelancer,
                    FirstName = "Christopher",
                    LastName = "Davis",
                    DateRegistered = DateTime.UtcNow.Date.AddDays(-10),
                    PhotoPath = "https://freelanceme.blob.core.windows.net/container1/n4",
                    Email = "christopher@pingafreelancer.com",
                    UserName = "christopher@pingafreelancer.com",
                    NormalizedUserName = "CHRISTOPHER@PINGAFREELANCER.COM",
                    NormalizedEmail = "CHRISTOPHER@PINGAFREELANCER.COM",
                    PhoneNumber = "+966522345678",
                    Latitude = 26.0851,
                    Longitude = 43.9731,
                    IsActive = true,
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Christopher123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new ApplicationUser
                {
                    Id = "id-matthew-wilson",
                    UserType = UserType.Freelancer,
                    FirstName = "Matthew",
                    LastName = "Wilson",
                    DateRegistered = DateTime.UtcNow.Date.AddDays(-11),
                    PhotoPath = "https://freelanceme.blob.core.windows.net/container1/n5",
                    Email = "matthew@pingafreelancer.com",
                    UserName = "matthew@pingafreelancer.com",
                    NormalizedUserName = "MATTHEW@PINGAFREELANCER.COM",
                    NormalizedEmail = "MATTHEW@PINGAFREELANCER.COM",
                    PhoneNumber = "+966523456789",
                    Latitude = 18.2164,
                    Longitude = 42.5053,
                    IsActive = true,
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Matthew123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new ApplicationUser
                {
                    Id = "id-daniel-taylor",
                    UserType = UserType.Freelancer,
                    FirstName = "Daniel",
                    LastName = "Taylor",
                    DateRegistered = DateTime.UtcNow.Date.AddDays(-12),
                    PhotoPath = "https://freelanceme.blob.core.windows.net/container1/n6",
                    Email = "daniel@pingafreelancer.com",
                    UserName = "daniel@pingafreelancer.com",
                    NormalizedUserName = "DANIEL@PINGAFREELANCER.COM",
                    NormalizedEmail = "DANIEL@PINGAFREELANCER.COM",
                    PhoneNumber = "+966524567890",
                    Latitude = 25.3841,
                    Longitude = 49.5876,
                    IsActive = true,
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Daniel123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new ApplicationUser
                {
                    Id = "id-andrew-anderson",
                    UserType = UserType.Freelancer,
                    FirstName = "Andrew",
                    LastName = "Anderson",
                    DateRegistered = DateTime.UtcNow.Date.AddDays(-13),
                    PhotoPath = "https://freelanceme.blob.core.windows.net/container1/n7",
                    Email = "andrew@pingafreelancer.com",
                    UserName = "andrew@pingafreelancer.com",
                    NormalizedUserName = "ANDREW@PINGAFREELANCER.COM",
                    NormalizedEmail = "ANDREW@PINGAFREELANCER.COM",
                    PhoneNumber = "+966525678901",
                    Latitude = 27.5236,
                    Longitude = 41.6954,
                    IsActive = true,
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Andrew123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new ApplicationUser
                {
                    Id = "id-joseph-thomas",
                    UserType = UserType.Freelancer,
                    FirstName = "Joseph",
                    LastName = "Thomas",
                    DateRegistered = DateTime.UtcNow.Date.AddDays(-14),
                    PhotoPath = "https://freelanceme.blob.core.windows.net/container1/n8",
                    Email = "joseph@pingafreelancer.com",
                    UserName = "joseph@pingafreelancer.com",
                    NormalizedUserName = "JOSEPH@PINGAFREELANCER.COM",
                    NormalizedEmail = "JOSEPH@PINGAFREELANCER.COM",
                    PhoneNumber = "+966526789012",
                    Latitude = 17.4933,
                    Longitude = 44.1290,
                    IsActive = true,
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Joseph123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new ApplicationUser
                {
                    Id = "id-william-jackson",
                    UserType = UserType.Freelancer,
                    FirstName = "William",
                    LastName = "Jackson",
                    DateRegistered = DateTime.UtcNow.Date.AddDays(-15),
                    PhotoPath = "https://freelanceme.blob.core.windows.net/container1/n9",
                    Email = "william@pingafreelancer.com",
                    UserName = "william@pingafreelancer.com",
                    NormalizedUserName = "WILLIAM@PINGAFREELANCER.COM",
                    NormalizedEmail = "WILLIAM@PINGAFREELANCER.COM",
                    PhoneNumber = "+966527890123",
                    Latitude = 24.5247,
                    Longitude = 39.5692,
                    IsActive = true,
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "William123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new ApplicationUser
                {
                    Id = "id-fatima-alotaibi",
                    UserType = UserType.Freelancer,
                    FirstName = "Fatima",
                    LastName = "AlOtaibi",
                    DateRegistered = DateTime.UtcNow.Date.AddDays(-16),
                    PhotoPath = "https://freelanceme.blob.core.windows.net/container1/f1",
                    Email = "fatima@pingafreelancer.com",
                    UserName = "fatima@pingafreelancer.com",
                    NormalizedUserName = "FATIMA@PINGAFREELANCER.COM",
                    NormalizedEmail = "FATIMA@PINGAFREELANCER.COM",
                    PhoneNumber = "+966528901234",
                    Latitude = 30.0984,
                    Longitude = 40.2854,
                    IsActive = true,
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Fatima123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new ApplicationUser
                {
                    Id = "id-aisha-alqahtani",
                    UserType = UserType.Freelancer,
                    FirstName = "Aisha",
                    LastName = "AlQahtani",
                    DateRegistered = DateTime.UtcNow.Date.AddDays(-17),
                    PhotoPath = "https://freelanceme.blob.core.windows.net/container1/f2",
                    Email = "aisha@pingafreelancer.com",
                    UserName = "aisha@pingafreelancer.com",
                    NormalizedUserName = "AISHA@PINGAFREELANCER.COM",
                    NormalizedEmail = "AISHA@PINGAFREELANCER.COM",
                    PhoneNumber = "+966529012345",
                    Latitude = 28.3998,
                    Longitude = 36.5714,
                    IsActive = true,
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Aisha123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new ApplicationUser
                {
                    Id = "id-noura-alshehri",
                    UserType = UserType.Freelancer,
                    FirstName = "Noura",
                    LastName = "AlShehri",
                    DateRegistered = DateTime.UtcNow.Date.AddDays(-18),
                    PhotoPath = "https://freelanceme.blob.core.windows.net/container1/f3",
                    Email = "noura@pingafreelancer.com",
                    UserName = "noura@pingafreelancer.com",
                    NormalizedUserName = "NOURA@PINGAFREELANCER.COM",
                    NormalizedEmail = "NOURA@PINGAFREELANCER.COM",
                    PhoneNumber = "+966530123456",
                    Latitude = 25.6640,
                    Longitude = 42.6996,
                    IsActive = true,
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Noura123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new ApplicationUser
                {
                    Id = "id-maryam-alghamdi",
                    UserType = UserType.Freelancer,
                    FirstName = "Maryam",
                    LastName = "AlGhamdi",
                    DateRegistered = DateTime.UtcNow.Date.AddDays(-19),
                    PhotoPath = "https://freelanceme.blob.core.windows.net/container1/f4",
                    Email = "maryam@pingafreelancer.com",
                    UserName = "maryam@pingafreelancer.com",
                    NormalizedUserName = "MARYAM@PINGAFREELANCER.COM",
                    NormalizedEmail = "MARYAM@PINGAFREELANCER.COM",
                    PhoneNumber = "+966531234567",
                    Latitude = 27.5236,
                    Longitude = 41.6954,
                    IsActive = true,
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Maryam123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new ApplicationUser
                {
                    Id = "id-layla-aldosari",
                    UserType = UserType.Freelancer,
                    FirstName = "Layla",
                    LastName = "AlDosari",
                    DateRegistered = DateTime.UtcNow.Date.AddDays(-20),
                    PhotoPath = "https://freelanceme.blob.core.windows.net/container1/f5",
                    Email = "layla@pingafreelancer.com",
                    UserName = "layla@pingafreelancer.com",
                    NormalizedUserName = "LAYLA@PINGAFREELANCER.COM",
                    NormalizedEmail = "LAYLA@PINGAFREELANCER.COM",
                    PhoneNumber = "+966532345678",
                    Latitude = 21.4858,
                    Longitude = 39.1925,
                    IsActive = true,
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Layla123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new ApplicationUser
                {
                    Id = "id-amira-alharbi",
                    UserType = UserType.Freelancer,
                    FirstName = "Amira",
                    LastName = "AlHarbi",
                    DateRegistered = DateTime.UtcNow.Date.AddDays(-21),
                    PhotoPath = "https://freelanceme.blob.core.windows.net/container1/f6",
                    Email = "amira@pingafreelancer.com",
                    UserName = "amira@pingafreelancer.com",
                    NormalizedUserName = "AMIRA@PINGAFREELANCER.COM",
                    NormalizedEmail = "AMIRA@PINGAFREELANCER.COM",
                    PhoneNumber = "+966533456789",
                    Latitude = 26.2361,
                    Longitude = 50.0393,
                    IsActive = true,
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Amira123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new ApplicationUser
                {
                    Id = "id-noor-alsultan",
                    UserType = UserType.Freelancer,
                    FirstName = "Noor",
                    LastName = "AlSultan",
                    DateRegistered = DateTime.UtcNow.Date.AddDays(-22),
                    PhotoPath = "https://freelanceme.blob.core.windows.net/container1/f7",
                    Email = "noor@pingafreelancer.com",
                    UserName = "noor@pingafreelancer.com",
                    NormalizedUserName = "NOOR@PINGAFREELANCER.COM",
                    NormalizedEmail = "NOOR@PINGAFREELANCER.COM",
                    PhoneNumber = "+966534567890",
                    Latitude = 24.4667,
                    Longitude = 39.6000,
                    IsActive = true,
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Noor123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new ApplicationUser
                {
                    Id = "id-reem-almalki",
                    UserType = UserType.Freelancer,
                    FirstName = "Reem",
                    LastName = "AlMalki",
                    DateRegistered = DateTime.UtcNow.Date.AddDays(-23),
                    PhotoPath = "https://freelanceme.blob.core.windows.net/container1/f8",
                    Email = "reem@pingafreelancer.com",
                    UserName = "reem@pingafreelancer.com",
                    NormalizedUserName = "REEM@PINGAFREELANCER.COM",
                    NormalizedEmail = "REEM@PINGAFREELANCER.COM",
                    PhoneNumber = "+966535678901",
                    Latitude = 26.4207,
                    Longitude = 50.0888,
                    IsActive = true,
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Reem123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new ApplicationUser
                {
                    Id = "id-hana-alzahrani",
                    UserType = UserType.Freelancer,
                    FirstName = "Hana",
                    LastName = "AlZahrani",
                    DateRegistered = DateTime.UtcNow.Date.AddDays(-24),
                    PhotoPath = "https://freelanceme.blob.core.windows.net/container1/f9",
                    Email = "hana@pingafreelancer.com",
                    UserName = "hana@pingafreelancer.com",
                    NormalizedUserName = "HANA@PINGAFREELANCER.COM",
                    NormalizedEmail = "HANA@PINGAFREELANCER.COM",
                    PhoneNumber = "+966536789012",
                    Latitude = 21.2707,
                    Longitude = 40.4167,
                    IsActive = true,
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Hana123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new ApplicationUser
                {
                    Id = "id-sara-alyami",
                    UserType = UserType.Freelancer,
                    FirstName = "Sara",
                    LastName = "AlYami",
                    DateRegistered = DateTime.UtcNow.Date.AddDays(-25),
                    PhotoPath = "https://freelanceme.blob.core.windows.net/container1/f10",
                    Email = "sara@pingafreelancer.com",
                    UserName = "sara@pingafreelancer.com",
                    NormalizedUserName = "SARA@PINGAFREELANCER.COM",
                    NormalizedEmail = "SARA@PINGAFREELANCER.COM",
                    PhoneNumber = "+966537890123",
                    Latitude = 26.0851,
                    Longitude = 43.9731,
                    IsActive = true,
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Sara123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new ApplicationUser
                {
                    Id = "id-lina-alomairi",
                    UserType = UserType.Freelancer,
                    FirstName = "Lina",
                    LastName = "AlOmairi",
                    DateRegistered = DateTime.UtcNow.Date.AddDays(-26),
                    PhotoPath = "https://freelanceme.blob.core.windows.net/container1/f11",
                    Email = "lina@pingafreelancer.com",
                    UserName = "lina@pingafreelancer.com",
                    NormalizedUserName = "LINA@PINGAFREELANCER.COM",
                    NormalizedEmail = "LINA@PINGAFREELANCER.COM",
                    PhoneNumber = "+966538901234",
                    Latitude = 18.2164,
                    Longitude = 42.5053,
                    IsActive = true,
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Lina123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new ApplicationUser
                {
                    Id = "id-ghada-alsubaie",
                    UserType = UserType.Freelancer,
                    FirstName = "Ghada",
                    LastName = "AlSubaie",
                    DateRegistered = DateTime.UtcNow.Date.AddDays(-27),
                    PhotoPath = "https://freelanceme.blob.core.windows.net/container1/f12",
                    Email = "ghada@pingafreelancer.com",
                    UserName = "ghada@pingafreelancer.com",
                    NormalizedUserName = "GHADA@PINGAFREELANCER.COM",
                    NormalizedEmail = "GHADA@PINGAFREELANCER.COM",
                    PhoneNumber = "+966539012345",
                    Latitude = 25.3841,
                    Longitude = 49.5876,
                    IsActive = true,
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Ghada123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new ApplicationUser
                {
                    Id = "id-asma-alsaif",
                    UserType = UserType.Freelancer,
                    FirstName = "Asma",
                    LastName = "AlSaif",
                    DateRegistered = DateTime.UtcNow.Date.AddDays(-28),
                    PhotoPath = "https://freelanceme.blob.core.windows.net/container1/f13",
                    Email = "asma@pingafreelancer.com",
                    UserName = "asma@pingafreelancer.com",
                    NormalizedUserName = "ASMA@PINGAFREELANCER.COM",
                    NormalizedEmail = "ASMA@PINGAFREELANCER.COM",
                    PhoneNumber = "+966540123456",
                    Latitude = 27.5236,
                    Longitude = 41.6954,
                    IsActive = true,
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Asma123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new ApplicationUser
                {
                    Id = "id-raneem-alrashid",
                    UserType = UserType.Freelancer,
                    FirstName = "Raneem",
                    LastName = "AlRashid",
                    DateRegistered = DateTime.UtcNow.Date.AddDays(-29),
                    PhotoPath = "https://freelanceme.blob.core.windows.net/container1/f14",
                    Email = "raneem@pingafreelancer.com",
                    UserName = "raneem@pingafreelancer.com",
                    NormalizedUserName = "RANEEM@PINGAFREELANCER.COM",
                    NormalizedEmail = "RANEEM@PINGAFREELANCER.COM",
                    PhoneNumber = "+966541234567",
                    Latitude = 17.4933,
                    Longitude = 44.1290,
                    IsActive = true,
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Raneem123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new ApplicationUser
                {
                    Id = "id-maysa-aldakhil",
                    UserType = UserType.Freelancer,
                    FirstName = "Maysa",
                    LastName = "AlDakhil",
                    DateRegistered = DateTime.UtcNow.Date.AddDays(-30),
                    PhotoPath = "https://freelanceme.blob.core.windows.net/container1/f15",
                    Email = "maysa@pingafreelancer.com",
                    UserName = "maysa@pingafreelancer.com",
                    NormalizedUserName = "MAYSA@PINGAFREELANCER.COM",
                    NormalizedEmail = "MAYSA@PINGAFREELANCER.COM",
                    PhoneNumber = "+966542345678",
                    Latitude = 24.5247,
                    Longitude = 39.5692,
                    IsActive = true,
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Maysa123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                }
            );

            modelBuilder.Entity<ClientUser>().HasData(
                new ClientUser
                {
                    Id = "id-kanaan-abukhadra",
                    TotalHires = 0
                }
            );

            modelBuilder.Entity<FreelancerUser>().HasData(
                new FreelancerUser
                {
                    Id = "id-raneem-alrashid",
                    DomainId = 7,
                    MainExpertiseId = 41,
                    HourlyRate = 85,
                    Rating = 4.7,
                    FulfilledContracts = 20,
                    HoursBilled = 400
                },
                new FreelancerUser
                {
                    Id = "id-maysa-aldakhil",
                    DomainId = 7,
                    MainExpertiseId = 42,
                    HourlyRate = 90,
                    Rating = 4.8,
                    FulfilledContracts = 24,
                    HoursBilled = 480
                },
                new FreelancerUser
                {
                    Id = "id-abdullah-alsaud",
                    DomainId = 1,
                    MainExpertiseId = 1,
                    HourlyRate = 75,
                    Rating = 4.8,
                    FulfilledContracts = 20,
                    HoursBilled = 400
                },
                new FreelancerUser
                {
                    Id = "id-mohammed-alghamdi",
                    DomainId = 1,
                    MainExpertiseId = 2,
                    HourlyRate = 80,
                    Rating = 4.7,
                    FulfilledContracts = 18,
                    HoursBilled = 360
                },
                new FreelancerUser
                {
                    Id = "id-ahmed-alshehri",
                    DomainId = 1,
                    MainExpertiseId = 3,
                    HourlyRate = 70,
                    Rating = 4.6,
                    FulfilledContracts = 15,
                    HoursBilled = 300
                },
                new FreelancerUser
                {
                    Id = "id-khalid-alqahtani",
                    DomainId = 1,
                    MainExpertiseId = 4,
                    HourlyRate = 85,
                    Rating = 4.9,
                    FulfilledContracts = 22,
                    HoursBilled = 440
                },
                new FreelancerUser
                {
                    Id = "id-omar-aldosari",
                    DomainId = 1,
                    MainExpertiseId = 5,
                    HourlyRate = 90,
                    Rating = 4.8,
                    FulfilledContracts = 25,
                    HoursBilled = 500
                },
                new FreelancerUser
                {
                    Id = "id-saad-alharbi",
                    DomainId = 1,
                    MainExpertiseId = 6,
                    HourlyRate = 65,
                    Rating = 4.5,
                    FulfilledContracts = 12,
                    HoursBilled = 240
                },
                new FreelancerUser
                {
                    Id = "id-faisal-alotaibi",
                    DomainId = 1,
                    MainExpertiseId = 8,
                    HourlyRate = 95,
                    Rating = 4.9,
                    FulfilledContracts = 28,
                    HoursBilled = 560
                },
                new FreelancerUser
                {
                    Id = "id-majid-alahmadi",
                    DomainId = 2,
                    MainExpertiseId = 14,
                    HourlyRate = 75,
                    Rating = 4.7,
                    FulfilledContracts = 16,
                    HoursBilled = 320
                },
                new FreelancerUser
                {
                    Id = "id-turki-alsultan",
                    DomainId = 2,
                    MainExpertiseId = 16,
                    HourlyRate = 100,
                    Rating = 5.0,
                    FulfilledContracts = 30,
                    HoursBilled = 600
                },
                new FreelancerUser
                {
                    Id = "id-fahad-almalki",
                    DomainId = 2,
                    MainExpertiseId = 18,
                    HourlyRate = 70,
                    Rating = 4.6,
                    FulfilledContracts = 14,
                    HoursBilled = 280
                },
                new FreelancerUser
                {
                    Id = "id-hassan-alzahrani",
                    DomainId = 2,
                    MainExpertiseId = 19,
                    HourlyRate = 85,
                    Rating = 4.8,
                    FulfilledContracts = 22,
                    HoursBilled = 440
                },
                new FreelancerUser
                {
                    Id = "id-nasser-alyami",
                    DomainId = 3,
                    MainExpertiseId = 20,
                    HourlyRate = 90,
                    Rating = 4.9,
                    FulfilledContracts = 26,
                    HoursBilled = 520
                },
                new FreelancerUser
                {
                    Id = "id-sami-alomairi",
                    DomainId = 3,
                    MainExpertiseId = 22,
                    HourlyRate = 75,
                    Rating = 4.7,
                    FulfilledContracts = 18,
                    HoursBilled = 360
                },
                new FreelancerUser
                {
                    Id = "id-yasser-alsubaie",
                    DomainId = 3,
                    MainExpertiseId = 23,
                    HourlyRate = 80,
                    Rating = 4.8,
                    FulfilledContracts = 20,
                    HoursBilled = 400
                },
                new FreelancerUser
                {
                    Id = "id-waleed-alsaif",
                    DomainId = 4,
                    MainExpertiseId = 26,
                    HourlyRate = 95,
                    Rating = 4.9,
                    FulfilledContracts = 28,
                    HoursBilled = 560
                },
                new FreelancerUser
                {
                    Id = "id-abdulaziz-alrashid",
                    DomainId = 4,
                    MainExpertiseId = 27,
                    HourlyRate = 85,
                    Rating = 4.7,
                    FulfilledContracts = 22,
                    HoursBilled = 440
                },
                new FreelancerUser
                {
                    Id = "id-bandar-aldakhil",
                    DomainId = 4,
                    MainExpertiseId = 28,
                    HourlyRate = 90,
                    Rating = 4.8,
                    FulfilledContracts = 24,
                    HoursBilled = 480
                },
                new FreelancerUser
                {
                    Id = "id-meshal-alfahad",
                    DomainId = 4,
                    MainExpertiseId = 30,
                    HourlyRate = 100,
                    Rating = 5.0,
                    FulfilledContracts = 30,
                    HoursBilled = 600
                },
                new FreelancerUser
                {
                    Id = "id-john-smith",
                    DomainId = 5,
                    MainExpertiseId = 32,
                    HourlyRate = 95,
                    Rating = 4.9,
                    FulfilledContracts = 28,
                    HoursBilled = 560
                },
                new FreelancerUser
                {
                    Id = "id-michael-johnson",
                    DomainId = 5,
                    MainExpertiseId = 33,
                    HourlyRate = 85,
                    Rating = 4.7,
                    FulfilledContracts = 22,
                    HoursBilled = 440
                },
                new FreelancerUser
                {
                    Id = "id-david-brown",
                    DomainId = 5,
                    MainExpertiseId = 34,
                    HourlyRate = 90,
                    Rating = 4.8,
                    FulfilledContracts = 24,
                    HoursBilled = 480
                },
                new FreelancerUser
                {
                    Id = "id-christopher-davis",
                    DomainId = 5,
                    MainExpertiseId = 35,
                    HourlyRate = 80,
                    Rating = 4.6,
                    FulfilledContracts = 18,
                    HoursBilled = 360
                },
                new FreelancerUser
                {
                    Id = "id-matthew-wilson",
                    DomainId = 5,
                    MainExpertiseId = 36,
                    HourlyRate = 95,
                    Rating = 4.9,
                    FulfilledContracts = 28,
                    HoursBilled = 560
                },
                new FreelancerUser
                {
                    Id = "id-daniel-taylor",
                    DomainId = 6,
                    MainExpertiseId = 37,
                    HourlyRate = 75,
                    Rating = 4.5,
                    FulfilledContracts = 15,
                    HoursBilled = 300
                },
                new FreelancerUser
                {
                    Id = "id-andrew-anderson",
                    DomainId = 6,
                    MainExpertiseId = 38,
                    HourlyRate = 85,
                    Rating = 4.7,
                    FulfilledContracts = 20,
                    HoursBilled = 400
                },
                new FreelancerUser
                {
                    Id = "id-joseph-thomas",
                    DomainId = 6,
                    MainExpertiseId = 39,
                    HourlyRate = 90,
                    Rating = 4.8,
                    FulfilledContracts = 24,
                    HoursBilled = 480
                },
                new FreelancerUser
                {
                    Id = "id-william-jackson",
                    DomainId = 7,
                    MainExpertiseId = 40,
                    HourlyRate = 100,
                    Rating = 5.0,
                    FulfilledContracts = 30,
                    HoursBilled = 600
                },
                new FreelancerUser
                {
                    Id = "id-fatima-alotaibi",
                    DomainId = 1,
                    MainExpertiseId = 7,
                    HourlyRate = 85,
                    Rating = 4.7,
                    FulfilledContracts = 20,
                    HoursBilled = 400
                },
                new FreelancerUser
                {
                    Id = "id-aisha-alqahtani",
                    DomainId = 2,
                    MainExpertiseId = 9,
                    HourlyRate = 90,
                    Rating = 4.8,
                    FulfilledContracts = 24,
                    HoursBilled = 480
                },
                new FreelancerUser
                {
                    Id = "id-noura-alshehri",
                    DomainId = 2,
                    MainExpertiseId = 10,
                    HourlyRate = 80,
                    Rating = 4.6,
                    FulfilledContracts = 18,
                    HoursBilled = 360
                },
                new FreelancerUser
                {
                    Id = "id-maryam-alghamdi",
                    DomainId = 2,
                    MainExpertiseId = 11,
                    HourlyRate = 95,
                    Rating = 4.9,
                    FulfilledContracts = 28,
                    HoursBilled = 560
                },
                new FreelancerUser
                {
                    Id = "id-layla-aldosari",
                    DomainId = 2,
                    MainExpertiseId = 12,
                    HourlyRate = 75,
                    Rating = 4.5,
                    FulfilledContracts = 15,
                    HoursBilled = 300
                },
                new FreelancerUser
                {
                    Id = "id-amira-alharbi",
                    DomainId = 2,
                    MainExpertiseId = 13,
                    HourlyRate = 85,
                    Rating = 4.7,
                    FulfilledContracts = 20,
                    HoursBilled = 400
                },
                new FreelancerUser
                {
                    Id = "id-noor-alsultan",
                    DomainId = 2,
                    MainExpertiseId = 15,
                    HourlyRate = 90,
                    Rating = 4.8,
                    FulfilledContracts = 24,
                    HoursBilled = 480
                },
                new FreelancerUser
                {
                    Id = "id-reem-almalki",
                    DomainId = 2,
                    MainExpertiseId = 17,
                    HourlyRate = 100,
                    Rating = 5.0,
                    FulfilledContracts = 30,
                    HoursBilled = 600
                },
                new FreelancerUser
                {
                    Id = "id-hana-alzahrani",
                    DomainId = 3,
                    MainExpertiseId = 21,
                    HourlyRate = 85,
                    Rating = 4.7,
                    FulfilledContracts = 20,
                    HoursBilled = 400
                },
                new FreelancerUser
                {
                    Id = "id-sara-alyami",
                    DomainId = 3,
                    MainExpertiseId = 24,
                    HourlyRate = 90,
                    Rating = 4.8,
                    FulfilledContracts = 24,
                    HoursBilled = 480
                },
                new FreelancerUser
                {
                    Id = "id-lina-alomairi",
                    DomainId = 3,
                    MainExpertiseId = 25,
                    HourlyRate = 80,
                    Rating = 4.6,
                    FulfilledContracts = 18,
                    HoursBilled = 360
                },
                new FreelancerUser
                {
                    Id = "id-ghada-alsubaie",
                    DomainId = 4,
                    MainExpertiseId = 29,
                    HourlyRate = 95,
                    Rating = 4.9,
                    FulfilledContracts = 28,
                    HoursBilled = 560
                },
                new FreelancerUser
                {
                    Id = "id-asma-alsaif",
                    DomainId = 4,
                    MainExpertiseId = 31,
                    HourlyRate = 75,
                    Rating = 4.5,
                    FulfilledContracts = 15,
                    HoursBilled = 300
                }
            );
        }
    }
}

        
        

        
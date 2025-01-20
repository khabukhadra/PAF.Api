using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FMA.Application.Migrations
{
    /// <inheritdoc />
    public partial class Initial24 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    DateRegistered = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Domains",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DomainName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BorderColor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domains", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TotalHires = table.Column<int>(type: "int", nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expertises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DomainId = table.Column<int>(type: "int", nullable: false),
                    ExpertiseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BorderColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expertises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expertises_Domains_DomainId",
                        column: x => x.DomainId,
                        principalTable: "Domains",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Freelancers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DomainId = table.Column<int>(type: "int", nullable: false),
                    MainExpertiseId = table.Column<int>(type: "int", nullable: false),
                    HourlyRate = table.Column<double>(type: "float", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    FulfilledContracts = table.Column<int>(type: "int", nullable: false),
                    HoursBilled = table.Column<int>(type: "int", nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Freelancers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Freelancers_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Freelancers_Domains_DomainId",
                        column: x => x.DomainId,
                        principalTable: "Domains",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Freelancers_Expertises_MainExpertiseId",
                        column: x => x.MainExpertiseId,
                        principalTable: "Expertises",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FreelancerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateStarted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCompleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    HoursContracted = table.Column<int>(type: "int", nullable: false),
                    AmountPaid = table.Column<int>(type: "int", nullable: false),
                    ClientEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreelancerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contracts_Freelancers_FreelancerId",
                        column: x => x.FreelancerId,
                        principalTable: "Freelancers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FreelancerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DatePinged = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreelancerUserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pings_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pings_Freelancers_FreelancerId",
                        column: x => x.FreelancerId,
                        principalTable: "Freelancers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateRegistered", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "Latitude", "LockoutEnabled", "LockoutEnd", "Longitude", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhotoPath", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserType" },
                values: new object[,]
                {
                    { "id-abdulaziz-alrashid", 0, "d967f390-9e6e-4fd5-9ee1-54676aa0ca69", new DateTime(2024, 11, 23, 0, 0, 0, 0, DateTimeKind.Utc), "abdulaziz@pingafreelancer.com", true, "Abdulaziz", true, "AlRashid", 27.523599999999998, true, null, 41.695399999999999, "ABDULAZIZ@PINGAFREELANCER.COM", "ABDULAZIZ@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEE4U3g8fJMwZS5DefJtjwMasHg0N8G6OZWuvoBTI16kjBgFUxh49XU1Y8rztW0ryPg==", "+966516789012", false, "https://freelanceme.blob.core.windows.net/container1/a16", "dc028a40-2c6b-4f63-9e61-1edb0e2055fa", false, "abdulaziz@pingafreelancer.com", 0 },
                    { "id-abdullah-alsaud", 0, "628d27dd-9731-4262-96b3-8f80dc821b37", new DateTime(2024, 9, 28, 0, 0, 0, 0, DateTimeKind.Utc), "abdullah@pingafreelancer.com", true, "Abdullah", true, "AlSaud", 24.7136, true, null, 46.6753, "ABDULLAH@PINGAFREELANCER.COM", "ABDULLAH@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEDregud2cXtUe5RQdtSU76TZxB211OpG1yOMdQ8GGI5j+jTO9+N5Lc1CqpFU2NBfyg==", "+966501234567", false, "https://freelanceme.blob.core.windows.net/container1/a1", "fb487771-07ce-4a48-aefc-1d450a1b74fd", false, "abdullah@pingafreelancer.com", 0 },
                    { "id-ahmed-alshehri", 0, "d21fd8c2-9220-4abb-b1b4-726a54b72d13", new DateTime(2024, 10, 8, 0, 0, 0, 0, DateTimeKind.Utc), "ahmed@pingafreelancer.com", true, "Ahmed", true, "AlShehri", 26.2361, true, null, 50.039299999999997, "AHMED@PINGAFREELANCER.COM", "AHMED@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEMp9ESu245piBo0HCCcHuMu17gBzA5N9A3GypNO62j0WWJAKGbqufSA9NIJ02Zpdpw==", "+966503456789", false, "https://freelanceme.blob.core.windows.net/container1/a3", "7ff6ab26-d1a5-446f-8b0f-406809d431e5", false, "ahmed@pingafreelancer.com", 0 },
                    { "id-aisha-alqahtani", 0, "595ec460-7a82-4966-b48d-4c413ddae12c", new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Utc), "aisha@pingafreelancer.com", true, "Aisha", true, "AlQahtani", 28.399799999999999, true, null, 36.571399999999997, "AISHA@PINGAFREELANCER.COM", "AISHA@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAECVj7JfYqq/hN2yqv2DIjv/zA3KvhB+7rHdvx0MrpcqRXbAW87x+dzkaA8pZJq8uVg==", "+966529012345", false, "https://freelanceme.blob.core.windows.net/container1/f2", "2bc90fdf-35ab-40cb-8058-243ecc994d2a", false, "aisha@pingafreelancer.com", 0 },
                    { "id-amira-alharbi", 0, "75a2e640-a2bd-4db0-a0bd-a01d608a1079", new DateTime(2024, 11, 6, 0, 0, 0, 0, DateTimeKind.Utc), "amira@pingafreelancer.com", true, "Amira", true, "AlHarbi", 26.2361, true, null, 50.039299999999997, "AMIRA@PINGAFREELANCER.COM", "AMIRA@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAECJ9eyS8d3znCa5RrWtIQb3Uydeu074BkJpBi0XxHmrUuNoH/CqB2L9UYkECTZ/YIw==", "+966533456789", false, "https://freelanceme.blob.core.windows.net/container1/f6", "2a856f55-de3e-42ea-9508-7a5dea5bc2d1", false, "amira@pingafreelancer.com", 0 },
                    { "id-andrew-anderson", 0, "f48fa159-2c31-4ce1-ab50-2df72792e11a", new DateTime(2024, 11, 14, 0, 0, 0, 0, DateTimeKind.Utc), "andrew@pingafreelancer.com", true, "Andrew", true, "Anderson", 27.523599999999998, true, null, 41.695399999999999, "ANDREW@PINGAFREELANCER.COM", "ANDREW@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEMrAmT6b3yNsqTdXhybHAuPAup+DvlT1N7Sja9UyZ6lS5vEQv8VmwP3/j1TDrwAhvg==", "+966525678901", false, "https://freelanceme.blob.core.windows.net/container1/n7", "2a401022-8115-494d-a49d-8e42edef0b56", false, "andrew@pingafreelancer.com", 0 },
                    { "id-asma-alsaif", 0, "12083525-3917-4e72-b876-4fa36660eb44", new DateTime(2024, 10, 30, 0, 0, 0, 0, DateTimeKind.Utc), "asma@pingafreelancer.com", true, "Asma", true, "AlSaif", 27.523599999999998, true, null, 41.695399999999999, "ASMA@PINGAFREELANCER.COM", "ASMA@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEJtPiW9LREd0ni667LCBTUqW3FBoouBDh29qXTIj14sr45zzF2nnLgkZAuHy16bNDA==", "+966540123456", false, "https://freelanceme.blob.core.windows.net/container1/f13", "9893051d-ccd2-41e9-8105-aa1c361a9d6a", false, "asma@pingafreelancer.com", 0 },
                    { "id-bandar-aldakhil", 0, "4f6e0f86-7a77-4315-8d30-44082d2f203e", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), "bandar@pingafreelancer.com", true, "Bandar", true, "AlDakhil", 21.485800000000001, true, null, 39.192500000000003, "BANDAR@PINGAFREELANCER.COM", "BANDAR@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEMqtUIPHy0YtrYwRFD1VDFd/GFfDRFm/+IrykPVOsquR5ot45bMmT6cZk2IhlZd19Q==", "+966517890123", false, "https://freelanceme.blob.core.windows.net/container1/a17", "5faf5d0f-7cb0-428e-808b-b97603ab5cbe", false, "bandar@pingafreelancer.com", 0 },
                    { "id-christopher-davis", 0, "7313ab2a-3b9c-4881-bf93-597298215765", new DateTime(2024, 11, 17, 0, 0, 0, 0, DateTimeKind.Utc), "christopher@pingafreelancer.com", true, "Christopher", true, "Davis", 26.085100000000001, true, null, 43.973100000000002, "CHRISTOPHER@PINGAFREELANCER.COM", "CHRISTOPHER@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEEoEicLbs21lgtHwU890+KE2EYOYSi2UqOZ1JetdwxpGM3YwUdAoywXxIdm680niGw==", "+966522345678", false, "https://freelanceme.blob.core.windows.net/container1/n4", "d643397f-c696-440b-900c-14183605aac8", false, "christopher@pingafreelancer.com", 0 },
                    { "id-daniel-taylor", 0, "e5678be1-037b-4c5b-8990-c2917b6152d6", new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Utc), "daniel@pingafreelancer.com", true, "Daniel", true, "Taylor", 25.3841, true, null, 49.587600000000002, "DANIEL@PINGAFREELANCER.COM", "DANIEL@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAELcn0xlqnbm0p1jdYbF6i4s2vVPyQ/fLsJfR2X/JjAyununzT3IIRZp8ZTwIEIVq2A==", "+966524567890", false, "https://freelanceme.blob.core.windows.net/container1/n6", "b8a2a697-4c87-4505-90f2-35295e7582f1", false, "daniel@pingafreelancer.com", 0 },
                    { "id-david-brown", 0, "8d8d00e7-09e1-4e76-83fc-93b3cc5da3dd", new DateTime(2024, 11, 18, 0, 0, 0, 0, DateTimeKind.Utc), "david@pingafreelancer.com", true, "David", true, "Brown", 21.270700000000001, true, null, 40.416699999999999, "DAVID@PINGAFREELANCER.COM", "DAVID@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEB5KaMhcfWlkTTYFat+N9dnppT4gmKKI5Q2af+4si30yaVI19/xLiB3S+DLn3h8NyQ==", "+966521234567", false, "https://freelanceme.blob.core.windows.net/container1/n3", "e9859744-8364-4f5e-9adb-1a88fbd90b9d", false, "david@pingafreelancer.com", 0 },
                    { "id-fahad-almalki", 0, "7c7dcb0d-45f0-4526-b436-ac3078bd80b4", new DateTime(2024, 11, 12, 0, 0, 0, 0, DateTimeKind.Utc), "fahad@pingafreelancer.com", true, "Fahad", true, "AlMalki", 27.523599999999998, true, null, 41.695399999999999, "FAHAD@PINGAFREELANCER.COM", "FAHAD@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAENnIVkf+ldLCYWNSVw2um1IJhaOT7EEBdAhURKUqWqKekXgak8i4GaDBSW2EOBTP3A==", "+966510123456", false, "https://freelanceme.blob.core.windows.net/container1/a10", "02dab3c2-7c05-46b1-bb14-79d5dd2e154c", false, "fahad@pingafreelancer.com", 0 },
                    { "id-faisal-alotaibi", 0, "ec72e198-35d3-452c-bd4c-8c93c90b39bb", new DateTime(2024, 10, 28, 0, 0, 0, 0, DateTimeKind.Utc), "faisal@pingafreelancer.com", true, "Faisal", true, "AlOtaibi", 26.085100000000001, true, null, 43.973100000000002, "FAISAL@PINGAFREELANCER.COM", "FAISAL@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEGfcgIRqJ/zbY8MLu2pLBBVvE9wk5hdixctretqI+561uX7TSmTcFdU6/cLPDIRrUQ==", "+966507890123", false, "https://freelanceme.blob.core.windows.net/container1/a7", "2bdf134e-cc7a-45db-986a-4eb690107a0f", false, "faisal@pingafreelancer.com", 0 },
                    { "id-fatima-alotaibi", 0, "233846cb-b4c5-49aa-bf83-5f4c78903da0", new DateTime(2024, 11, 11, 0, 0, 0, 0, DateTimeKind.Utc), "fatima@pingafreelancer.com", true, "Fatima", true, "AlOtaibi", 30.098400000000002, true, null, 40.285400000000003, "FATIMA@PINGAFREELANCER.COM", "FATIMA@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAELntshBjP2zj/tHtMgFPvQiCAsoRCl7rJiAQ2qPVwX8LsOr7Id67dnIbJaYLCoxuSw==", "+966528901234", false, "https://freelanceme.blob.core.windows.net/container1/f1", "32051dc9-b33c-4af5-8ea2-e3958b7a20a4", false, "fatima@pingafreelancer.com", 0 },
                    { "id-ghada-alsubaie", 0, "6bcaf8a7-0a6d-4ec9-bc2d-7698fb3a3b34", new DateTime(2024, 10, 31, 0, 0, 0, 0, DateTimeKind.Utc), "ghada@pingafreelancer.com", true, "Ghada", true, "AlSubaie", 25.3841, true, null, 49.587600000000002, "GHADA@PINGAFREELANCER.COM", "GHADA@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEIkBwvlDoyTgCV+THnoAd5z3kbv0n8HAay1ml837XN2Bu5VYYXuT6JvRPa8GdqIvnw==", "+966539012345", false, "https://freelanceme.blob.core.windows.net/container1/f12", "a0d188e7-79e7-4bd6-9903-1e2699fc1ff1", false, "ghada@pingafreelancer.com", 0 },
                    { "id-hana-alzahrani", 0, "63940290-7429-4d3c-8c25-3b40382e2a1f", new DateTime(2024, 11, 3, 0, 0, 0, 0, DateTimeKind.Utc), "hana@pingafreelancer.com", true, "Hana", true, "AlZahrani", 21.270700000000001, true, null, 40.416699999999999, "HANA@PINGAFREELANCER.COM", "HANA@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEBwc1X+2cCh3wsFp5ENUt/hd2vsWiwcyxdl/d2H6LWY6bz6xw0Yq4bfvqxB9QR8AsA==", "+966536789012", false, "https://freelanceme.blob.core.windows.net/container1/f9", "ca08828b-2077-4611-85ce-8b04cb9298e3", false, "hana@pingafreelancer.com", 0 },
                    { "id-hassan-alzahrani", 0, "d5201965-2101-4bd3-b73a-f71f34b73971", new DateTime(2024, 11, 17, 0, 0, 0, 0, DateTimeKind.Utc), "hassan@pingafreelancer.com", true, "Hassan", true, "AlZahrani", 17.493300000000001, true, null, 44.128999999999998, "HASSAN@PINGAFREELANCER.COM", "HASSAN@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEBn6FNAvBox12b7cBKcZAj3QeCRMq2+fudh7iicuDZX+JrxB7ez8y4Wg2krT/QczRw==", "+966511234567", false, "https://freelanceme.blob.core.windows.net/container1/a11", "bc25e53c-0560-42bd-b639-3ee157f55b5b", false, "hassan@pingafreelancer.com", 0 },
                    { "id-john-smith", 0, "dbcb2405-2d58-414b-a9ae-c43ea2fde0df", new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Utc), "john@pingafreelancer.com", true, "John", true, "Smith", 24.466699999999999, true, null, 39.600000000000001, "JOHN@PINGAFREELANCER.COM", "JOHN@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEDgc23aFq6HnchiXK8BZYAJ9i/OcjIsxwCj5yo+mgTZ+WGbj8mFxatM/zZ200sHcAw==", "+966519012345", false, "https://freelanceme.blob.core.windows.net/container1/n1", "7005aa14-06af-4c90-af65-f8491cbc555e", false, "john@pingafreelancer.com", 0 },
                    { "id-joseph-thomas", 0, "cd7f1ff0-d38b-4519-8e18-c79c941192f8", new DateTime(2024, 11, 13, 0, 0, 0, 0, DateTimeKind.Utc), "joseph@pingafreelancer.com", true, "Joseph", true, "Thomas", 17.493300000000001, true, null, 44.128999999999998, "JOSEPH@PINGAFREELANCER.COM", "JOSEPH@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEKlVgNooPhTRYdKLjJ64XxT7J7rhG7O2Fw/A7iqP2dZs/t3GvsQCHY6f817UtYAL1Q==", "+966526789012", false, "https://freelanceme.blob.core.windows.net/container1/n8", "a7459e66-6d61-453e-b19d-2a51ca2bb0bf", false, "joseph@pingafreelancer.com", 0 },
                    { "id-kanaan-abukhadra", 0, "3da47b8a-4c55-482b-8bf0-1ed859f55c73", new DateTime(2024, 11, 27, 15, 11, 1, 332, DateTimeKind.Utc).AddTicks(9200), "kanaanabukhadra@gmail.com", true, "Kanaan", true, "Abukhadra", 26.329999999999998, true, null, 50.130000000000003, "KANAANABUKHADRA@GMAIL.COM", "KANAANABUKHADRA@GMAIL.COM", "AQAAAAIAAYagAAAAEKmQPzKIqH9U45aCslTyHIjAkiT26GobHmo2HXflYbvOvj8lS/6/ZqDD0MtOVFz8cw==", "+966503725354", false, "https://freelanceme.blob.core.windows.net/container1/kanaan", "77447fe6-0258-4ae3-a4e2-bad1ba4f38e8", false, "kanaanabukhadra@gmail.com", 1 },
                    { "id-khalid-alqahtani", 0, "a819efa4-4261-4eaf-8040-f3fa4e61cb03", new DateTime(2024, 10, 13, 0, 0, 0, 0, DateTimeKind.Utc), "khalid@pingafreelancer.com", true, "Khalid", true, "AlQahtani", 24.466699999999999, true, null, 39.600000000000001, "KHALID@PINGAFREELANCER.COM", "KHALID@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEMWof1Sq1hI24cN5kCSSwhwy7rDfKFS+JdhXdPGfpi68AwgYrj9WyNI2cZVCpJem4w==", "+966504567890", false, "https://freelanceme.blob.core.windows.net/container1/a4", "167c4977-5ea2-4521-b474-5e829144ec11", false, "khalid@pingafreelancer.com", 0 },
                    { "id-layla-aldosari", 0, "41095dbe-fc44-48d8-b864-bc2762d34594", new DateTime(2024, 11, 7, 0, 0, 0, 0, DateTimeKind.Utc), "layla@pingafreelancer.com", true, "Layla", true, "AlDosari", 21.485800000000001, true, null, 39.192500000000003, "LAYLA@PINGAFREELANCER.COM", "LAYLA@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEHjOIpO7HaX0rBjZeFkytwMs2YlfCiP5rqwo6536E23srDYCGLJDEgbFhOGs2n8b6A==", "+966532345678", false, "https://freelanceme.blob.core.windows.net/container1/f5", "4f770472-e6e8-4812-a535-6cb33633a937", false, "layla@pingafreelancer.com", 0 },
                    { "id-lina-alomairi", 0, "28182837-f6ce-49a4-b8b2-6ebee9432135", new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), "lina@pingafreelancer.com", true, "Lina", true, "AlOmairi", 18.2164, true, null, 42.505299999999998, "LINA@PINGAFREELANCER.COM", "LINA@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEGT1ufb1C2/SNSCjzdgs6a9YL3HKcW2L0769EchGnB+AXgNmydU8HqM0i/nbVwUcSg==", "+966538901234", false, "https://freelanceme.blob.core.windows.net/container1/f11", "e10a98a7-9021-46ae-98a2-db9832e9ad46", false, "lina@pingafreelancer.com", 0 },
                    { "id-majid-alahmadi", 0, "89a81239-704c-4354-8ac1-f4d101bb7051", new DateTime(2024, 11, 2, 0, 0, 0, 0, DateTimeKind.Utc), "majid@pingafreelancer.com", true, "Majid", true, "AlAhmadi", 18.2164, true, null, 42.505299999999998, "MAJID@PINGAFREELANCER.COM", "MAJID@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEPK9SkRNj/P7dBdeX8O7pu+AjxfKd6ZHns4a9x6JR4S3ENWl+mSHEbZcxt8YSZsYiA==", "+966508901234", false, "https://freelanceme.blob.core.windows.net/container1/a8", "664821ca-8836-4770-9a55-9a25dd503bfd", false, "majid@pingafreelancer.com", 0 },
                    { "id-maryam-alghamdi", 0, "5b4d466e-26be-44fe-834f-49d598417755", new DateTime(2024, 11, 8, 0, 0, 0, 0, DateTimeKind.Utc), "maryam@pingafreelancer.com", true, "Maryam", true, "AlGhamdi", 27.523599999999998, true, null, 41.695399999999999, "MARYAM@PINGAFREELANCER.COM", "MARYAM@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEAt2oFLD30ES+P7wigIYMaZsW/UplRsv6416kicwumRCoPLtYxpQXiQjpgeLAqth0g==", "+966531234567", false, "https://freelanceme.blob.core.windows.net/container1/f4", "ea4db40d-7997-4b15-8d2b-791d58d1aac2", false, "maryam@pingafreelancer.com", 0 },
                    { "id-matthew-wilson", 0, "60dce398-a64a-4676-a4f4-429790594cea", new DateTime(2024, 11, 16, 0, 0, 0, 0, DateTimeKind.Utc), "matthew@pingafreelancer.com", true, "Matthew", true, "Wilson", 18.2164, true, null, 42.505299999999998, "MATTHEW@PINGAFREELANCER.COM", "MATTHEW@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEEUMeyfl+mf9Hm7+SBd2PK2WIn3hyOqA98eTzuiIZygbgaVaH9P8O3A53u136deFiQ==", "+966523456789", false, "https://freelanceme.blob.core.windows.net/container1/n5", "a1180451-2b75-4538-b2f7-228a0c563482", false, "matthew@pingafreelancer.com", 0 },
                    { "id-maysa-aldakhil", 0, "68d0148f-60ca-48f1-8121-0e5bd363f391", new DateTime(2024, 10, 28, 0, 0, 0, 0, DateTimeKind.Utc), "maysa@pingafreelancer.com", true, "Maysa", true, "AlDakhil", 24.524699999999999, true, null, 39.569200000000002, "MAYSA@PINGAFREELANCER.COM", "MAYSA@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEP96fJ4VDt15Ot4b4cTn7vUBJlh0anCykF5L473BEMABKsPVFGArRGsFq1XNHj8XCQ==", "+966542345678", false, "https://freelanceme.blob.core.windows.net/container1/f15", "2eb9c870-aa3d-44cb-bbf4-4f8cea391654", false, "maysa@pingafreelancer.com", 0 },
                    { "id-meshal-alfahad", 0, "7d55a13a-9d07-4b6b-b413-7cf9d2c4e59a", new DateTime(2024, 11, 21, 0, 0, 0, 0, DateTimeKind.Utc), "meshal@pingafreelancer.com", true, "Meshal", true, "AlFahad", 26.2361, true, null, 50.039299999999997, "MESHAL@PINGAFREELANCER.COM", "MESHAL@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEAel/uVIz4I7F2lS+c55PvEnlGpVhNQINpgn3ogoC2YaSZFgYSTFw6L7UjiQAU1e6w==", "+966518901234", false, "https://freelanceme.blob.core.windows.net/container1/a18", "692d4300-12c0-47d1-86f7-19c382507d59", false, "meshal@pingafreelancer.com", 0 },
                    { "id-michael-johnson", 0, "afb2e893-6ece-40f9-a9c7-c94acc38089d", new DateTime(2024, 11, 19, 0, 0, 0, 0, DateTimeKind.Utc), "michael@pingafreelancer.com", true, "Michael", true, "Johnson", 26.4207, true, null, 50.088799999999999, "MICHAEL@PINGAFREELANCER.COM", "MICHAEL@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAELJ6+ppNkytl8UOfyZLAkccc/rt4lIUOb+/JyClC6NsTfsMZ0tiIA3dT02OpNZugyw==", "+966520123456", false, "https://freelanceme.blob.core.windows.net/container1/n2", "a594d796-dea3-4971-9425-49648b761d2a", false, "michael@pingafreelancer.com", 0 },
                    { "id-mohammed-alghamdi", 0, "d28c1f53-1a5d-4da8-a985-454e1ba090e6", new DateTime(2024, 10, 3, 0, 0, 0, 0, DateTimeKind.Utc), "mohammed@pingafreelancer.com", true, "Mohammed", true, "AlGhamdi", 21.485800000000001, true, null, 39.192500000000003, "MOHAMMED@PINGAFREELANCER.COM", "MOHAMMED@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEEqhuJFTOFKcAyrBsDROpTUKENUsc8bxa/sMbyYsfpfioSYiHweA8DqcNszTHo5RSw==", "+966502345678", false, "https://freelanceme.blob.core.windows.net/container1/a2", "898de29c-2ea1-4929-8ff1-6f3bfc2ff923", false, "mohammed@pingafreelancer.com", 0 },
                    { "id-nasser-alyami", 0, "ad41a78a-5516-456e-b9da-8a1114888c07", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), "nasser@pingafreelancer.com", true, "Nasser", true, "AlYami", 24.524699999999999, true, null, 39.569200000000002, "NASSER@PINGAFREELANCER.COM", "NASSER@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEHHWJI5atSq809NzBjfGbEJPoGewXzKiaM23cU5+DvBJtlUy9Gq9THqfygfxu4I1vw==", "+966512345678", false, "https://freelanceme.blob.core.windows.net/container1/a12", "04e500c9-f5fc-4d1b-a754-4f0fd325d106", false, "nasser@pingafreelancer.com", 0 },
                    { "id-noor-alsultan", 0, "e1ce53f9-47dd-42ea-9618-adff8cecc3fd", new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Utc), "noor@pingafreelancer.com", true, "Noor", true, "AlSultan", 24.466699999999999, true, null, 39.600000000000001, "NOOR@PINGAFREELANCER.COM", "NOOR@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEO7KtVIk82ho18Tr7QpIFe7dx8dvBYUjc18+ImnR1234BA5iaCmeXQYkwEeyHNEgKA==", "+966534567890", false, "https://freelanceme.blob.core.windows.net/container1/f7", "a677e936-4efd-4b43-a1a0-d11c00e51a55", false, "noor@pingafreelancer.com", 0 },
                    { "id-noura-alshehri", 0, "f862f85c-803c-4341-aa2a-3890992d0a1c", new DateTime(2024, 11, 9, 0, 0, 0, 0, DateTimeKind.Utc), "noura@pingafreelancer.com", true, "Noura", true, "AlShehri", 25.664000000000001, true, null, 42.699599999999997, "NOURA@PINGAFREELANCER.COM", "NOURA@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEPYJJgjyazywtv/x3A0fIFdWPb8ZBNa4irdp7A/RvElsc6bXkrVrckI2zGCaYqrJlQ==", "+966530123456", false, "https://freelanceme.blob.core.windows.net/container1/f3", "6f25d32b-4179-45a5-8dcd-b86461925adf", false, "noura@pingafreelancer.com", 0 },
                    { "id-omar-aldosari", 0, "8346c125-305c-4b5f-beb7-90bdca2da1a7", new DateTime(2024, 10, 18, 0, 0, 0, 0, DateTimeKind.Utc), "omar@pingafreelancer.com", true, "Omar", true, "AlDosari", 26.4207, true, null, 50.088799999999999, "OMAR@PINGAFREELANCER.COM", "OMAR@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEKiZaH/SEWYUuY4QD3aW6kMOnolNM9tUum/cejUTTCYWwmFDdKIb7UzlckD6Z18alw==", "+966505678901", false, "https://freelanceme.blob.core.windows.net/container1/a5", "0566f744-b78e-4a81-aab2-a6f6adaa4199", false, "omar@pingafreelancer.com", 0 },
                    { "id-raneem-alrashid", 0, "99b451b8-780c-45d9-83dc-82ea4669bf48", new DateTime(2024, 10, 29, 0, 0, 0, 0, DateTimeKind.Utc), "raneem@pingafreelancer.com", true, "Raneem", true, "AlRashid", 17.493300000000001, true, null, 44.128999999999998, "RANEEM@PINGAFREELANCER.COM", "RANEEM@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEJDOM8vimntNYevoXcKPAvQsNi/AhUh9SoC3bXiGb+jcjYYJ34G4CmCW68dfmXbgOg==", "+966541234567", false, "https://freelanceme.blob.core.windows.net/container1/f14", "27d9f565-6b2c-4cf3-9cb6-6fe3a22d629f", false, "raneem@pingafreelancer.com", 0 },
                    { "id-reem-almalki", 0, "151b1d80-4249-42fc-8b84-cd63a081467f", new DateTime(2024, 11, 4, 0, 0, 0, 0, DateTimeKind.Utc), "reem@pingafreelancer.com", true, "Reem", true, "AlMalki", 26.4207, true, null, 50.088799999999999, "REEM@PINGAFREELANCER.COM", "REEM@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEH7oWf68a2xyGoIPm3bbQKPovr5LxdFoXD/Bg2VY6yHauLgNsa80P0NoUtJrg0bq+Q==", "+966535678901", false, "https://freelanceme.blob.core.windows.net/container1/f8", "3481c1e6-f908-462b-b78c-551e75d7c229", false, "reem@pingafreelancer.com", 0 },
                    { "id-saad-alharbi", 0, "aacf8d6a-795e-4b55-a0ba-37346865ebbd", new DateTime(2024, 10, 23, 0, 0, 0, 0, DateTimeKind.Utc), "saad@pingafreelancer.com", true, "Saad", true, "AlHarbi", 21.270700000000001, true, null, 40.416699999999999, "SAAD@PINGAFREELANCER.COM", "SAAD@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEGwc1PrmADY6JRso99XA+vR3du+uCf7r6DCzqQhJ5tkjBeVTF3libdcFh69PaB5o7g==", "+966506789012", false, "https://freelanceme.blob.core.windows.net/container1/a6", "76f4cd30-8f54-4daf-ac10-00508015350b", false, "saad@pingafreelancer.com", 0 },
                    { "id-sami-alomairi", 0, "a3e68ed9-55b5-4667-b2ae-8c61a6525f12", new DateTime(2024, 11, 26, 0, 0, 0, 0, DateTimeKind.Utc), "sami@pingafreelancer.com", true, "Sami", true, "AlOmairi", 30.098400000000002, true, null, 40.285400000000003, "SAMI@PINGAFREELANCER.COM", "SAMI@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEFYWyHwioohpJl1Nl2hbvOhlrdebIFmTqsbzNyiMyyVAcTqHhYoO/E3tAjWKH2JsMQ==", "+966513456789", false, "https://freelanceme.blob.core.windows.net/container1/a13", "19ebfd4e-fb4f-40ac-9037-3fef8a992f1c", false, "sami@pingafreelancer.com", 0 },
                    { "id-sara-alyami", 0, "0c9a9154-ba84-4a12-b795-68aa07f7839c", new DateTime(2024, 11, 2, 0, 0, 0, 0, DateTimeKind.Utc), "sara@pingafreelancer.com", true, "Sara", true, "AlYami", 26.085100000000001, true, null, 43.973100000000002, "SARA@PINGAFREELANCER.COM", "SARA@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEHXpUekv0q6BuCcTj8xQ27ZFKxz6IkkjUn97TVBTtx00ZZUMFcM3D/ax1BTFZp9SHw==", "+966537890123", false, "https://freelanceme.blob.core.windows.net/container1/f10", "56eea0e1-f94a-4760-88f0-72e8e4abf9d4", false, "sara@pingafreelancer.com", 0 },
                    { "id-turki-alsultan", 0, "2786f272-fa1c-40c5-87ab-d1414ad627be", new DateTime(2024, 11, 7, 0, 0, 0, 0, DateTimeKind.Utc), "turki@pingafreelancer.com", true, "Turki", true, "AlSultan", 25.3841, true, null, 49.587600000000002, "TURKI@PINGAFREELANCER.COM", "TURKI@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEHvlf46RPLrX7H4MCyiIhlwe/VbK4kG8dFCTRNMqHaYyxIDCwc2Cfv+MB8AP5C8+1Q==", "+966509012345", false, "https://freelanceme.blob.core.windows.net/container1/a9", "a10ebb7c-6e84-413d-95e7-552d83be65db", false, "turki@pingafreelancer.com", 0 },
                    { "id-waleed-alsaif", 0, "5f26d38f-4564-49bb-bb7f-876ecf1adc3a", new DateTime(2024, 11, 24, 0, 0, 0, 0, DateTimeKind.Utc), "waleed@pingafreelancer.com", true, "Waleed", true, "AlSaif", 25.664000000000001, true, null, 42.699599999999997, "WALEED@PINGAFREELANCER.COM", "WALEED@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAELEHaU+NirWPMOYuzMUYkFHjGVIk2+VS3LAtoiF2/YpGHeGn472UBka3OHEGzmp1lg==", "+966515678901", false, "https://freelanceme.blob.core.windows.net/container1/a15", "bde1b9b7-409e-4bcd-9b24-553aad8dc9b5", false, "waleed@pingafreelancer.com", 0 },
                    { "id-william-jackson", 0, "47d31be5-63d3-41ca-a57f-df5d4e663a4e", new DateTime(2024, 11, 12, 0, 0, 0, 0, DateTimeKind.Utc), "william@pingafreelancer.com", true, "William", true, "Jackson", 24.524699999999999, true, null, 39.569200000000002, "WILLIAM@PINGAFREELANCER.COM", "WILLIAM@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEK1wqvtzggNvpu7yE0gDtCvhzL54kZBn5vE0+Lx9xgYcFx14YO0itOHH3s8qj5qKMQ==", "+966527890123", false, "https://freelanceme.blob.core.windows.net/container1/n9", "b0969a6c-2e4f-4384-b604-e7fb8edc51f0", false, "william@pingafreelancer.com", 0 },
                    { "id-yasser-alsubaie", 0, "ab9e6f01-2576-424b-802c-50913079f1fe", new DateTime(2024, 11, 25, 0, 0, 0, 0, DateTimeKind.Utc), "yasser@pingafreelancer.com", true, "Yasser", true, "AlSubaie", 28.399799999999999, true, null, 36.571399999999997, "YASSER@PINGAFREELANCER.COM", "YASSER@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEEUoWQoCMWpFvsvAAmjPrupRAREc5tsmtOSI9PEzi0m1F4w8Pdo4YQZ+6bEZqBvrtg==", "+966514567890", false, "https://freelanceme.blob.core.windows.net/container1/a14", "98afe3d0-8882-4bef-93b0-fdde83b8f177", false, "yasser@pingafreelancer.com", 0 }
                });

            migrationBuilder.InsertData(
                table: "Domains",
                columns: new[] { "Id", "BorderColor", "DomainName", "PhotoPath" },
                values: new object[,]
                {
                    { 1, "#fdf1d3", "Manual Labor", "https://freelanceme.blob.core.windows.net/container1/manual_labor" },
                    { 2, "#f3fee7", "Domestic Services", "https://freelanceme.blob.core.windows.net/container1/domestic_services" },
                    { 3, "#fee7e7", "Health & Wellness ", "https://freelanceme.blob.core.windows.net/container1/health_and_wellness" },
                    { 4, "#e7edfe", "Business Services", "https://freelanceme.blob.core.windows.net/container1/business_services" },
                    { 5, "#ffeab5", "Home Technology", "https://freelanceme.blob.core.windows.net/container1/home_technology" },
                    { 6, "#dcffb5", "Pet Care", "https://freelanceme.blob.core.windows.net/container1/pets" },
                    { 7, "#fdf1d3", "Performing Arts", "https://freelanceme.blob.core.windows.net/container1/performing_arts" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "TotalHires", "UserType" },
                values: new object[] { "id-kanaan-abukhadra", 0, 1 });

            migrationBuilder.InsertData(
                table: "Expertises",
                columns: new[] { "Id", "BorderColor", "DomainId", "ExpertiseName", "PhotoPath" },
                values: new object[,]
                {
                    { 1, "#fdf1d3", 1, "Furniture assembler", "https://freelanceme.blob.core.windows.net/container1/furniture_assembler" },
                    { 2, "#f3fee7", 1, "Chauffeur", "https://freelanceme.blob.core.windows.net/container1/chauffeur" },
                    { 3, "#fee7e7", 1, "Painter", "https://freelanceme.blob.core.windows.net/container1/painter" },
                    { 4, "#e7edfe", 1, "Carpenter", "https://freelanceme.blob.core.windows.net/container1/carpenter" },
                    { 5, "#ffeab5", 1, "Roof repairer", "https://freelanceme.blob.core.windows.net/container1/roof_repairer" },
                    { 6, "#dcffb5", 1, "Packer", "https://freelanceme.blob.core.windows.net/container1/packing_service" },
                    { 7, "#fdf1d3", 1, "Window cleaner", "https://freelanceme.blob.core.windows.net/container1/window_cleaner" },
                    { 8, "#f3fee7", 1, "Yard worker", "https://freelanceme.blob.core.windows.net/container1/yard_worker" },
                    { 9, "#fee7e7", 2, "Housekeeper", "https://freelanceme.blob.core.windows.net/container1/housekeeper" },
                    { 10, "#e7edfe", 2, "Housesitter", "https://freelanceme.blob.core.windows.net/container1/housesitter" },
                    { 11, "#ffeab5", 2, "Babysitter", "https://freelanceme.blob.core.windows.net/container1/babysitter" },
                    { 12, "#dcffb5", 2, "Nanny", "https://freelanceme.blob.core.windows.net/container1/nanny" },
                    { 13, "#fdf1d3", 2, "Caregiver", "https://freelanceme.blob.core.windows.net/container1/caregiver" },
                    { 14, "#f3fee7", 2, "Cook", "https://freelanceme.blob.core.windows.net/container1/cook" },
                    { 15, "#fee7e7", 2, "Kitchen cleaner", "https://freelanceme.blob.core.windows.net/container1/kitchen_cleaner" },
                    { 16, "#e7edfe", 2, "Gardener", "https://freelanceme.blob.core.windows.net/container1/gardener" },
                    { 17, "#ffeab5", 2, "Grocery shopper", "https://freelanceme.blob.core.windows.net/container1/grocery_shopper" },
                    { 18, "#dcffb5", 2, "Errand runner", "https://freelanceme.blob.core.windows.net/container1/errand_runner" },
                    { 19, "#fdf1d3", 2, "Bartender", "https://freelanceme.blob.core.windows.net/container1/bartender" },
                    { 20, "#f3fee7", 3, "Chiropractor", "https://freelanceme.blob.core.windows.net/container1/chiropractor" },
                    { 21, "#fee7e7", 3, "Health aide", "https://freelanceme.blob.core.windows.net/container1/health_aide" },
                    { 22, "#e7edfe", 3, "Personal trainer", "https://freelanceme.blob.core.windows.net/container1/personal_trainer" },
                    { 23, "#ffeab5", 3, "Physiotherapist", "https://freelanceme.blob.core.windows.net/container1/physiotherapist" },
                    { 24, "#dcffb5", 3, "Yoga instructor", "https://freelanceme.blob.core.windows.net/container1/yoga_instructor" },
                    { 25, "#fdf1d3", 3, "Elderly companion", "https://freelanceme.blob.core.windows.net/container1/elderly_companion" },
                    { 26, "#f3fee7", 4, "Tutor", "https://freelanceme.blob.core.windows.net/container1/tutor" },
                    { 27, "#fee7e7", 4, "Personal assistant", "https://freelanceme.blob.core.windows.net/container1/personal_assistant" },
                    { 28, "#e7edfe", 4, "Interior designer", "https://freelanceme.blob.core.windows.net/container1/interior_designer" },
                    { 29, "#ffeab5", 4, "Stylist", "https://freelanceme.blob.core.windows.net/container1/stylist" },
                    { 30, "#dcffb5", 4, "Photographer", "https://freelanceme.blob.core.windows.net/container1/photographer" },
                    { 31, "#fdf1d3", 4, "Life Coach", "https://freelanceme.blob.core.windows.net/container1/life_coach" },
                    { 32, "#f3fee7", 5, "WiFi technician", "https://freelanceme.blob.core.windows.net/container1/wifi_technician" },
                    { 33, "#fee7e7", 5, "Computer repair technician", "https://freelanceme.blob.core.windows.net/container1/computer_repair_technician" },
                    { 34, "#e7edfe", 5, "Electrical appliance installer", "https://freelanceme.blob.core.windows.net/container1/electrical_appliance_installer" },
                    { 35, "#ffeab5", 5, "Smart home device installer", "https://freelanceme.blob.core.windows.net/container1/smart_home_device_installer" },
                    { 36, "#dcffb5", 5, "Home security system installer", "https://freelanceme.blob.core.windows.net/container1/home_security_system_installer" },
                    { 37, "#fdf1d3", 6, "Pet sitter", "https://freelanceme.blob.core.windows.net/container1/pet_sitter" },
                    { 38, "#f3fee7", 6, "Dog walker", "https://freelanceme.blob.core.windows.net/container1/dog_walker" },
                    { 39, "#fee7e7", 6, "Pet groomer", "https://freelanceme.blob.core.windows.net/container1/pet_groomer" },
                    { 40, "#e7edfe", 7, "Music teacher", "https://freelanceme.blob.core.windows.net/container1/music_teacher" },
                    { 41, "#ffeab5", 7, "Dance instructor", "https://freelanceme.blob.core.windows.net/container1/dance_instructor" },
                    { 42, "#dcffb5", 7, "Live music performer", "https://freelanceme.blob.core.windows.net/container1/live_music_performer" }
                });

            migrationBuilder.InsertData(
                table: "Freelancers",
                columns: new[] { "Id", "DomainId", "FulfilledContracts", "HourlyRate", "HoursBilled", "MainExpertiseId", "Rating", "UserType" },
                values: new object[,]
                {
                    { "id-abdulaziz-alrashid", 4, 22, 85.0, 440, 27, 4.7000000000000002, 0 },
                    { "id-abdullah-alsaud", 1, 20, 75.0, 400, 1, 4.7999999999999998, 0 },
                    { "id-ahmed-alshehri", 1, 15, 70.0, 300, 3, 4.5999999999999996, 0 },
                    { "id-aisha-alqahtani", 2, 24, 90.0, 480, 9, 4.7999999999999998, 0 },
                    { "id-amira-alharbi", 2, 20, 85.0, 400, 13, 4.7000000000000002, 0 },
                    { "id-andrew-anderson", 6, 20, 85.0, 400, 38, 4.7000000000000002, 0 },
                    { "id-asma-alsaif", 4, 15, 75.0, 300, 31, 4.5, 0 },
                    { "id-bandar-aldakhil", 4, 24, 90.0, 480, 28, 4.7999999999999998, 0 },
                    { "id-christopher-davis", 5, 18, 80.0, 360, 35, 4.5999999999999996, 0 },
                    { "id-daniel-taylor", 6, 15, 75.0, 300, 37, 4.5, 0 },
                    { "id-david-brown", 5, 24, 90.0, 480, 34, 4.7999999999999998, 0 },
                    { "id-fahad-almalki", 2, 14, 70.0, 280, 18, 4.5999999999999996, 0 },
                    { "id-faisal-alotaibi", 1, 28, 95.0, 560, 8, 4.9000000000000004, 0 },
                    { "id-fatima-alotaibi", 1, 20, 85.0, 400, 7, 4.7000000000000002, 0 },
                    { "id-ghada-alsubaie", 4, 28, 95.0, 560, 29, 4.9000000000000004, 0 },
                    { "id-hana-alzahrani", 3, 20, 85.0, 400, 21, 4.7000000000000002, 0 },
                    { "id-hassan-alzahrani", 2, 22, 85.0, 440, 19, 4.7999999999999998, 0 },
                    { "id-john-smith", 5, 28, 95.0, 560, 32, 4.9000000000000004, 0 },
                    { "id-joseph-thomas", 6, 24, 90.0, 480, 39, 4.7999999999999998, 0 },
                    { "id-khalid-alqahtani", 1, 22, 85.0, 440, 4, 4.9000000000000004, 0 },
                    { "id-layla-aldosari", 2, 15, 75.0, 300, 12, 4.5, 0 },
                    { "id-lina-alomairi", 3, 18, 80.0, 360, 25, 4.5999999999999996, 0 },
                    { "id-majid-alahmadi", 2, 16, 75.0, 320, 14, 4.7000000000000002, 0 },
                    { "id-maryam-alghamdi", 2, 28, 95.0, 560, 11, 4.9000000000000004, 0 },
                    { "id-matthew-wilson", 5, 28, 95.0, 560, 36, 4.9000000000000004, 0 },
                    { "id-maysa-aldakhil", 7, 24, 90.0, 480, 42, 4.7999999999999998, 0 },
                    { "id-meshal-alfahad", 4, 30, 100.0, 600, 30, 5.0, 0 },
                    { "id-michael-johnson", 5, 22, 85.0, 440, 33, 4.7000000000000002, 0 },
                    { "id-mohammed-alghamdi", 1, 18, 80.0, 360, 2, 4.7000000000000002, 0 },
                    { "id-nasser-alyami", 3, 26, 90.0, 520, 20, 4.9000000000000004, 0 },
                    { "id-noor-alsultan", 2, 24, 90.0, 480, 15, 4.7999999999999998, 0 },
                    { "id-noura-alshehri", 2, 18, 80.0, 360, 10, 4.5999999999999996, 0 },
                    { "id-omar-aldosari", 1, 25, 90.0, 500, 5, 4.7999999999999998, 0 },
                    { "id-raneem-alrashid", 7, 20, 85.0, 400, 41, 4.7000000000000002, 0 },
                    { "id-reem-almalki", 2, 30, 100.0, 600, 17, 5.0, 0 },
                    { "id-saad-alharbi", 1, 12, 65.0, 240, 6, 4.5, 0 },
                    { "id-sami-alomairi", 3, 18, 75.0, 360, 22, 4.7000000000000002, 0 },
                    { "id-sara-alyami", 3, 24, 90.0, 480, 24, 4.7999999999999998, 0 },
                    { "id-turki-alsultan", 2, 30, 100.0, 600, 16, 5.0, 0 },
                    { "id-waleed-alsaif", 4, 28, 95.0, 560, 26, 4.9000000000000004, 0 },
                    { "id-william-jackson", 7, 30, 100.0, 600, 40, 5.0, 0 },
                    { "id-yasser-alsubaie", 3, 20, 80.0, 400, 23, 4.7999999999999998, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ClientId",
                table: "Contracts",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_FreelancerId",
                table: "Contracts",
                column: "FreelancerId");

            migrationBuilder.CreateIndex(
                name: "IX_Expertises_DomainId",
                table: "Expertises",
                column: "DomainId");

            migrationBuilder.CreateIndex(
                name: "IX_Freelancers_DomainId",
                table: "Freelancers",
                column: "DomainId");

            migrationBuilder.CreateIndex(
                name: "IX_Freelancers_MainExpertiseId",
                table: "Freelancers",
                column: "MainExpertiseId");

            migrationBuilder.CreateIndex(
                name: "IX_Pings_ClientId",
                table: "Pings",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Pings_FreelancerId",
                table: "Pings",
                column: "FreelancerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "Pings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Freelancers");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Expertises");

            migrationBuilder.DropTable(
                name: "Domains");
        }
    }
}

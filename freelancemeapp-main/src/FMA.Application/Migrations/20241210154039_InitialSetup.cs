using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FMA.Application.Migrations
{
    /// <inheritdoc />
    public partial class InitialSetup : Migration
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
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateStarted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCompleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    HoursContracted = table.Column<int>(type: "int", nullable: true),
                    AmountPaid = table.Column<int>(type: "int", nullable: true),
                    ClientEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreelancerEmail = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    DatePinged = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    { "id-abdulaziz-alrashid", 0, "d8f5f554-758a-437f-9b88-504f2684e767", new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc), "abdulaziz@pingafreelancer.com", true, "Abdulaziz", true, "AlRashid", 27.523599999999998, true, null, 41.695399999999999, "ABDULAZIZ@PINGAFREELANCER.COM", "ABDULAZIZ@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEPbR4G/9Q1ocHDVq9wivEw8VeuUeHwjkbXuaS/NM0WtgpMNk4YRs0YKxrdo23hgnFA==", "+966516789012", false, "https://freelanceme.blob.core.windows.net/container1/a16", "593c30e4-95c1-43cd-b26c-92262003eb88", false, "abdulaziz@pingafreelancer.com", 0 },
                    { "id-abdullah-alsaud", 0, "2cf941fd-57de-4d24-a037-e6c221a71d96", new DateTime(2024, 10, 11, 0, 0, 0, 0, DateTimeKind.Utc), "abdullah@pingafreelancer.com", true, "Abdullah", true, "AlSaud", 24.7136, true, null, 46.6753, "ABDULLAH@PINGAFREELANCER.COM", "ABDULLAH@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEGYN0mwpQx66diAdmpENx6he2Q4oH/+s8VfbrXxMGOwEensI3nbWntMBeTcT+cVTNw==", "+966501234567", false, "https://freelanceme.blob.core.windows.net/container1/a1", "f559f246-4c18-4e06-bd4d-fdfe7b082d91", false, "abdullah@pingafreelancer.com", 0 },
                    { "id-ahmed-alshehri", 0, "5ed783ca-8326-4b72-b2bd-f35b893b8d42", new DateTime(2024, 10, 21, 0, 0, 0, 0, DateTimeKind.Utc), "ahmed@pingafreelancer.com", true, "Ahmed", true, "AlShehri", 26.2361, true, null, 50.039299999999997, "AHMED@PINGAFREELANCER.COM", "AHMED@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEJMwInY54nhFS2jIF5LBBX4+a3DEPKJufHUS9Ien+qhJ0vJDooWcg/ZGiwqWQclQkg==", "+966503456789", false, "https://freelanceme.blob.core.windows.net/container1/a3", "9c6e3c00-4743-4f63-93b5-dc4c1d3065f5", false, "ahmed@pingafreelancer.com", 0 },
                    { "id-aisha-alqahtani", 0, "c2afe1a6-9eb7-4767-91d3-386190eb4f8f", new DateTime(2024, 11, 23, 0, 0, 0, 0, DateTimeKind.Utc), "aisha@pingafreelancer.com", true, "Aisha", true, "AlQahtani", 28.399799999999999, true, null, 36.571399999999997, "AISHA@PINGAFREELANCER.COM", "AISHA@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEIFZy/aeq55NgXG12rbTmMrdEcIKDaSQ4+atIft+hn9v0XhFuPg0APc4K90IXLNMuA==", "+966529012345", false, "https://freelanceme.blob.core.windows.net/container1/f2", "d8ca9481-2010-487c-bdb3-4400acaf85a1", false, "aisha@pingafreelancer.com", 0 },
                    { "id-amira-alharbi", 0, "a176cf3d-a766-4603-a89e-4ed3368dd57e", new DateTime(2024, 11, 19, 0, 0, 0, 0, DateTimeKind.Utc), "amira@pingafreelancer.com", true, "Amira", true, "AlHarbi", 26.2361, true, null, 50.039299999999997, "AMIRA@PINGAFREELANCER.COM", "AMIRA@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAELfga0A+L1pN0vy7HYZaP1L5Vt+yyNKwnUX8SlDO7A8JLqEaIrKvf7RCT4UzIED1fQ==", "+966533456789", false, "https://freelanceme.blob.core.windows.net/container1/f6", "554cbc2b-d70c-4e1f-b300-888cbaac23cd", false, "amira@pingafreelancer.com", 0 },
                    { "id-andrew-anderson", 0, "d66d2c6f-1410-4fdf-9600-d120cca68554", new DateTime(2024, 11, 27, 0, 0, 0, 0, DateTimeKind.Utc), "andrew@pingafreelancer.com", true, "Andrew", true, "Anderson", 27.523599999999998, true, null, 41.695399999999999, "ANDREW@PINGAFREELANCER.COM", "ANDREW@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEFKb/6LJSSRy2K/Ax5/pW1HZMmrR88a3G8QXLk4qnVXK5I4M6+aG8cuLzllhap62hw==", "+966525678901", false, "https://freelanceme.blob.core.windows.net/container1/n7", "935e44f6-c0ea-4a12-af36-2ce4d138b676", false, "andrew@pingafreelancer.com", 0 },
                    { "id-asma-alsaif", 0, "4691957f-3916-4cbe-95d1-af80723fa4ba", new DateTime(2024, 11, 12, 0, 0, 0, 0, DateTimeKind.Utc), "asma@pingafreelancer.com", true, "Asma", true, "AlSaif", 27.523599999999998, true, null, 41.695399999999999, "ASMA@PINGAFREELANCER.COM", "ASMA@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEA1N9CeBuH4mlfuoOPfIoWHQmiTynHxhuzXfsl1i/dGr6AwbsvxWsZVEqgyKJuE8mg==", "+966540123456", false, "https://freelanceme.blob.core.windows.net/container1/f13", "a89aaa54-6cdb-4c64-814d-0d1f7bd06dcd", false, "asma@pingafreelancer.com", 0 },
                    { "id-bandar-aldakhil", 0, "546cba3c-d31a-449e-a276-9381740def21", new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Utc), "bandar@pingafreelancer.com", true, "Bandar", true, "AlDakhil", 21.485800000000001, true, null, 39.192500000000003, "BANDAR@PINGAFREELANCER.COM", "BANDAR@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEGPy9rcRT/dI78LP///NZVMLizSYV0DRV5qIue7fvO9ZI4NYLvESm8Lk+YC11dPncw==", "+966517890123", false, "https://freelanceme.blob.core.windows.net/container1/a17", "5355e4f7-ea9c-4f0a-963a-af74a660fc49", false, "bandar@pingafreelancer.com", 0 },
                    { "id-christopher-davis", 0, "f669e9c6-c3eb-45e2-863d-da7432dfdc6c", new DateTime(2024, 11, 30, 0, 0, 0, 0, DateTimeKind.Utc), "christopher@pingafreelancer.com", true, "Christopher", true, "Davis", 26.085100000000001, true, null, 43.973100000000002, "CHRISTOPHER@PINGAFREELANCER.COM", "CHRISTOPHER@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEMm6BtAo7kMPNcm4OK8K79bKmnSGrYtRzeMgHp+1qK0IX3hagqIMqU8kFtYup+5WPA==", "+966522345678", false, "https://freelanceme.blob.core.windows.net/container1/n4", "0cf89417-c18f-4ece-bcd9-b8f26fba7f0d", false, "christopher@pingafreelancer.com", 0 },
                    { "id-daniel-taylor", 0, "4c39b222-fe0e-4e65-8749-ecf6ea8ee6d1", new DateTime(2024, 11, 28, 0, 0, 0, 0, DateTimeKind.Utc), "daniel@pingafreelancer.com", true, "Daniel", true, "Taylor", 25.3841, true, null, 49.587600000000002, "DANIEL@PINGAFREELANCER.COM", "DANIEL@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEN+7VqTlsn96huNxw0p78tR+pHNnwrN7sVG96tDRfhh7hLtUisWbS4cbZnUM532jBQ==", "+966524567890", false, "https://freelanceme.blob.core.windows.net/container1/n6", "b265d338-71ba-4ba1-a820-ecf326cd0138", false, "daniel@pingafreelancer.com", 0 },
                    { "id-david-brown", 0, "1bd4427e-da50-41d8-8806-63d8051d066a", new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), "david@pingafreelancer.com", true, "David", true, "Brown", 21.270700000000001, true, null, 40.416699999999999, "DAVID@PINGAFREELANCER.COM", "DAVID@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEAXLB/WB8nZ2YdBxSK6rd+tsMTljYE+4K9rtUvmnVTb4PJo3v8HN/6OvH2o0MnhtAw==", "+966521234567", false, "https://freelanceme.blob.core.windows.net/container1/n3", "07f2bf80-9cf5-480c-9aaf-3858ea038026", false, "david@pingafreelancer.com", 0 },
                    { "id-fahad-almalki", 0, "07702733-11bb-4052-bc05-b33906a8eddb", new DateTime(2024, 11, 25, 0, 0, 0, 0, DateTimeKind.Utc), "fahad@pingafreelancer.com", true, "Fahad", true, "AlMalki", 27.523599999999998, true, null, 41.695399999999999, "FAHAD@PINGAFREELANCER.COM", "FAHAD@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAECGGFkF22Wh2qVWCVzBF5KgJ/a77Z3xP8apFO6u/jr1vGWb1Jz8Gkfl92G6WDSOfEg==", "+966510123456", false, "https://freelanceme.blob.core.windows.net/container1/a10", "038e2e28-1b97-4023-8132-16c686654066", false, "fahad@pingafreelancer.com", 0 },
                    { "id-faisal-alotaibi", 0, "3405e715-71da-4391-9dc7-cb1539125dd1", new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Utc), "faisal@pingafreelancer.com", true, "Faisal", true, "AlOtaibi", 26.085100000000001, true, null, 43.973100000000002, "FAISAL@PINGAFREELANCER.COM", "FAISAL@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEFU6DPHwP6RViNwWH3oY1udKvQ2Fyj6X5t6O2yy3eJh43isvdgYesXXSo3Qz9zN9RA==", "+966507890123", false, "https://freelanceme.blob.core.windows.net/container1/a7", "00643dde-fe84-45d1-adb1-8c7f1d79bc63", false, "faisal@pingafreelancer.com", 0 },
                    { "id-fatima-alotaibi", 0, "7b1475f3-0775-4b50-99e4-bc89b682a20c", new DateTime(2024, 11, 24, 0, 0, 0, 0, DateTimeKind.Utc), "fatima@pingafreelancer.com", true, "Fatima", true, "AlOtaibi", 30.098400000000002, true, null, 40.285400000000003, "FATIMA@PINGAFREELANCER.COM", "FATIMA@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEIRJd5ybopELWiHdbn177yrSoNrfBx3lnyef77n1O/6HvzEnkFVS+GPUB157Gmxqdg==", "+966528901234", false, "https://freelanceme.blob.core.windows.net/container1/f1", "a928c1fb-b3bb-4d0d-97ff-5a23a279ce64", false, "fatima@pingafreelancer.com", 0 },
                    { "id-ghada-alsubaie", 0, "2d114a1d-5504-40b0-8b15-94a030078dda", new DateTime(2024, 11, 13, 0, 0, 0, 0, DateTimeKind.Utc), "ghada@pingafreelancer.com", true, "Ghada", true, "AlSubaie", 25.3841, true, null, 49.587600000000002, "GHADA@PINGAFREELANCER.COM", "GHADA@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEOBmUWtY0ckHIZ4KEjZzh3ExvWqoGkQ0sXhwQlVrcXYSDDjIEs0bvhaEgfUEYxiUaw==", "+966539012345", false, "https://freelanceme.blob.core.windows.net/container1/f12", "ae35b8a3-ad5b-4e89-bcc6-ff731fa9af13", false, "ghada@pingafreelancer.com", 0 },
                    { "id-hana-alzahrani", 0, "b34f77c4-67a5-4db7-93c9-3c3cc0610953", new DateTime(2024, 11, 16, 0, 0, 0, 0, DateTimeKind.Utc), "hana@pingafreelancer.com", true, "Hana", true, "AlZahrani", 21.270700000000001, true, null, 40.416699999999999, "HANA@PINGAFREELANCER.COM", "HANA@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAECBQOKYdj48QWF8H1DWgDX3oM8P9p1e8Mrch8VPRqiE9fbk7tnC1rITd3sGVnbWOmg==", "+966536789012", false, "https://freelanceme.blob.core.windows.net/container1/f9", "b7a13de7-e4e5-42c2-99d2-68fb735bb03c", false, "hana@pingafreelancer.com", 0 },
                    { "id-hassan-alzahrani", 0, "7e2daa89-e2c2-48ef-b283-1be9992b96d9", new DateTime(2024, 11, 30, 0, 0, 0, 0, DateTimeKind.Utc), "hassan@pingafreelancer.com", true, "Hassan", true, "AlZahrani", 17.493300000000001, true, null, 44.128999999999998, "HASSAN@PINGAFREELANCER.COM", "HASSAN@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEFLagvmTFsFrIviyyTZaChe5WhkkO3XQ1PCsyDDQ0pJdYjojjsHAM1ZaXCo46Nf9Eg==", "+966511234567", false, "https://freelanceme.blob.core.windows.net/container1/a11", "f68cf04e-0791-4877-a58a-f05fbae937cd", false, "hassan@pingafreelancer.com", 0 },
                    { "id-john-smith", 0, "9b7c5916-072d-4e6d-8fc1-05e356166459", new DateTime(2024, 12, 3, 0, 0, 0, 0, DateTimeKind.Utc), "john@pingafreelancer.com", true, "John", true, "Smith", 24.466699999999999, true, null, 39.600000000000001, "JOHN@PINGAFREELANCER.COM", "JOHN@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEEHx2zbwZmqeqGrxefXLtJJvuUSLzRWB8qx5F1OdnEvE8yi0Ya+VX8Sib8rJgfkrIA==", "+966519012345", false, "https://freelanceme.blob.core.windows.net/container1/n1", "84db0565-4376-4a3c-9395-7ea664e1e03e", false, "john@pingafreelancer.com", 0 },
                    { "id-joseph-thomas", 0, "a73f92d7-a110-41b5-8e48-f67f8fb03331", new DateTime(2024, 11, 26, 0, 0, 0, 0, DateTimeKind.Utc), "joseph@pingafreelancer.com", true, "Joseph", true, "Thomas", 17.493300000000001, true, null, 44.128999999999998, "JOSEPH@PINGAFREELANCER.COM", "JOSEPH@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEGlulxm+X1wX0my7Yai/hVtQqw6pW/J/hUHlMsYiWgJ6zbi5ahricZ25y+f/Q16Mtg==", "+966526789012", false, "https://freelanceme.blob.core.windows.net/container1/n8", "e9230730-7428-4c81-9986-319bd1cefad5", false, "joseph@pingafreelancer.com", 0 },
                    { "id-kanaan-abukhadra", 0, "2f83dbd8-7fbd-47b8-856b-d490ff51f4c7", new DateTime(2024, 12, 10, 15, 40, 37, 349, DateTimeKind.Utc).AddTicks(5810), "kanaanabukhadra@gmail.com", true, "Kanaan", true, "Abukhadra", 26.329999999999998, true, null, 50.130000000000003, "KANAANABUKHADRA@GMAIL.COM", "KANAANABUKHADRA@GMAIL.COM", "AQAAAAIAAYagAAAAEETTta8sCoW3fQBEtR7RYczu81FzhFmOeXFkqbjtgV+0LbhlErBO8/uFuv5HdoQypA==", "+966503725354", false, "https://freelanceme.blob.core.windows.net/container1/kanaan", "3a65e697-9b42-4647-95c0-3552825a7dd4", false, "kanaanabukhadra@gmail.com", 1 },
                    { "id-khalid-alqahtani", 0, "8bc4f923-f4a0-427b-83fb-a334b02b09d0", new DateTime(2024, 10, 26, 0, 0, 0, 0, DateTimeKind.Utc), "khalid@pingafreelancer.com", true, "Khalid", true, "AlQahtani", 24.466699999999999, true, null, 39.600000000000001, "KHALID@PINGAFREELANCER.COM", "KHALID@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEIJQmg00HO4PIug459gBJQJFZjS7I2u6Rg1FT23ajLIIWp26Ltz2NkWS1rj7JpkaTQ==", "+966504567890", false, "https://freelanceme.blob.core.windows.net/container1/a4", "545e45d2-389a-489b-8446-32aaa07ac0da", false, "khalid@pingafreelancer.com", 0 },
                    { "id-layla-aldosari", 0, "4dc64166-30b8-432c-bf7a-c9e1ac9d0474", new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Utc), "layla@pingafreelancer.com", true, "Layla", true, "AlDosari", 21.485800000000001, true, null, 39.192500000000003, "LAYLA@PINGAFREELANCER.COM", "LAYLA@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAENBmLR4tlJK1Z8lRGls7StEalSjRZmdZ2EcYXVcv0jCZLcj96jO0+UtjtpPCLodghw==", "+966532345678", false, "https://freelanceme.blob.core.windows.net/container1/f5", "00f7a651-49b1-4473-87a9-cefa40691125", false, "layla@pingafreelancer.com", 0 },
                    { "id-lina-alomairi", 0, "d3a1ed13-06a3-42db-ba23-0be670d1507f", new DateTime(2024, 11, 14, 0, 0, 0, 0, DateTimeKind.Utc), "lina@pingafreelancer.com", true, "Lina", true, "AlOmairi", 18.2164, true, null, 42.505299999999998, "LINA@PINGAFREELANCER.COM", "LINA@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAENkAqGNIEPQTSKcXHRNnahH4rKkNiBMbw5aRfeKsk+K2uXZ8s8zBBWA+v/CCxEpxYg==", "+966538901234", false, "https://freelanceme.blob.core.windows.net/container1/f11", "c1d1daa8-64fe-43c3-a302-4b2821d4abdf", false, "lina@pingafreelancer.com", 0 },
                    { "id-majid-alahmadi", 0, "bcbff566-61f8-4b24-bf76-49556a050ddf", new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Utc), "majid@pingafreelancer.com", true, "Majid", true, "AlAhmadi", 18.2164, true, null, 42.505299999999998, "MAJID@PINGAFREELANCER.COM", "MAJID@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEMVBt51GnNPsIQlNadIyqIyrhXY9iaQXHGPMJsqN0OIRUX0j42IPHC4rxA2wBeZGXA==", "+966508901234", false, "https://freelanceme.blob.core.windows.net/container1/a8", "6216a42c-c7a3-4020-8629-e0d4ec806963", false, "majid@pingafreelancer.com", 0 },
                    { "id-maryam-alghamdi", 0, "7c3e7733-f1de-4348-824c-8a29216674af", new DateTime(2024, 11, 21, 0, 0, 0, 0, DateTimeKind.Utc), "maryam@pingafreelancer.com", true, "Maryam", true, "AlGhamdi", 27.523599999999998, true, null, 41.695399999999999, "MARYAM@PINGAFREELANCER.COM", "MARYAM@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEMVyyuNjPV8EZJqK49bhQLggXTP8l2ADveUeP90EteMKU52JT0phdA2MiSAS3scZyg==", "+966531234567", false, "https://freelanceme.blob.core.windows.net/container1/f4", "55bf4521-bc5e-4baf-9f7d-05bfd7d9cf08", false, "maryam@pingafreelancer.com", 0 },
                    { "id-matthew-wilson", 0, "ae9d6c42-f0a5-4bb5-879d-7a817ef20fb3", new DateTime(2024, 11, 29, 0, 0, 0, 0, DateTimeKind.Utc), "matthew@pingafreelancer.com", true, "Matthew", true, "Wilson", 18.2164, true, null, 42.505299999999998, "MATTHEW@PINGAFREELANCER.COM", "MATTHEW@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEMrR08DRr3iWrVYegnZ+MIo8GORcqs9vcqUJdN2ztXOqhKZAiweNHonlUHWEu47xQA==", "+966523456789", false, "https://freelanceme.blob.core.windows.net/container1/n5", "e5316941-7133-4143-b283-25bbfa841ed0", false, "matthew@pingafreelancer.com", 0 },
                    { "id-maysa-aldakhil", 0, "58a2cfbd-d5f8-4ec0-96aa-36053403e32f", new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Utc), "maysa@pingafreelancer.com", true, "Maysa", true, "AlDakhil", 24.524699999999999, true, null, 39.569200000000002, "MAYSA@PINGAFREELANCER.COM", "MAYSA@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEO4XmbO3Ctk8jXvtpARFvC0IqFmU0cSPl1bunEI+c1GDMYkwUzSU+wGoz83eAGSOng==", "+966542345678", false, "https://freelanceme.blob.core.windows.net/container1/f15", "7f3d1737-2ae1-433a-a46a-ef44179cc659", false, "maysa@pingafreelancer.com", 0 },
                    { "id-meshal-alfahad", 0, "c1b80b2f-068e-43d9-843b-85c31f7cbf50", new DateTime(2024, 12, 4, 0, 0, 0, 0, DateTimeKind.Utc), "meshal@pingafreelancer.com", true, "Meshal", true, "AlFahad", 26.2361, true, null, 50.039299999999997, "MESHAL@PINGAFREELANCER.COM", "MESHAL@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEBLJDNF5j2L2Cl1luFUXh25/72ruCvwH2a6sIyuoZqFp5AAO9acmwQ82uO7hnaV5tw==", "+966518901234", false, "https://freelanceme.blob.core.windows.net/container1/a18", "32b71c2d-1031-49b2-96fb-dc9e76f91a9c", false, "meshal@pingafreelancer.com", 0 },
                    { "id-michael-johnson", 0, "165428e8-a72d-4ea5-9946-8181bc8c575f", new DateTime(2024, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), "michael@pingafreelancer.com", true, "Michael", true, "Johnson", 26.4207, true, null, 50.088799999999999, "MICHAEL@PINGAFREELANCER.COM", "MICHAEL@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAENyAWA5khVRUnE4NriiGCe2tfsg11GPsZDbRHj07buRJ6y5siEz3MYymBWCPCVMwqg==", "+966520123456", false, "https://freelanceme.blob.core.windows.net/container1/n2", "e2edc563-025b-4933-8fae-421868a349c6", false, "michael@pingafreelancer.com", 0 },
                    { "id-mohammed-alghamdi", 0, "39f7ca0c-4cdf-4685-9825-2b3467cf9c0e", new DateTime(2024, 10, 16, 0, 0, 0, 0, DateTimeKind.Utc), "mohammed@pingafreelancer.com", true, "Mohammed", true, "AlGhamdi", 21.485800000000001, true, null, 39.192500000000003, "MOHAMMED@PINGAFREELANCER.COM", "MOHAMMED@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEEGEkZhyv1GUbdECQa5NzbgAgRA794zTrEPWDsdySDUUcHUbFEwqDCt9pacXABBFnA==", "+966502345678", false, "https://freelanceme.blob.core.windows.net/container1/a2", "601b6ece-1d42-4ad6-bd29-26505b273d3c", false, "mohammed@pingafreelancer.com", 0 },
                    { "id-nasser-alyami", 0, "30e9812e-fac9-4baa-afec-e345f87d8191", new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Utc), "nasser@pingafreelancer.com", true, "Nasser", true, "AlYami", 24.524699999999999, true, null, 39.569200000000002, "NASSER@PINGAFREELANCER.COM", "NASSER@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEJKJDoM1Rff9Ym3VJkOONXyP7XIZXgQOmZ/ZciI3n/PZUN7w4aaD7t/oPn0ReoqKJQ==", "+966512345678", false, "https://freelanceme.blob.core.windows.net/container1/a12", "d3a9063b-045a-405f-bbea-71fb5d0f03aa", false, "nasser@pingafreelancer.com", 0 },
                    { "id-noor-alsultan", 0, "5981f7f8-b4e8-4f3f-87f2-995cb847f78c", new DateTime(2024, 11, 18, 0, 0, 0, 0, DateTimeKind.Utc), "noor@pingafreelancer.com", true, "Noor", true, "AlSultan", 24.466699999999999, true, null, 39.600000000000001, "NOOR@PINGAFREELANCER.COM", "NOOR@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAENj/eLCUvqPYldaJ9hNlWugjsrEG2GIwWyXf16MjkBYE+V+3+gvlcubHTanlHFvN4A==", "+966534567890", false, "https://freelanceme.blob.core.windows.net/container1/f7", "f15e83a5-0bab-46a8-b40d-d84116e8150a", false, "noor@pingafreelancer.com", 0 },
                    { "id-noura-alshehri", 0, "52937267-b4c0-411b-849f-6c73a938991d", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), "noura@pingafreelancer.com", true, "Noura", true, "AlShehri", 25.664000000000001, true, null, 42.699599999999997, "NOURA@PINGAFREELANCER.COM", "NOURA@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEPdUPYZxoKNkcRGxhd/StcMFFkvuVtGBgU6nOHVreWpwhCXwRMDKxlcfRcZkLIv39w==", "+966530123456", false, "https://freelanceme.blob.core.windows.net/container1/f3", "c92a27ef-954d-40a5-b6e1-1f52648c0f18", false, "noura@pingafreelancer.com", 0 },
                    { "id-omar-aldosari", 0, "75ccccee-a042-4a8b-ace9-5e719a7c8212", new DateTime(2024, 10, 31, 0, 0, 0, 0, DateTimeKind.Utc), "omar@pingafreelancer.com", true, "Omar", true, "AlDosari", 26.4207, true, null, 50.088799999999999, "OMAR@PINGAFREELANCER.COM", "OMAR@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEL7OnIpXegQxgyWDMWQaQMW5OeQS4XoJ/MlEmVuAdJ6M+H6rlEpXiQFECZPk9Uisgw==", "+966505678901", false, "https://freelanceme.blob.core.windows.net/container1/a5", "968949de-5333-4859-bfb4-2b4dda90c3b9", false, "omar@pingafreelancer.com", 0 },
                    { "id-raneem-alrashid", 0, "dd80c369-ba50-4b9c-90ac-a184b98eec2d", new DateTime(2024, 11, 11, 0, 0, 0, 0, DateTimeKind.Utc), "raneem@pingafreelancer.com", true, "Raneem", true, "AlRashid", 17.493300000000001, true, null, 44.128999999999998, "RANEEM@PINGAFREELANCER.COM", "RANEEM@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEMesWoDkA/+n5zzFVpGLkwFfvbIkW3AfKYHrtDGel+unZNx+M0azXrWBke7O3QGKWg==", "+966541234567", false, "https://freelanceme.blob.core.windows.net/container1/f14", "1cb59333-d634-4d40-86c4-ce6a7d254d4a", false, "raneem@pingafreelancer.com", 0 },
                    { "id-reem-almalki", 0, "ef2b4188-ba38-47a9-b117-9ae0236d7313", new DateTime(2024, 11, 17, 0, 0, 0, 0, DateTimeKind.Utc), "reem@pingafreelancer.com", true, "Reem", true, "AlMalki", 26.4207, true, null, 50.088799999999999, "REEM@PINGAFREELANCER.COM", "REEM@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEC56/rilr7PKOP7vXha7yQKsjJ8i4NiHuy1A5FKxBTKFqL0+Ik6NHGBHbxbt85WQTA==", "+966535678901", false, "https://freelanceme.blob.core.windows.net/container1/f8", "009fbad6-0d3d-48f2-8613-49580a3f7cdd", false, "reem@pingafreelancer.com", 0 },
                    { "id-saad-alharbi", 0, "aade9dbc-f7d5-47a5-b270-504cc85b4846", new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Utc), "saad@pingafreelancer.com", true, "Saad", true, "AlHarbi", 21.270700000000001, true, null, 40.416699999999999, "SAAD@PINGAFREELANCER.COM", "SAAD@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEJR3YtiAGLJuH6spk73D9KucrwVAMFTe+nKbBaXVit2pEHzGJ+4wn4lnu2+ZBKtL5g==", "+966506789012", false, "https://freelanceme.blob.core.windows.net/container1/a6", "6248d70d-6e44-45ba-80ff-0f8f90336cde", false, "saad@pingafreelancer.com", 0 },
                    { "id-sami-alomairi", 0, "0394eeed-8364-41af-a6ee-bfd7c2fae7fe", new DateTime(2024, 12, 9, 0, 0, 0, 0, DateTimeKind.Utc), "sami@pingafreelancer.com", true, "Sami", true, "AlOmairi", 30.098400000000002, true, null, 40.285400000000003, "SAMI@PINGAFREELANCER.COM", "SAMI@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEMvZblvabDX/lfJ16iIsG8cTjw1Tza8XgkR3VpqQXXxR0Frn/Qqlz98RjuO8LK9gVA==", "+966513456789", false, "https://freelanceme.blob.core.windows.net/container1/a13", "68680fbe-d8d6-4824-9e71-0c2c0ef53e12", false, "sami@pingafreelancer.com", 0 },
                    { "id-sara-alyami", 0, "ac4a8989-f73f-43ce-a8c1-d4dc90935766", new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Utc), "sara@pingafreelancer.com", true, "Sara", true, "AlYami", 26.085100000000001, true, null, 43.973100000000002, "SARA@PINGAFREELANCER.COM", "SARA@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAELHYjJz+2sfzEFjBTBfglLk55quS0MVTeUu96n3BljLfAWoWThrQCZG3fig/d424Uw==", "+966537890123", false, "https://freelanceme.blob.core.windows.net/container1/f10", "b18392f8-6097-421c-90b0-0ada8df0284f", false, "sara@pingafreelancer.com", 0 },
                    { "id-turki-alsultan", 0, "111e4489-542b-44c0-b04f-bafe3138d8f8", new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Utc), "turki@pingafreelancer.com", true, "Turki", true, "AlSultan", 25.3841, true, null, 49.587600000000002, "TURKI@PINGAFREELANCER.COM", "TURKI@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEPPtDwGFzrzBDbAzpbTlIL98QnFC14IpZ8xJu3CzNYZqlAy1WLdlswUko98Zy/mu+A==", "+966509012345", false, "https://freelanceme.blob.core.windows.net/container1/a9", "e0a4d130-6e95-4d7c-b55a-9569db2539eb", false, "turki@pingafreelancer.com", 0 },
                    { "id-waleed-alsaif", 0, "554ecc6b-1481-4902-bc8c-096246435ad9", new DateTime(2024, 12, 7, 0, 0, 0, 0, DateTimeKind.Utc), "waleed@pingafreelancer.com", true, "Waleed", true, "AlSaif", 25.664000000000001, true, null, 42.699599999999997, "WALEED@PINGAFREELANCER.COM", "WALEED@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEGtmY/TL7sS7CNk9bWgj2lszjBCAiGo8JICY/3kojFCTBIs0WQiBg4gplsKQiN6Pqw==", "+966515678901", false, "https://freelanceme.blob.core.windows.net/container1/a15", "bcfd603e-6189-436d-967f-5119ec4ad540", false, "waleed@pingafreelancer.com", 0 },
                    { "id-william-jackson", 0, "d27c7511-b903-443e-b56f-0a9f2815ffa9", new DateTime(2024, 11, 25, 0, 0, 0, 0, DateTimeKind.Utc), "william@pingafreelancer.com", true, "William", true, "Jackson", 24.524699999999999, true, null, 39.569200000000002, "WILLIAM@PINGAFREELANCER.COM", "WILLIAM@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEBnk9Y1L1Pkcy7R5wU9iuBlmoV33DP1YQdF8GKU6uAdty6Obtdjwf8NshTqWI/gaJQ==", "+966527890123", false, "https://freelanceme.blob.core.windows.net/container1/n9", "ec229956-0940-4081-8d83-91d2242cb455", false, "william@pingafreelancer.com", 0 },
                    { "id-yasser-alsubaie", 0, "9d8ae1f2-c260-4333-be03-6cab1a7cb995", new DateTime(2024, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), "yasser@pingafreelancer.com", true, "Yasser", true, "AlSubaie", 28.399799999999999, true, null, 36.571399999999997, "YASSER@PINGAFREELANCER.COM", "YASSER@PINGAFREELANCER.COM", "AQAAAAIAAYagAAAAEN7utorfwIGPvYNwclzI1bJkurS1sq1zeo2S9UMiawaDnseC6QWXmgllWz/LyoOunw==", "+966514567890", false, "https://freelanceme.blob.core.windows.net/container1/a14", "ee862a8a-39f9-4f5b-9f09-1e477290641d", false, "yasser@pingafreelancer.com", 0 }
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

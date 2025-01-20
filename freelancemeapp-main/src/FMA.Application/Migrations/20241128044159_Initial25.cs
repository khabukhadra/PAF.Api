using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FMA.Application.Migrations
{
    /// <inheritdoc />
    public partial class Initial25 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientUserId",
                table: "Pings");

            migrationBuilder.DropColumn(
                name: "FreelancerUserId",
                table: "Pings");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-abdulaziz-alrashid",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d9cecf10-4049-4de8-a312-dd73ca16b186", new DateTime(2024, 11, 24, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEAXlvjybtTfYBQbuvsuZjfQeaZYQwRNDW9/eAvGC9OTIv5+qbsiTNpk+Ru9daO425Q==", "d7c3faa6-89f9-42fe-a078-6ca6e1ac919e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-abdullah-alsaud",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b71ee1c7-0cad-4a00-a80e-49207edb7e52", new DateTime(2024, 9, 29, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEChD+jXdDxhGnh0g2xWdPRQRr8Bou0oB8pmDdsd06N2rVDEEoZG2C1N4hpbO7GdMlA==", "3dcb13c5-a71c-4176-9fb3-15c8b8f04223" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-ahmed-alshehri",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "89de57a9-5492-4b40-8aa2-73c9e4842776", new DateTime(2024, 10, 9, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEIWVvPB27prfNQdyis/st1f2NPDBZi7Pw5hIQ74RSLJmca6LYvgplYxBWF2OTXaZ5w==", "cfa1361f-315a-4b11-9aeb-d48539c86606" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-aisha-alqahtani",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0af586bd-1b77-4ce5-9961-2a3ac1d7cbc4", new DateTime(2024, 11, 11, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAELWlgZtE4OlOJ9xUcrkCFqXDovgqepVU+FPbvgW+t/xr+aAdoJUPusanDMQeifI+dw==", "f01dae61-d4b0-4ea2-9876-f2e790d686fc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-amira-alharbi",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f928403-3e4f-46e5-ad04-055a6505afe5", new DateTime(2024, 11, 7, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEIF84dH2ec8kpRBwm5/byK1+yRJ2hVa1sfkNa6cMdKm7bur9/yGYawMCZ+7t5sQZQQ==", "8a9b2af1-6191-46f9-a362-2c42ce5a14fa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-andrew-anderson",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bcbf2085-ba9c-4d08-9b7c-2bd1edeaca2d", new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEFot5c2GxGp2QbQCJGHbud1T9lIqF3og5GS+SZPYXRsut23yd8ZmjZ5Tbc2UKTzy0Q==", "edc203e8-e7f5-4193-a24f-4758f0043e17" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-asma-alsaif",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eb04899f-47bf-4e3f-bfa6-71c9f8c8b899", new DateTime(2024, 10, 31, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEGQlRaVh+c0F1/9mAM0pWP6+PV+da61F5nMrfgyx9OykOsXY3sIKANTh8LiVB0MxRQ==", "265bb544-2b4b-4a50-bb64-11d57e36e371" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-bandar-aldakhil",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "340d9060-2503-4c1d-8226-cb011ddc5c8f", new DateTime(2024, 11, 23, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEOcAEl4pSWU/Ih8QZ0XEYyvN0zqnZn9Wea9E4Sf2/qPWk3h88yYfKJmJM8D+g6JgDg==", "ecfadd24-69f1-4f7c-beaa-7ffe57cb5cdc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-christopher-davis",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48d756e5-ef77-4548-8baf-c56377bb988f", new DateTime(2024, 11, 18, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEAwZS3LeDfBAOBDPozKYRTzYBwlco2rY0hgCoQFfFJZGz5BDbDHt3TRzCPtzG91kJw==", "f85da0f3-e5fb-4120-9909-278af50ee146" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-daniel-taylor",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "43e976d5-b172-4e97-8eb3-ed2b897a619d", new DateTime(2024, 11, 16, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEJSBiQUNmeM1qG1aS4/Mr4qNw47JDI0FzhJmemFJ8vMO+ZLPTONucqtUPw2aZAxL5w==", "203467cf-032b-4cf2-9d7b-e36f798a68fb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-david-brown",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1dd93824-b922-479c-8d94-eb94db99f0f8", new DateTime(2024, 11, 19, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAENZO0/hWwJdB+/bpiWoDKWHaWL2YrnhUczDEN8AeUQyv4n+CKRt7Kn5YB6QM1sNfKg==", "70aa5f9d-67c4-4866-826d-759ce63bba89" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-fahad-almalki",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "69f93e19-10fd-406f-a54a-71b59c4ffb10", new DateTime(2024, 11, 13, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEBJg0VKcXVavLKnvq76zpsHjluY7UP2QKvG8fMAZBUNKWHYguNOFhlQpg4rv7mdnYA==", "921a4f41-f0b2-443a-81c1-4bcbf04e4796" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-faisal-alotaibi",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2153061d-19b7-49fc-a8f3-c158f49cc21f", new DateTime(2024, 10, 29, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAELMEVhLGpNWAI+AMENHBzq13WTW0EW8yrshmtDW6X0WYZ99amZseIhi4JddmwB2uUw==", "da02a0a3-46f9-4028-8225-3df94315cad2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-fatima-alotaibi",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f1b2d474-cb5b-470e-95da-bf8d163392a0", new DateTime(2024, 11, 12, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEMvrQ178n+Zrvft6TsFGMSb8cwTwAKuVDCHNsO9xhCAh2HC7mdXQhbNDc1cXFI1bYQ==", "1932b748-3833-4f9c-82b3-b4f3ea3ff35a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-ghada-alsubaie",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7904ac7d-6548-4677-8db1-f129b836f2ae", new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEAhnCw9/hGnIpUqmza4r055XJthMrOnJn06KdgvL8xdvMiP6RFEsBv/kPznXmlC6PA==", "262eaa05-48cb-45cf-bbf3-a23675ee8867" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-hana-alzahrani",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "82657a40-8bae-45b4-9ba9-59efd3b9ca96", new DateTime(2024, 11, 4, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEN+v7tR6LS2p5Roo7uRPV51i+GVrfeR4C0uxf/4/uDNj+ljezlQyzKPU14KXOQFGqg==", "f079182e-7cce-40e1-acde-53a4fa0a5419" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-hassan-alzahrani",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9355f3fe-bdfa-411c-ada1-599a518cfb12", new DateTime(2024, 11, 18, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEKdVDmzBzzOdNnRboApbbehZCcJnTjvWP2Lyo/sAGy2K4VmRF1ZR/UQORN+muuGY0Q==", "be2bb449-577f-48cb-abe0-4ea4548f866f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-john-smith",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4f95db88-2db4-431f-9e8f-8ba3e5768fe7", new DateTime(2024, 11, 21, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAECPASXhX3dibUHWtoTTJTzp/Qlj2pCd7qUwU/2gM05Sg2H8ycFMJBAYE4ZMdwBR9rQ==", "0ca9c0c6-0f8e-4b11-ada5-bcf8fa70dc9b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-joseph-thomas",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c7ecb06-b2af-40e8-9cdb-1975e2e75204", new DateTime(2024, 11, 14, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEN+gpinP/VgCRcMUUkntNMA0B6oxLbFNK2cmRV7Iio+8ueG+eALdL3gqTr/y0xsWIw==", "6ee73364-eb71-4e12-abcd-f59252b5c0a2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-kanaan-abukhadra",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e9bfbb19-f8f1-462f-8389-44fe64488add", new DateTime(2024, 11, 28, 4, 41, 57, 727, DateTimeKind.Utc).AddTicks(5950), "AQAAAAIAAYagAAAAEJ+hhqw+kw7QNir1Amw1TlK/pfBYASQ3/cShupXE6xXY7eAfCbuJQwvwrKPlbqLVQA==", "84348e0c-9a9c-4f01-8428-9b247e797465" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-khalid-alqahtani",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b4ebcc8d-2cdd-47dc-a65e-600b1145ec00", new DateTime(2024, 10, 14, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEDAGBj8FdEgOA8ZiZ1VpKK0ghv/p00L0K6exTBpJgzWvFNdSi2aJs1bE2D9MIyd/Hw==", "ec418460-7133-478a-8555-2a4226e36a67" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-layla-aldosari",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d6922c0-f3b9-4115-a440-1aef78ce7e7a", new DateTime(2024, 11, 8, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEApvyLi9jaQd+n4dZwk5SOfluMJtFRJGtLTFoziHQJki/QpiPgOPX5rn19okshlJzw==", "c3a79065-ef15-46c9-815d-abfca28a9f97" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-lina-alomairi",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc9a8536-2321-481c-a974-67970c893546", new DateTime(2024, 11, 2, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAED1oyLJ9iiwl2xm9MHOdYyFzl19oqNpwG37AfHDVj0F7+psDu0y2dcXCpKNWvh9T1w==", "b841bd27-69bc-4d33-94b9-c7155311b80a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-majid-alahmadi",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3306e45b-d281-42a8-84b1-be2ba7543efa", new DateTime(2024, 11, 3, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEGHtOXzpNXjwBEd9BntNgQnSSXBfNjxZZ+ehw2K4pXlO2gAiiQAV6bmwzFcNDVEc3Q==", "663492fc-870c-4498-ba11-2f85e0237db3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-maryam-alghamdi",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc5568a5-6c6a-4358-8dae-1e5d302503b0", new DateTime(2024, 11, 9, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAELVSpB9kXY9SPg4EeiF2JupXTiSH126um2m+FYFjvmbFucBhMXC+sScyRTQBnweMOA==", "0b4c84a8-ef90-413b-86df-2b53a925a82b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-matthew-wilson",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ffc5030-0353-480b-9d4d-081c0443ba1c", new DateTime(2024, 11, 17, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEExp9v2db1nkUz21rmXqrgqWbUyFJn1AqNNflk/oMt5pa+jn8oq404HVGP7JKZvoAA==", "1bb61654-0027-4372-b012-f220fc6a1739" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-maysa-aldakhil",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f15c0c05-b6af-482a-adb8-d8270dd758c3", new DateTime(2024, 10, 29, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEJgHApQ3Pqk9qNevaZI6xY3c8nqgh7yxA3R882+TMOwFoyehczVVCVMR/IPBRTMDVQ==", "e7b92a8d-bb10-4c4b-a46c-5faf7188940c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-meshal-alfahad",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "803f4bdf-6e5a-4734-b791-cba309748168", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEIBVF0rEkalE23DFMYGZkvQKMcH+nZ0hwM0i9Bjf/lAf92NIvkveJOK2ioOB2qhi6w==", "28fcfb90-b022-479e-afe0-3cff8da736b3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-michael-johnson",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2c77c0de-4500-4693-a32e-29ac655685c6", new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEPuXEqSZyeHI31h9bVgjcMqQyN0Y8bimYeuu7An9wGyqpTXN1Uyn0SDuNyD0cMx39g==", "3a80d46e-fbf4-4b90-b751-d50b40dfc056" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-mohammed-alghamdi",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9596543-16be-4f5f-a538-3a56ad2168bc", new DateTime(2024, 10, 4, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEJmFIsdW2YW7IjOviosWicnfTV+zGMSgMlD1akfrj5/hjPpHPE8Iajcbm80/4Et+fA==", "7026104a-c813-4f61-80c7-356e7a648b06" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-nasser-alyami",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4a295527-ba6c-4e86-8532-56b0ddeff40b", new DateTime(2024, 11, 23, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEBVdIQFdojtrgm91LXYQXyWTAwqqBRrsDwpuWspnSPbazv5dzuXQidQ7YsTbN/+WAg==", "b52f7292-267f-427d-b040-9754f515adaa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-noor-alsultan",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "646cd755-eb89-46c4-92eb-a8d2661d5e4d", new DateTime(2024, 11, 6, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEPP7Ar+ZA7s/if9WalTNVzF9dYqwPFbyG7At0jABuNZcSWzlFDNbLym4oc0vnTsrUA==", "9c34675e-37ac-4019-b2af-7a4bce0d6b37" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-noura-alshehri",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "23ec96d7-0add-42f8-b5d5-3f5411cfe123", new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEK+8gBEM0oVMTTCybZ+jHVSvEef2bMwUsZmrRVDSDdZWlM/y9RCgw4bwtyTvp3acsQ==", "094fe2ac-a743-4613-8a81-3c015dc1b67f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-omar-aldosari",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5550e4cb-7821-4b55-b51d-dcc6464b7545", new DateTime(2024, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEE9OMJ8WZJxuUOYKphHoEYPq8cZfnPS1ghyig1INWAA33pJJA+YrAWjhKcX/ODRvdg==", "ed844113-ed2c-409f-bc15-5331554c0d36" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-raneem-alrashid",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6362565e-7fe0-42c3-a003-ece6938b694b", new DateTime(2024, 10, 30, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEPPm8yOH0WQYcvnpFnH1b/oMSa4jrJD1ZoNJfC8CDoNIBrB1HtWria8ScH0hlFolnA==", "592699b8-03f5-4ac2-9a4c-e695c7761ac1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-reem-almalki",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1fe14009-096d-40a2-9c5c-7c781c0f0ca1", new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEA4wkzLl0q7dDfhP7YhOopc1hbW0Ch66uwCmJMvGce/O5LyiKFDFTRJfzD9OcgvVYQ==", "c13c865e-dd3d-4f89-8375-be2344b99cd8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-saad-alharbi",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ecb154b4-b55a-46fa-894f-4e12732536eb", new DateTime(2024, 10, 24, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEKgIWf+iXqDXptSZjYZvENGwHUdWXcZUbVwhVQZOGVWqDjwuPjKgQjezKw1JlaEBNA==", "ef41c9f3-443f-464c-8912-8e92b20f3f11" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-sami-alomairi",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "65d5974e-f891-45ab-836e-b9290b22617a", new DateTime(2024, 11, 27, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEA04giMmiQ1CbUM5p3SIiedvezJ45cIP4IcE3Q2h11h91WSFbbrh7PpXIkO+BMJ/rQ==", "9d3e1b2b-7205-47ef-97a4-08d408553584" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-sara-alyami",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0e34249a-7e52-4ab9-ae72-1e38999cdbf9", new DateTime(2024, 11, 3, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEANwNGsRndTk+6oriTo+NwbIUIQ51UFlAuI0Za23RMhwB/f2bnhJuCZxUADN0TqR7g==", "3865fc73-8e67-4958-8968-e62a4df2982d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-turki-alsultan",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d97d8332-b6f7-4bea-a135-119979ef94bb", new DateTime(2024, 11, 8, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEFtWvQXtC2dcMcw1K37IzWmaSBc82e/3b83lGYhJIMp93IKskaCOSosAYsqeLqCPMA==", "0b225640-ba44-4118-ab18-8fcb09d2a83a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-waleed-alsaif",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c0b151c2-1075-42d8-80c4-2ec25fdd5ccc", new DateTime(2024, 11, 25, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEK8JCU6AQP0mEg88+b47+99li/I48DRvptQF55+6ZNw2SRymD5HGF1CtuquCya0rPA==", "6bdf80d1-14a9-430b-b079-8841be031e3b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-william-jackson",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6704303f-9d81-4046-b91d-19bd07cef0d9", new DateTime(2024, 11, 13, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEFa+88RaGgFM0CXbgxFTETUgwxjDbFJTP5lC1AEtJn9kR5j5cs1X0J30Y/r/QSw/3A==", "fa8d5ad2-201b-462c-a902-2b43b9e182de" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-yasser-alsubaie",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "63a0c8ce-64a5-4228-a644-739b6221fbdf", new DateTime(2024, 11, 26, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAELVAsGfaBbaNLVDBQE4PJ1ZEXhrgojvgmU1nbxgvFi+UMqMTJCnb8NAIPSWw2hzF+w==", "015fa3c7-8696-4b7c-afd9-99bb38118305" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientUserId",
                table: "Pings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FreelancerUserId",
                table: "Pings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-abdulaziz-alrashid",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d967f390-9e6e-4fd5-9ee1-54676aa0ca69", new DateTime(2024, 11, 23, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEE4U3g8fJMwZS5DefJtjwMasHg0N8G6OZWuvoBTI16kjBgFUxh49XU1Y8rztW0ryPg==", "dc028a40-2c6b-4f63-9e61-1edb0e2055fa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-abdullah-alsaud",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "628d27dd-9731-4262-96b3-8f80dc821b37", new DateTime(2024, 9, 28, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEDregud2cXtUe5RQdtSU76TZxB211OpG1yOMdQ8GGI5j+jTO9+N5Lc1CqpFU2NBfyg==", "fb487771-07ce-4a48-aefc-1d450a1b74fd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-ahmed-alshehri",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d21fd8c2-9220-4abb-b1b4-726a54b72d13", new DateTime(2024, 10, 8, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEMp9ESu245piBo0HCCcHuMu17gBzA5N9A3GypNO62j0WWJAKGbqufSA9NIJ02Zpdpw==", "7ff6ab26-d1a5-446f-8b0f-406809d431e5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-aisha-alqahtani",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "595ec460-7a82-4966-b48d-4c413ddae12c", new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAECVj7JfYqq/hN2yqv2DIjv/zA3KvhB+7rHdvx0MrpcqRXbAW87x+dzkaA8pZJq8uVg==", "2bc90fdf-35ab-40cb-8058-243ecc994d2a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-amira-alharbi",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "75a2e640-a2bd-4db0-a0bd-a01d608a1079", new DateTime(2024, 11, 6, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAECJ9eyS8d3znCa5RrWtIQb3Uydeu074BkJpBi0XxHmrUuNoH/CqB2L9UYkECTZ/YIw==", "2a856f55-de3e-42ea-9508-7a5dea5bc2d1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-andrew-anderson",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f48fa159-2c31-4ce1-ab50-2df72792e11a", new DateTime(2024, 11, 14, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEMrAmT6b3yNsqTdXhybHAuPAup+DvlT1N7Sja9UyZ6lS5vEQv8VmwP3/j1TDrwAhvg==", "2a401022-8115-494d-a49d-8e42edef0b56" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-asma-alsaif",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12083525-3917-4e72-b876-4fa36660eb44", new DateTime(2024, 10, 30, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEJtPiW9LREd0ni667LCBTUqW3FBoouBDh29qXTIj14sr45zzF2nnLgkZAuHy16bNDA==", "9893051d-ccd2-41e9-8105-aa1c361a9d6a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-bandar-aldakhil",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4f6e0f86-7a77-4315-8d30-44082d2f203e", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEMqtUIPHy0YtrYwRFD1VDFd/GFfDRFm/+IrykPVOsquR5ot45bMmT6cZk2IhlZd19Q==", "5faf5d0f-7cb0-428e-808b-b97603ab5cbe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-christopher-davis",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7313ab2a-3b9c-4881-bf93-597298215765", new DateTime(2024, 11, 17, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEEoEicLbs21lgtHwU890+KE2EYOYSi2UqOZ1JetdwxpGM3YwUdAoywXxIdm680niGw==", "d643397f-c696-440b-900c-14183605aac8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-daniel-taylor",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e5678be1-037b-4c5b-8990-c2917b6152d6", new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAELcn0xlqnbm0p1jdYbF6i4s2vVPyQ/fLsJfR2X/JjAyununzT3IIRZp8ZTwIEIVq2A==", "b8a2a697-4c87-4505-90f2-35295e7582f1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-david-brown",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8d8d00e7-09e1-4e76-83fc-93b3cc5da3dd", new DateTime(2024, 11, 18, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEB5KaMhcfWlkTTYFat+N9dnppT4gmKKI5Q2af+4si30yaVI19/xLiB3S+DLn3h8NyQ==", "e9859744-8364-4f5e-9adb-1a88fbd90b9d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-fahad-almalki",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c7dcb0d-45f0-4526-b436-ac3078bd80b4", new DateTime(2024, 11, 12, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAENnIVkf+ldLCYWNSVw2um1IJhaOT7EEBdAhURKUqWqKekXgak8i4GaDBSW2EOBTP3A==", "02dab3c2-7c05-46b1-bb14-79d5dd2e154c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-faisal-alotaibi",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ec72e198-35d3-452c-bd4c-8c93c90b39bb", new DateTime(2024, 10, 28, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEGfcgIRqJ/zbY8MLu2pLBBVvE9wk5hdixctretqI+561uX7TSmTcFdU6/cLPDIRrUQ==", "2bdf134e-cc7a-45db-986a-4eb690107a0f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-fatima-alotaibi",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "233846cb-b4c5-49aa-bf83-5f4c78903da0", new DateTime(2024, 11, 11, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAELntshBjP2zj/tHtMgFPvQiCAsoRCl7rJiAQ2qPVwX8LsOr7Id67dnIbJaYLCoxuSw==", "32051dc9-b33c-4af5-8ea2-e3958b7a20a4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-ghada-alsubaie",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6bcaf8a7-0a6d-4ec9-bc2d-7698fb3a3b34", new DateTime(2024, 10, 31, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEIkBwvlDoyTgCV+THnoAd5z3kbv0n8HAay1ml837XN2Bu5VYYXuT6JvRPa8GdqIvnw==", "a0d188e7-79e7-4bd6-9903-1e2699fc1ff1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-hana-alzahrani",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "63940290-7429-4d3c-8c25-3b40382e2a1f", new DateTime(2024, 11, 3, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEBwc1X+2cCh3wsFp5ENUt/hd2vsWiwcyxdl/d2H6LWY6bz6xw0Yq4bfvqxB9QR8AsA==", "ca08828b-2077-4611-85ce-8b04cb9298e3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-hassan-alzahrani",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d5201965-2101-4bd3-b73a-f71f34b73971", new DateTime(2024, 11, 17, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEBn6FNAvBox12b7cBKcZAj3QeCRMq2+fudh7iicuDZX+JrxB7ez8y4Wg2krT/QczRw==", "bc25e53c-0560-42bd-b639-3ee157f55b5b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-john-smith",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dbcb2405-2d58-414b-a9ae-c43ea2fde0df", new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEDgc23aFq6HnchiXK8BZYAJ9i/OcjIsxwCj5yo+mgTZ+WGbj8mFxatM/zZ200sHcAw==", "7005aa14-06af-4c90-af65-f8491cbc555e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-joseph-thomas",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cd7f1ff0-d38b-4519-8e18-c79c941192f8", new DateTime(2024, 11, 13, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEKlVgNooPhTRYdKLjJ64XxT7J7rhG7O2Fw/A7iqP2dZs/t3GvsQCHY6f817UtYAL1Q==", "a7459e66-6d61-453e-b19d-2a51ca2bb0bf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-kanaan-abukhadra",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3da47b8a-4c55-482b-8bf0-1ed859f55c73", new DateTime(2024, 11, 27, 15, 11, 1, 332, DateTimeKind.Utc).AddTicks(9200), "AQAAAAIAAYagAAAAEKmQPzKIqH9U45aCslTyHIjAkiT26GobHmo2HXflYbvOvj8lS/6/ZqDD0MtOVFz8cw==", "77447fe6-0258-4ae3-a4e2-bad1ba4f38e8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-khalid-alqahtani",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a819efa4-4261-4eaf-8040-f3fa4e61cb03", new DateTime(2024, 10, 13, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEMWof1Sq1hI24cN5kCSSwhwy7rDfKFS+JdhXdPGfpi68AwgYrj9WyNI2cZVCpJem4w==", "167c4977-5ea2-4521-b474-5e829144ec11" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-layla-aldosari",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "41095dbe-fc44-48d8-b864-bc2762d34594", new DateTime(2024, 11, 7, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEHjOIpO7HaX0rBjZeFkytwMs2YlfCiP5rqwo6536E23srDYCGLJDEgbFhOGs2n8b6A==", "4f770472-e6e8-4812-a535-6cb33633a937" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-lina-alomairi",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "28182837-f6ce-49a4-b8b2-6ebee9432135", new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEGT1ufb1C2/SNSCjzdgs6a9YL3HKcW2L0769EchGnB+AXgNmydU8HqM0i/nbVwUcSg==", "e10a98a7-9021-46ae-98a2-db9832e9ad46" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-majid-alahmadi",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "89a81239-704c-4354-8ac1-f4d101bb7051", new DateTime(2024, 11, 2, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEPK9SkRNj/P7dBdeX8O7pu+AjxfKd6ZHns4a9x6JR4S3ENWl+mSHEbZcxt8YSZsYiA==", "664821ca-8836-4770-9a55-9a25dd503bfd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-maryam-alghamdi",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5b4d466e-26be-44fe-834f-49d598417755", new DateTime(2024, 11, 8, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEAt2oFLD30ES+P7wigIYMaZsW/UplRsv6416kicwumRCoPLtYxpQXiQjpgeLAqth0g==", "ea4db40d-7997-4b15-8d2b-791d58d1aac2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-matthew-wilson",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "60dce398-a64a-4676-a4f4-429790594cea", new DateTime(2024, 11, 16, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEEUMeyfl+mf9Hm7+SBd2PK2WIn3hyOqA98eTzuiIZygbgaVaH9P8O3A53u136deFiQ==", "a1180451-2b75-4538-b2f7-228a0c563482" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-maysa-aldakhil",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68d0148f-60ca-48f1-8121-0e5bd363f391", new DateTime(2024, 10, 28, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEP96fJ4VDt15Ot4b4cTn7vUBJlh0anCykF5L473BEMABKsPVFGArRGsFq1XNHj8XCQ==", "2eb9c870-aa3d-44cb-bbf4-4f8cea391654" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-meshal-alfahad",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7d55a13a-9d07-4b6b-b413-7cf9d2c4e59a", new DateTime(2024, 11, 21, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEAel/uVIz4I7F2lS+c55PvEnlGpVhNQINpgn3ogoC2YaSZFgYSTFw6L7UjiQAU1e6w==", "692d4300-12c0-47d1-86f7-19c382507d59" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-michael-johnson",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "afb2e893-6ece-40f9-a9c7-c94acc38089d", new DateTime(2024, 11, 19, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAELJ6+ppNkytl8UOfyZLAkccc/rt4lIUOb+/JyClC6NsTfsMZ0tiIA3dT02OpNZugyw==", "a594d796-dea3-4971-9425-49648b761d2a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-mohammed-alghamdi",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d28c1f53-1a5d-4da8-a985-454e1ba090e6", new DateTime(2024, 10, 3, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEEqhuJFTOFKcAyrBsDROpTUKENUsc8bxa/sMbyYsfpfioSYiHweA8DqcNszTHo5RSw==", "898de29c-2ea1-4929-8ff1-6f3bfc2ff923" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-nasser-alyami",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad41a78a-5516-456e-b9da-8a1114888c07", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEHHWJI5atSq809NzBjfGbEJPoGewXzKiaM23cU5+DvBJtlUy9Gq9THqfygfxu4I1vw==", "04e500c9-f5fc-4d1b-a754-4f0fd325d106" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-noor-alsultan",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e1ce53f9-47dd-42ea-9618-adff8cecc3fd", new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEO7KtVIk82ho18Tr7QpIFe7dx8dvBYUjc18+ImnR1234BA5iaCmeXQYkwEeyHNEgKA==", "a677e936-4efd-4b43-a1a0-d11c00e51a55" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-noura-alshehri",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f862f85c-803c-4341-aa2a-3890992d0a1c", new DateTime(2024, 11, 9, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEPYJJgjyazywtv/x3A0fIFdWPb8ZBNa4irdp7A/RvElsc6bXkrVrckI2zGCaYqrJlQ==", "6f25d32b-4179-45a5-8dcd-b86461925adf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-omar-aldosari",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8346c125-305c-4b5f-beb7-90bdca2da1a7", new DateTime(2024, 10, 18, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEKiZaH/SEWYUuY4QD3aW6kMOnolNM9tUum/cejUTTCYWwmFDdKIb7UzlckD6Z18alw==", "0566f744-b78e-4a81-aab2-a6f6adaa4199" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-raneem-alrashid",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "99b451b8-780c-45d9-83dc-82ea4669bf48", new DateTime(2024, 10, 29, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEJDOM8vimntNYevoXcKPAvQsNi/AhUh9SoC3bXiGb+jcjYYJ34G4CmCW68dfmXbgOg==", "27d9f565-6b2c-4cf3-9cb6-6fe3a22d629f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-reem-almalki",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "151b1d80-4249-42fc-8b84-cd63a081467f", new DateTime(2024, 11, 4, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEH7oWf68a2xyGoIPm3bbQKPovr5LxdFoXD/Bg2VY6yHauLgNsa80P0NoUtJrg0bq+Q==", "3481c1e6-f908-462b-b78c-551e75d7c229" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-saad-alharbi",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aacf8d6a-795e-4b55-a0ba-37346865ebbd", new DateTime(2024, 10, 23, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEGwc1PrmADY6JRso99XA+vR3du+uCf7r6DCzqQhJ5tkjBeVTF3libdcFh69PaB5o7g==", "76f4cd30-8f54-4daf-ac10-00508015350b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-sami-alomairi",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a3e68ed9-55b5-4667-b2ae-8c61a6525f12", new DateTime(2024, 11, 26, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEFYWyHwioohpJl1Nl2hbvOhlrdebIFmTqsbzNyiMyyVAcTqHhYoO/E3tAjWKH2JsMQ==", "19ebfd4e-fb4f-40ac-9037-3fef8a992f1c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-sara-alyami",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c9a9154-ba84-4a12-b795-68aa07f7839c", new DateTime(2024, 11, 2, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEHXpUekv0q6BuCcTj8xQ27ZFKxz6IkkjUn97TVBTtx00ZZUMFcM3D/ax1BTFZp9SHw==", "56eea0e1-f94a-4760-88f0-72e8e4abf9d4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-turki-alsultan",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2786f272-fa1c-40c5-87ab-d1414ad627be", new DateTime(2024, 11, 7, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEHvlf46RPLrX7H4MCyiIhlwe/VbK4kG8dFCTRNMqHaYyxIDCwc2Cfv+MB8AP5C8+1Q==", "a10ebb7c-6e84-413d-95e7-552d83be65db" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-waleed-alsaif",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f26d38f-4564-49bb-bb7f-876ecf1adc3a", new DateTime(2024, 11, 24, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAELEHaU+NirWPMOYuzMUYkFHjGVIk2+VS3LAtoiF2/YpGHeGn472UBka3OHEGzmp1lg==", "bde1b9b7-409e-4bcd-9b24-553aad8dc9b5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-william-jackson",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "47d31be5-63d3-41ca-a57f-df5d4e663a4e", new DateTime(2024, 11, 12, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEK1wqvtzggNvpu7yE0gDtCvhzL54kZBn5vE0+Lx9xgYcFx14YO0itOHH3s8qj5qKMQ==", "b0969a6c-2e4f-4384-b604-e7fb8edc51f0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-yasser-alsubaie",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ab9e6f01-2576-424b-802c-50913079f1fe", new DateTime(2024, 11, 25, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEEUoWQoCMWpFvsvAAmjPrupRAREc5tsmtOSI9PEzi0m1F4w8Pdo4YQZ+6bEZqBvrtg==", "98afe3d0-8882-4bef-93b0-fdde83b8f177" });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FMA.Application.Migrations
{
    /// <inheritdoc />
    public partial class AddedNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "HoursContracted",
                table: "Contracts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "FreelancerEmail",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "AmountPaid",
                table: "Contracts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ClientPhoneNumber",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-abdulaziz-alrashid",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12e593e5-3bc7-4531-b134-9798fbcf8cbe", new DateTime(2024, 12, 3, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAENBY/TmAdbStX0RgVVT3zJsFz0iBUjk99zvssVCUiRP59dIx8QzY8kxFO3XcYfGYrg==", "cd8f2baf-c8aa-4552-bbb2-39ce52899871" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-abdullah-alsaud",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "030b7867-a694-4fcb-9fe1-c94b46e02fbc", new DateTime(2024, 10, 8, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEDaoxnjeaf/4dusTcXf6fjEDbN2Dcwdh//4giiiTPRNVRUu2/mo7mqHJNNcwSe6zEQ==", "85224dc9-d5a9-4194-8526-51efcedf42d5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-ahmed-alshehri",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad4115c9-c21b-4c87-94b9-24754faa721c", new DateTime(2024, 10, 18, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEBxWX/t0C8gqpfecc1GQ5bDZ64nwXied/uvc4nxSF5FoX6cU9a0ksRVh6IhvZ4pcVQ==", "ec686142-cad6-46ad-a3da-9f6c6c43b692" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-aisha-alqahtani",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c141e694-c6fc-4049-859a-850bc6e3470c", new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEPHgtQN9uLockV5WJSoksAbLY1HdXzqmGXQc4UwHvPPUuA2WN13EvBZVU+Sdt/F5kg==", "0d225e35-bbfd-4199-b23f-a3a1d625dab3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-amira-alharbi",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c85c198-6e74-4895-b5bb-76c9bf4b99c9", new DateTime(2024, 11, 16, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAECBKKdWTboA3NnNdhZWnfm8uzRDRAsOL4MrlsEHMhokgLx5dL9el+ec2Pxr8nGSq9Q==", "3557ecfa-8205-4ef3-948a-31131e72416e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-andrew-anderson",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f59a2ebb-1700-4eb3-b3ac-85f410529eb5", new DateTime(2024, 11, 24, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEJZ5m0sZcwFlAYACjv13kLivzohpVhiP6cc22S4yxxiAwq/rEDCmq1s2Zc1CwqvdYg==", "b70db703-fcd7-40e1-baa1-b700690b20ed" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-asma-alsaif",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4e75511e-bf00-41a1-b5fc-97ce9fe97f53", new DateTime(2024, 11, 9, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEH/xgxoUarQ9CKRMxBZp9GKpWL9DeH1eY5uogSHLZkysql8luQeKB4EBtePtcPGffg==", "aeed6377-373b-449d-bd57-cb28226f7047" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-bandar-aldakhil",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d459af1c-9820-4d26-be0d-97c294ef3835", new DateTime(2024, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAECzRg/9Ip12ftKS6qoFr1ikk+OIM1NINKi9zF0/Jl77EOzZns7EDS1TozQVJr8iRbg==", "7082cc15-d980-430b-b05c-920926917dc3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-christopher-davis",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d56884ce-ab1a-429d-b082-6863b25050e1", new DateTime(2024, 11, 27, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEGfC6TPy7wvX2hY4oyrY6/CYzYqV+gckMHrCdydvF6hCoQzG4Hww05RBdjP8wnGlcA==", "2f4c5a9b-7b70-407c-8253-1100ea1f772f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-daniel-taylor",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "929b9bbd-38a3-4303-a1ec-2ba738025d2d", new DateTime(2024, 11, 25, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEK9CMAZY9oem94Nyn6wr3SiRAKlL8BOBskgLAxK0i22ah+nm8M/8JDoXtM7RzPgz0w==", "1a7688b9-345d-4e62-b576-9b7dba25f965" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-david-brown",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a10469ab-4ea0-4933-a3e7-fd44c0e0d17b", new DateTime(2024, 11, 28, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEO7bUg55BMUoXxfyCIK0Bn/Cut14ARG/3adBojKC9U315dSEt8uHrKIsOGUQfVuiyg==", "bf5051bc-13d5-47f9-8eb5-af8c469334ac" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-fahad-almalki",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2d431776-2cf5-42e2-bfb6-34e5027128b0", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAECiGa9YscOCVxDVKNxZ3/X6K1nqvsHqajXdO8ZmjMCd6ZFIWydwJdtkjAZzT39b07w==", "bce6edb6-69d9-4b94-b858-c37761777a51" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-faisal-alotaibi",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a5ac9582-dfab-4a23-8fd8-5979d327a939", new DateTime(2024, 11, 7, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEBXPAYB7jWUTXElAY8vMokdsxRuQZOkAvx5kFS9PKayzmZ9eH+XVMSfGZrbNSXS4vQ==", "263ae717-e842-4280-ad8f-a9e1eaa0101f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-fatima-alotaibi",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5757bea7-4da1-4211-9fc8-0f109f8b872d", new DateTime(2024, 11, 21, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEHS7cwESZaCCUrwHlr+bEOxCqMmEnotffDdneYT1fijiWyz0Jtpb4aiKpwHyveva/A==", "22384e3c-7da6-4c04-a7e3-f61e10849866" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-ghada-alsubaie",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9b93a8c9-1b65-4b70-89e4-b988c026c393", new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEK8k8aveh79mPuYXmWs7wXH+TvoPk8PlwN3iTBE5s7Jm7FhIQqPk2oXwfbUqmy2w2g==", "34207f25-01cb-49f0-8b21-997b799c526a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-hana-alzahrani",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "30c7fa9f-9e82-40f7-b66e-37d0aeabc537", new DateTime(2024, 11, 13, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEAyvgP3r0T1ldVYiUeo+F5L21GE6+XKEeEZ8dQ9bnhSsYGpw2U9xoniO14WgrlWFyw==", "6e77121f-ee2c-4e5c-bafd-40e81f21402f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-hassan-alzahrani",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ebefc9df-b854-4b1f-9795-ba3605665b9c", new DateTime(2024, 11, 27, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEByPGJUS3zB4CwzEf+MJlees9pRJYMPBPvj2FsTSYTcC5Zz14a6Vy3y9lsuEOwdSGA==", "e2045bb7-2b12-43f1-ac85-197019663eff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-john-smith",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "371488fc-4320-44fd-92e4-e571499cca9d", new DateTime(2024, 11, 30, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEBvImzyXM093NzPq46ajteoQfAPoGiTUJCh6X/zi877F0Ek3uXQ1zMU8XgY7sz7ITA==", "8d9189b6-9e0d-48c5-b2e4-8135d5a0a6f8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-joseph-thomas",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ca768b36-f906-4e11-849d-70840530c066", new DateTime(2024, 11, 23, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAED5Z01haomZpeVoZVR4B27lPUaG8Zua5s3eSyAVBiJY/3DQqrjCNMnrlYf0TfU5Oyw==", "1327da22-c235-4835-83d1-9eb0479d9a44" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-kanaan-abukhadra",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2c16a9aa-0bbf-47cc-b49e-de069c0fbfb6", new DateTime(2024, 12, 7, 7, 56, 20, 304, DateTimeKind.Utc).AddTicks(5090), "AQAAAAIAAYagAAAAEPQTWITUsxs7Qh1xm82iUr84gyjyy3uNghkVST5I2e0p7BCanLGyGWxrr+RXBKQAtw==", "2e005705-7a25-43c8-9fc8-748a0556ebc3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-khalid-alqahtani",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "61eaea9f-18cd-477c-a2ae-3e37bcde387a", new DateTime(2024, 10, 23, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEIyqBEmlrUyTk2d6iYOce+yjY/1T+3PYGRtUxc2JezCBfsov8pFXqUgKqljFNk3i1w==", "0547d77c-63d1-4bde-bc36-38d6052c642a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-layla-aldosari",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "45457730-a970-47c6-9b35-6636e86f2e71", new DateTime(2024, 11, 17, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEIOjsyW3boIqDp+LKnZueWpRkL+iVU4UQImGNWd29XHzv4nOBUYgv5wWIuu5HagvSw==", "76afdaa2-41ba-4198-a697-23dc6ff1f55b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-lina-alomairi",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "55e5f4ee-61c8-459c-b16b-3c023f37e50b", new DateTime(2024, 11, 11, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEMLik3v7LS8V1LeXBWpEV1rIh2MHmgYi5kimsPAKNnS6Xy+SCp5UuIful78g9v6zLA==", "242c3dc6-b717-4014-8346-c01fb2cc856e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-majid-alahmadi",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5559a504-50ec-47c1-8e14-eb5fa7020c30", new DateTime(2024, 11, 12, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEI7jW4vmPmVrmCjPxIH4oBFQv1SpMp0Qs88mN/R8d7Y0BHFYK0XvDzQ43WMTsZo2Dg==", "15077dca-50a1-4e9f-bf43-c0668d7fb0b9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-maryam-alghamdi",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "28d0c2d9-74e2-42d2-a377-b7ff269a7112", new DateTime(2024, 11, 18, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEEkKWjyG+C+T8miVmTSwD8Pht/TP0sx+GKKmrqC6sKNBUqsPffF8rzYIGax6fxg92A==", "26c6415f-35b6-4920-9003-6e975b4221a6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-matthew-wilson",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e52f6b04-d528-4870-8bc3-954328e24c13", new DateTime(2024, 11, 26, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEDUU+OjfMw6jiyUMzKgIQ/x1AQHb51vUNxZbF74uWQIbM1D3fodFi1V1ucjYTPYW0A==", "1edfc43d-38b5-445b-97b9-95638606c092" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-maysa-aldakhil",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "67b70196-ce97-4154-817d-b1ff3224bd27", new DateTime(2024, 11, 7, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEAJj5mBvsslRvcKRKWVmlMjcgfucK+IrN4u9QmmxQq3XP/SBQxkBE9cVRbDbOLh6BA==", "8102d53a-d7cb-4405-b269-cb58f1ef31d1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-meshal-alfahad",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e5f94d2-4801-45c8-a9f0-a579324ea95a", new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEJEZRfz9ZD7F283NF6Q76ZSITsJw8oaxadH4pzhvGms5q12O4AlHuKJd32HkiJsZRg==", "e0ae5acd-84c0-4ef6-a93d-153ac645ab86" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-michael-johnson",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a3d89bf1-d84c-4f39-aa69-d725d954cbca", new DateTime(2024, 11, 29, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEBQP04fL+LghnuL1adu3R4fZV/pOwZKxIzcc3q42PXdMo7ccsnu9OCBkY00XqOlwCw==", "b22d6732-86d3-4a87-861f-ff1797f7a3dc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-mohammed-alghamdi",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0a01f506-c21d-4a81-8990-eebd594460cc", new DateTime(2024, 10, 13, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEMc7DoujMJiumrkxeiX94jFOKYClexMaWdzyVx8kiL/rPRPvI2GLk71n2spmO5uqWw==", "4306a686-5d4a-4e20-be5a-692fd4e892ec" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-nasser-alyami",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2038133b-cb05-4d65-b733-c478ed68145c", new DateTime(2024, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAELn1edzU3tVt1FlMxYl8kwdiCkZ9Gl+N8DVF2SwEPaInrEEZAF6lJUi7kty8mMG64Q==", "93405896-5a00-43a3-912b-c4b37481301d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-noor-alsultan",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc2e3587-4944-4afc-8c91-62ce9d489ef2", new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEASuLntJld0qj/0VGauM7xcGBk1jU1LfYY+TOsryoSaoaNqbT4Qu2vfRNQq3CFCUaw==", "b6b811df-b341-4be3-94e7-c876b9cbfcde" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-noura-alshehri",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c897262-0eab-4b70-8386-284ec9a0bd28", new DateTime(2024, 11, 19, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEDoMPW2XE0oUoDKB9zNeaIeAG+qsgBAundTbuWy+VOFYUlMUU/b1joScQUVm0+Iz9A==", "d796db1c-c6be-48e2-8617-46ba37ecaed2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-omar-aldosari",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "98c42b15-df77-4d5a-adf6-45e291463be5", new DateTime(2024, 10, 28, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEAGQvMEK5Ks+c7MRFw+TlM0WYcMZn7eUNkhD0DmneqBj4jpIv5RgQgSQ1t/IXgFbEA==", "b0dad44e-4d16-4547-947b-1bfd984fd80e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-raneem-alrashid",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bd6be8e5-5ec3-43f1-abba-72507a07b400", new DateTime(2024, 11, 8, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEKzhR+/hOIY6j6KmpNu2w8rnoobAO1Y+sLhrKuAzduWULTJYbbw7OtEOT6Ibp8ECTg==", "6c8dc617-2beb-4f5c-a26e-1f81b59a8938" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-reem-almalki",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fdb43a6a-1adb-4b3d-9a59-3089bc83cfcf", new DateTime(2024, 11, 14, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEKNmbR1C4ij1maQsjcNhqj4ttgvL7o3lMat2ObOdh/x2Bwevcy823h6P1WLYiJYWNQ==", "cb910f49-650b-4d59-ad46-f83343ce7e07" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-saad-alharbi",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f15ccde3-e7e0-4d16-8053-7a5cb0f0c037", new DateTime(2024, 11, 2, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAELEw6Pwi/oIPIOYbmY9x5pXe+Y7uW5Ek/69VN5RypYApYVzeE0Al0ZeQge78bIt3Ww==", "fdb930b9-e721-470f-917d-db33b3180313" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-sami-alomairi",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa3dc734-2da4-49b2-a714-8b446a53b08b", new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEDyLeSXbV2sSnXFysPLuvvOM96fS1gpCiACFzm/mThPR7DZWa1qbFps964Ks6th3Bg==", "811a7c6d-44ac-42c5-80ee-13e8924376e5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-sara-alyami",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "130f07f9-336c-4b50-ab2a-480fc13147e9", new DateTime(2024, 11, 12, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEGbLuHWV5Z7iP6m3ZvXYI0AA3phI5Bvn1DN6gOaka3XigCfxOjjYb2VfOd3jwJcd4A==", "9a55dfa8-a30a-4a0d-a52e-94b81aa5239c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-turki-alsultan",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c833bc8a-d6b2-4f93-b8f3-17bbebd8ff30", new DateTime(2024, 11, 17, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAELDE23yRdj61YIEJFgVIvXx7P9y/HieUHT4XAmO85loQsPQDIs0VmmBl6E/J1t6OdA==", "fc7384d6-4855-4b41-a11d-40fd293f3e86" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-waleed-alsaif",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5793109d-23c9-4ae4-adf8-95358b085dbf", new DateTime(2024, 12, 4, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEBdQqW2sOkFtW3KY2V6F/UAIkIFSyuXZCPywJhcR87XvlPAuLlCW9r2T6LGdbpk9Dg==", "a52cc83b-3b9e-4bfc-a642-cf48ab222763" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-william-jackson",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "74637c4c-b4e9-403e-9c91-9d53b9ffc00e", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEHtVsqW5VhaEsMifDOCSdxSnOONTUAzWy3JOrIU8HF6n7jTKJ4wrGIf5Nocb9lcrMg==", "998133bf-f01a-43b6-ba46-09deec94f58a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "id-yasser-alsubaie",
                columns: new[] { "ConcurrencyStamp", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1a6817e2-c040-4e59-8710-66785eb475ed", new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEKiGU+0ycbri3rw9Bm2Kt+vq5c/dQ/aOd5bbkqPmtiCOdz1a25i5zHf1cFnHEMgYfQ==", "88ad17bd-329b-438b-9286-3539c2824440" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientPhoneNumber",
                table: "Contracts");

            migrationBuilder.AlterColumn<int>(
                name: "HoursContracted",
                table: "Contracts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FreelancerEmail",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AmountPaid",
                table: "Contracts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}

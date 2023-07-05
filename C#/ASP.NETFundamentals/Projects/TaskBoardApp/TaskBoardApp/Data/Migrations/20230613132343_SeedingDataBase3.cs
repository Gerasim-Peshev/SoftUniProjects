using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class SeedingDataBase3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9848ff8f-df2e-4d1f-9ab9-985d0f2738a9");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e8e41f2d-fbba-434e-b343-e30aa1746ab5", 0, "35434d5d-1547-4277-9da8-5056a2fea872", null, false, false, null, "TEST@SOFTUNI.BG", null, "AQAAAAEAACcQAAAAEHUfJx+8TolEmND6znIvj3Yrz1NdrSM6RlLKg0FbpwxIfOWalSt+h0AO9QrxTcIgiA==", null, false, "11c59b3f-e629-4aea-9b9a-d5830182c051", false, "test@softuni.bg" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2022, 11, 25, 16, 23, 42, 829, DateTimeKind.Local).AddTicks(3529), "e8e41f2d-fbba-434e-b343-e30aa1746ab5" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2023, 6, 8, 16, 23, 42, 829, DateTimeKind.Local).AddTicks(3568), "e8e41f2d-fbba-434e-b343-e30aa1746ab5" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2023, 5, 13, 16, 23, 42, 829, DateTimeKind.Local).AddTicks(3571), "e8e41f2d-fbba-434e-b343-e30aa1746ab5" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2022, 6, 13, 16, 23, 42, 829, DateTimeKind.Local).AddTicks(3576), "e8e41f2d-fbba-434e-b343-e30aa1746ab5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e8e41f2d-fbba-434e-b343-e30aa1746ab5");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9848ff8f-df2e-4d1f-9ab9-985d0f2738a9", 0, "ee832f67-93f4-4de1-a25d-a30d33dc6867", null, false, false, null, "TEST@SOFTUNI.BG", null, "AQAAAAEAACcQAAAAELYeB9i5gZDXiBIjMlmFSSD1hSa7stCiwqlbpyH2Ib9qOzJjhJAqEyay6Al1JwJH3w==", null, false, "0f3005cc-dd67-47f6-8cf7-820b70490ebf", false, "test@softuni.bg" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2022, 11, 25, 16, 21, 45, 462, DateTimeKind.Local).AddTicks(2866), "2a3a1c9d-7f55-4f28-b7b5-1e7921248057" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2023, 6, 8, 16, 21, 45, 462, DateTimeKind.Local).AddTicks(2904), "2a3a1c9d-7f55-4f28-b7b5-1e7921248057" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2023, 5, 13, 16, 21, 45, 462, DateTimeKind.Local).AddTicks(2906), "2a3a1c9d-7f55-4f28-b7b5-1e7921248057" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2022, 6, 13, 16, 21, 45, 462, DateTimeKind.Local).AddTicks(2909), "2a3a1c9d-7f55-4f28-b7b5-1e7921248057" });
        }
    }
}

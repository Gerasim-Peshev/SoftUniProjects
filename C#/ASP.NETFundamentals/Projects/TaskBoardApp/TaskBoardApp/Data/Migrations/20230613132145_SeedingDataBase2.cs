using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class SeedingDataBase2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83ff5856-8a7f-4c4a-9c4b-189cbd545670");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9848ff8f-df2e-4d1f-9ab9-985d0f2738a9");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "83ff5856-8a7f-4c4a-9c4b-189cbd545670", 0, "e5e240bc-fe07-4443-900a-ad317dd6f0a8", null, false, false, null, "TEST@SOFTUNI.BG", null, "AQAAAAEAACcQAAAAEAzbgmig5BbVj9MgwcmACIMpX0UQNVbq2Pf3uyThHnyRpMQ4DOcJa22Z2c95rlz15w==", null, false, "a8fd4231-35bf-4b50-95bb-955448936618", false, "test@softuni.bg" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2022, 11, 25, 16, 13, 25, 225, DateTimeKind.Local).AddTicks(8075), "83ff5856-8a7f-4c4a-9c4b-189cbd545670" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2023, 6, 8, 16, 13, 25, 225, DateTimeKind.Local).AddTicks(8109), "83ff5856-8a7f-4c4a-9c4b-189cbd545670" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2023, 5, 13, 16, 13, 25, 225, DateTimeKind.Local).AddTicks(8111), "83ff5856-8a7f-4c4a-9c4b-189cbd545670" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2022, 6, 13, 16, 13, 25, 225, DateTimeKind.Local).AddTicks(8116), "83ff5856-8a7f-4c4a-9c4b-189cbd545670" });
        }
    }
}

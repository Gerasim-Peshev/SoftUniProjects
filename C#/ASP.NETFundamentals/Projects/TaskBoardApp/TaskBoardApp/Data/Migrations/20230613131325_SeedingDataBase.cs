using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class SeedingDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "83ff5856-8a7f-4c4a-9c4b-189cbd545670", 0, "e5e240bc-fe07-4443-900a-ad317dd6f0a8", null, false, false, null, "TEST@SOFTUNI.BG", null, "AQAAAAEAACcQAAAAEAzbgmig5BbVj9MgwcmACIMpX0UQNVbq2Pf3uyThHnyRpMQ4DOcJa22Z2c95rlz15w==", null, false, "a8fd4231-35bf-4b50-95bb-955448936618", false, "test@softuni.bg" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "In Progress" },
                    { 3, "Done" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 11, 25, 16, 13, 25, 225, DateTimeKind.Local).AddTicks(8075), "Same", "83ff5856-8a7f-4c4a-9c4b-189cbd545670", "Improve CSS styles" },
                    { 2, 1, new DateTime(2023, 6, 8, 16, 13, 25, 225, DateTimeKind.Local).AddTicks(8109), "Same as second Title", "83ff5856-8a7f-4c4a-9c4b-189cbd545670", "Android Client App" },
                    { 3, 2, new DateTime(2023, 5, 13, 16, 13, 25, 225, DateTimeKind.Local).AddTicks(8111), "Same as third Title", "83ff5856-8a7f-4c4a-9c4b-189cbd545670", "Desctop Client App" },
                    { 4, 3, new DateTime(2022, 6, 13, 16, 13, 25, 225, DateTimeKind.Local).AddTicks(8116), "Same as forth Title", "83ff5856-8a7f-4c4a-9c4b-189cbd545670", "Create Tasks" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83ff5856-8a7f-4c4a-9c4b-189cbd545670");

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}

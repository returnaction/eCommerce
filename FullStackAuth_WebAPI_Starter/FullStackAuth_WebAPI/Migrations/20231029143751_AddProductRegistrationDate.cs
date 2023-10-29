using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FullStackAuth_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddProductRegistrationDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f4a5ab0-7a6e-4366-b38b-5d2256587549");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93fa4cbe-9c4f-4bf2-ab8a-fd5032f3469b");

            migrationBuilder.AddColumn<DateTime>(
                name: "ProductRegistrationDate",
                table: "Products",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3ef10428-4679-49b3-965d-509697efa958", null, "Admin", "ADMIN" },
                    { "8e2f47fe-1191-472c-8ae3-6ce02d88b160", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ef10428-4679-49b3-965d-509697efa958");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e2f47fe-1191-472c-8ae3-6ce02d88b160");

            migrationBuilder.DropColumn(
                name: "ProductRegistrationDate",
                table: "Products");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8f4a5ab0-7a6e-4366-b38b-5d2256587549", null, "Admin", "ADMIN" },
                    { "93fa4cbe-9c4f-4bf2-ab8a-fd5032f3469b", null, "User", "USER" }
                });
        }
    }
}

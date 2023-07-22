using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IkApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig_6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "26b60e55-b330-40b6-9134-55314b386836", null, "Admin", "ADMIN" },
                    { "b9a2ab75-6c52-45ef-8fa2-482d4c372f9b", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                column: "Id",
                values: new object[]
                {
                    "26b60e55-b330-40b6-9134-55314b386836",
                    "b9a2ab75-6c52-45ef-8fa2-482d4c372f9b"
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: "26b60e55-b330-40b6-9134-55314b386836");

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: "b9a2ab75-6c52-45ef-8fa2-482d4c372f9b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26b60e55-b330-40b6-9134-55314b386836");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9a2ab75-6c52-45ef-8fa2-482d4c372f9b");
        }
    }
}

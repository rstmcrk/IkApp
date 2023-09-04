using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IkApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig_12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4afa7d75-33a6-489f-97f3-b61ebc1bda5c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa4a80d5-1bb7-4a76-b4f9-c3f5e40562b0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "11a9b76a-d770-4a6e-8364-beb2d06c1faa", null, "Admin", "ADMIN" },
                    { "55031975-a547-4246-b776-739e32706d30", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11a9b76a-d770-4a6e-8364-beb2d06c1faa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55031975-a547-4246-b776-739e32706d30");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4afa7d75-33a6-489f-97f3-b61ebc1bda5c", null, "Admin", "ADMIN" },
                    { "aa4a80d5-1bb7-4a76-b4f9-c3f5e40562b0", null, "User", "USER" }
                });
        }
    }
}

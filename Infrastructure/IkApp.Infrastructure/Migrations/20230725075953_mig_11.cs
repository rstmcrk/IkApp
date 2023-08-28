using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IkApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig_11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c0c18d0-2a17-4ea3-8f4f-834ae5fc9d5a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f854a25e-f61e-4f99-8f1a-1a127b9d9d22");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4afa7d75-33a6-489f-97f3-b61ebc1bda5c", null, "Admin", "ADMIN" },
                    { "aa4a80d5-1bb7-4a76-b4f9-c3f5e40562b0", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "9c0c18d0-2a17-4ea3-8f4f-834ae5fc9d5a", null, "Admin", "ADMIN" },
                    { "f854a25e-f61e-4f99-8f1a-1a127b9d9d22", null, "User", "USER" }
                });
        }
    }
}

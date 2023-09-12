using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IkApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig_29 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ecc7024-6aa5-47f9-8071-745e8335ebf7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0e63500-a387-48ab-8f25-29c5935554b4");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "DayOffRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cf9d5637-eac9-46d2-a129-4f811b6322bf", null, "User", "USER" },
                    { "dd27326a-bc9c-4cd5-ae30-45e593e3b339", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf9d5637-eac9-46d2-a129-4f811b6322bf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd27326a-bc9c-4cd5-ae30-45e593e3b339");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "DayOffRequests");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0ecc7024-6aa5-47f9-8071-745e8335ebf7", null, "User", "USER" },
                    { "f0e63500-a387-48ab-8f25-29c5935554b4", null, "Admin", "ADMIN" }
                });
        }
    }
}

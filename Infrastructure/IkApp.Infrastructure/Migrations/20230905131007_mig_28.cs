using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IkApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig_28 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c81a2a3-1cd9-476a-8df7-80a96fb65f10");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f4d25ed-fc91-4cbd-8652-2e458a613903");

            migrationBuilder.AddColumn<bool>(
                name: "Approval",
                table: "DayOffRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0ecc7024-6aa5-47f9-8071-745e8335ebf7", null, "User", "USER" },
                    { "f0e63500-a387-48ab-8f25-29c5935554b4", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ecc7024-6aa5-47f9-8071-745e8335ebf7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0e63500-a387-48ab-8f25-29c5935554b4");

            migrationBuilder.DropColumn(
                name: "Approval",
                table: "DayOffRequests");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1c81a2a3-1cd9-476a-8df7-80a96fb65f10", null, "Admin", "ADMIN" },
                    { "4f4d25ed-fc91-4cbd-8652-2e458a613903", null, "User", "USER" }
                });
        }
    }
}

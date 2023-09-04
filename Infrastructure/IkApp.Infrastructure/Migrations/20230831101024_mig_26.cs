using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IkApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig_26 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1431c2f0-f027-4685-b767-5ca64481e450");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d82ade3-6bbd-4527-91c3-5a310526612b");

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
                    { "1938833b-1e0e-471a-9f42-f317e93a7d8d", null, "User", "USER" },
                    { "d9eb9bb0-0300-4490-8cd3-2afcfbf5993d", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1938833b-1e0e-471a-9f42-f317e93a7d8d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9eb9bb0-0300-4490-8cd3-2afcfbf5993d");

            migrationBuilder.DropColumn(
                name: "Approval",
                table: "DayOffRequests");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1431c2f0-f027-4685-b767-5ca64481e450", null, "Admin", "ADMIN" },
                    { "2d82ade3-6bbd-4527-91c3-5a310526612b", null, "User", "USER" }
                });
        }
    }
}

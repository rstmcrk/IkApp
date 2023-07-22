using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IkApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig_7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26b60e55-b330-40b6-9134-55314b386836");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9a2ab75-6c52-45ef-8fa2-482d4c372f9b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "421be73b-e0d8-4924-b3dc-f8e36b64394a", null, "User", "USER" },
                    { "79a2bc2c-abf5-4a13-991f-ce0c84ce4937", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "421be73b-e0d8-4924-b3dc-f8e36b64394a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79a2bc2c-abf5-4a13-991f-ce0c84ce4937");

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRole_AspNetRoles_Id",
                        column: x => x.Id,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
    }
}

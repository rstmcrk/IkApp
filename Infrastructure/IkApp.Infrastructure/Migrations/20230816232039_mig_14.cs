using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IkApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig_14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Users_DepartmentUserId1",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_DepartmentUserId1",
                table: "Departments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c5bcd05-f983-4336-ae43-6f991e18f2bc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2ab59ac-18fc-4b2b-855d-ce997dcf66fc");

            migrationBuilder.DropColumn(
                name: "DepartmentUserId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "DepartmentUserId1",
                table: "Departments");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b69da0e4-b752-4814-b1b1-65cf12d70ef5", null, "Admin", "ADMIN" },
                    { "e9af1bb5-1d0d-4f51-ae16-c52ac11d3005", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b69da0e4-b752-4814-b1b1-65cf12d70ef5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9af1bb5-1d0d-4f51-ae16-c52ac11d3005");

            migrationBuilder.AddColumn<string>(
                name: "DepartmentUserId",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DepartmentUserId1",
                table: "Departments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1c5bcd05-f983-4336-ae43-6f991e18f2bc", null, "User", "USER" },
                    { "e2ab59ac-18fc-4b2b-855d-ce997dcf66fc", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DepartmentUserId1",
                table: "Departments",
                column: "DepartmentUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Users_DepartmentUserId1",
                table: "Departments",
                column: "DepartmentUserId1",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}

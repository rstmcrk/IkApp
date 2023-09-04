using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IkApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig_13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Users_DepartmentUserId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_DepartmentUserId",
                table: "Departments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11a9b76a-d770-4a6e-8364-beb2d06c1faa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55031975-a547-4246-b776-739e32706d30");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DepartmentUserId",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "DepartmentId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DepartmentUserId1",
                table: "Departments");

            migrationBuilder.AlterColumn<string>(
                name: "DepartmentUserId",
                table: "Departments",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "11a9b76a-d770-4a6e-8364-beb2d06c1faa", null, "Admin", "ADMIN" },
                    { "55031975-a547-4246-b776-739e32706d30", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DepartmentUserId",
                table: "Departments",
                column: "DepartmentUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Users_DepartmentUserId",
                table: "Departments",
                column: "DepartmentUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

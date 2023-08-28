using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IkApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig_18 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "101c3519-e1ec-4731-bbec-583ca966d9d3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4269c8eb-f5a8-4682-9072-3be736da4347");

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                    table.ForeignKey(
                        name: "FK_Departments_Users_DepartmentUserId",
                        column: x => x.DepartmentUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "67c930c9-ef64-416c-ab42-5844c8ac10ca", null, "Admin", "ADMIN" },
                    { "7807dee5-1fb9-4de8-b1ee-75ac47fdb69b", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DepartmentUserId",
                table: "Departments",
                column: "DepartmentUserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67c930c9-ef64-416c-ab42-5844c8ac10ca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7807dee5-1fb9-4de8-b1ee-75ac47fdb69b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "101c3519-e1ec-4731-bbec-583ca966d9d3", null, "User", "USER" },
                    { "4269c8eb-f5a8-4682-9072-3be736da4347", null, "Admin", "ADMIN" }
                });
        }
    }
}

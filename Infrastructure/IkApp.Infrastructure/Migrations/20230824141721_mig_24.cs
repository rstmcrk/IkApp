using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IkApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig_24 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_BoddyId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_BoddyId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bae103b8-223b-493f-ac80-ca99e1ca44b9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d15ddb9b-fd03-4bf1-a087-1c810d08017b");

            migrationBuilder.DropColumn(
                name: "BoddyId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "DayOffRequests",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermissionDetail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DayOffNumber = table.Column<float>(type: "real", nullable: false),
                    PermissionStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PermissionEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayOffRequests", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DayOffRequests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DaysOff",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RemainingDayOff = table.Column<float>(type: "real", nullable: false),
                    DayOffAssignmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DayOffAssign = table.Column<float>(type: "real", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaysOff", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DaysOff_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "add90408-0d0e-4fec-b37e-ecf7ab355130", null, "Admin", "ADMIN" },
                    { "b20ad2ea-4a8c-4e3b-8bc5-db7e0a2617f3", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DayOffRequests_UserId",
                table: "DayOffRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DaysOff_UserId",
                table: "DaysOff",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DayOffRequests");

            migrationBuilder.DropTable(
                name: "DaysOff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "add90408-0d0e-4fec-b37e-ecf7ab355130");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b20ad2ea-4a8c-4e3b-8bc5-db7e0a2617f3");

            migrationBuilder.AddColumn<string>(
                name: "BoddyId",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bae103b8-223b-493f-ac80-ca99e1ca44b9", null, "Admin", "ADMIN" },
                    { "d15ddb9b-fd03-4bf1-a087-1c810d08017b", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_BoddyId",
                table: "Users",
                column: "BoddyId",
                unique: true,
                filter: "[BoddyId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_BoddyId",
                table: "Users",
                column: "BoddyId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

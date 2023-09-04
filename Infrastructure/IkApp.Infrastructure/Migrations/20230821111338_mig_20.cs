using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IkApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig_20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_TaskUsrId",
                table: "Tasks");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09de1130-0b15-4bb3-b9fb-930e23afbc96");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92643d6b-36f1-4152-910d-c97d39f1a0d8");

            migrationBuilder.RenameColumn(
                name: "TaskUsrId",
                table: "Tasks",
                newName: "TaskUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_TaskUsrId",
                table: "Tasks",
                newName: "IX_Tasks_TaskUserId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "392003c6-1798-4ab3-84ea-971f55d7da23", null, "User", "USER" },
                    { "f89b9432-8048-43b8-a275-5c67d98a10e4", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_TaskUserId",
                table: "Tasks",
                column: "TaskUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_TaskUserId",
                table: "Tasks");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "392003c6-1798-4ab3-84ea-971f55d7da23");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f89b9432-8048-43b8-a275-5c67d98a10e4");

            migrationBuilder.RenameColumn(
                name: "TaskUserId",
                table: "Tasks",
                newName: "TaskUsrId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_TaskUserId",
                table: "Tasks",
                newName: "IX_Tasks_TaskUsrId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "09de1130-0b15-4bb3-b9fb-930e23afbc96", null, "User", "USER" },
                    { "92643d6b-36f1-4152-910d-c97d39f1a0d8", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_TaskUsrId",
                table: "Tasks",
                column: "TaskUsrId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

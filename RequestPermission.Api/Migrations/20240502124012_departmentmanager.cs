using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RequestPermission.Api.Migrations
{
    /// <inheritdoc />
    public partial class departmentmanager : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Departments_D_MANAGER_ID",
                table: "Departments",
                column: "D_MANAGER_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Employees_D_MANAGER_ID",
                table: "Departments",
                column: "D_MANAGER_ID",
                principalTable: "Employees",
                principalColumn: "E_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Employees_D_MANAGER_ID",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_D_MANAGER_ID",
                table: "Departments");
        }
    }
}

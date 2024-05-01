using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RequestPermission.Api.Migrations
{
    /// <inheritdoc />
    public partial class updt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_E_DEPARTMENT",
                table: "Employees");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_E_DEPARTMENT",
                table: "Employees",
                column: "E_DEPARTMENT",
                principalTable: "Departments",
                principalColumn: "D_ID",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_E_DEPARTMENT",
                table: "Employees");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_E_DEPARTMENT",
                table: "Employees",
                column: "E_DEPARTMENT",
                principalTable: "Departments",
                principalColumn: "D_ID");
        }
    }
}

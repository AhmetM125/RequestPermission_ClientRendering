using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RequestPermission.Api.Migrations
{
    /// <inheritdoc />
    public partial class updatenullable_settings2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_E_EMP_COMM_ID",
                table: "Employees");

            migrationBuilder.AlterColumn<Guid>(
                name: "E_EMP_COMM_ID",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_E_EMP_COMM_ID",
                table: "Employees",
                column: "E_EMP_COMM_ID",
                unique: true,
                filter: "[E_EMP_COMM_ID] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_E_EMP_COMM_ID",
                table: "Employees");

            migrationBuilder.AlterColumn<Guid>(
                name: "E_EMP_COMM_ID",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_E_EMP_COMM_ID",
                table: "Employees",
                column: "E_EMP_COMM_ID",
                unique: true);
        }
    }
}

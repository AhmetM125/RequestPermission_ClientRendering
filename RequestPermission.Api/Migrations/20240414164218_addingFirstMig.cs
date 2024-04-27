using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RequestPermission.Api.Migrations
{
    /// <inheritdoc />
    public partial class addingFirstMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    D_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    D_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.D_ID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    E_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    E_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    E_SURNAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    E_EMAIL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    E_TITLE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    E_DEPARTMENT = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.E_ID);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_E_DEPARTMENT",
                        column: x => x.E_DEPARTMENT,
                        principalTable: "Departments",
                        principalColumn: "D_ID");
                });

            migrationBuilder.CreateTable(
                name: "Vacations",
                columns: table => new
                {
                    V_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    V_EMP_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    V_START_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    V_END_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    V_REASON = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    V_TYPE = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacations", x => x.V_ID);
                    table.ForeignKey(
                        name: "FK_Vacations_Employees_V_EMP_ID",
                        column: x => x.V_EMP_ID,
                        principalTable: "Employees",
                        principalColumn: "E_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_E_DEPARTMENT",
                table: "Employees",
                column: "E_DEPARTMENT");

            migrationBuilder.CreateIndex(
                name: "IX_Vacations_V_EMP_ID",
                table: "Vacations",
                column: "V_EMP_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vacations");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}

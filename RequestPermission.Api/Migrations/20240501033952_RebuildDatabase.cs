using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RequestPermission.Api.Migrations
{
    /// <inheritdoc />
    public partial class RebuildDatabase : Migration
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
                    D_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    D_IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    D_MANAGER_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUser = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    InsertUser = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.D_ID);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    P_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    P_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    P_DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.P_ID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    R_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    R_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.R_ID);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    RP_ROLE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RP_PERMISSION_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RP_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => new { x.RP_ROLE_ID, x.RP_PERMISSION_ID });
                    table.ForeignKey(
                        name: "FK_RolePermissions_Permissions_RP_PERMISSION_ID",
                        column: x => x.RP_PERMISSION_ID,
                        principalTable: "Permissions",
                        principalColumn: "P_ID");
                    table.ForeignKey(
                        name: "FK_RolePermissions_Roles_RP_ROLE_ID",
                        column: x => x.RP_ROLE_ID,
                        principalTable: "Roles",
                        principalColumn: "R_ID");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeCommunication",
                columns: table => new
                {
                    EC_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EC_PHONE = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    EC_ADDRESS = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    EC_CITY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EC_COUNTRY = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    EC_MOBILE_PHONE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EC_EMAIL = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    EMPLOYEEE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUser = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    InsertUser = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeCommunication", x => x.EC_ID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    E_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    E_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    E_SURNAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    E_TITLE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    E_DEPARTMENT = table.Column<int>(type: "int", nullable: true),
                    E_EMP_COMM_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUser = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    InsertUser = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.E_ID);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_E_DEPARTMENT",
                        column: x => x.E_DEPARTMENT,
                        principalTable: "Departments",
                        principalColumn: "D_ID");
                    table.ForeignKey(
                        name: "FK_Employees_EmployeeCommunication_E_EMP_COMM_ID",
                        column: x => x.E_EMP_COMM_ID,
                        principalTable: "EmployeeCommunication",
                        principalColumn: "EC_ID");
                });

            migrationBuilder.CreateTable(
                name: "Securities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Securities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Securities_Employees_Id",
                        column: x => x.Id,
                        principalTable: "Employees",
                        principalColumn: "E_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UR_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UR_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UR_EMP_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UR_ROLE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EMPLOYEEE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.UR_ID);
                    table.ForeignKey(
                        name: "FK_UserRoles_Employees_EMPLOYEEE_ID",
                        column: x => x.EMPLOYEEE_ID,
                        principalTable: "Employees",
                        principalColumn: "E_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_UR_ROLE_ID",
                        column: x => x.UR_ROLE_ID,
                        principalTable: "Roles",
                        principalColumn: "R_ID");
                });

            migrationBuilder.CreateTable(
                name: "Vacations",
                columns: table => new
                {
                    V_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    V_START_DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    V_END_DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    V_REASON = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    V_TYPE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    V_EMP_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUser = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    InsertUser = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacations", x => x.V_ID);
                    table.ForeignKey(
                        name: "FK_Vacations_Employees_V_EMP_ID",
                        column: x => x.V_EMP_ID,
                        principalTable: "Employees",
                        principalColumn: "E_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCommunication_EMPLOYEEE_ID",
                table: "EmployeeCommunication",
                column: "EMPLOYEEE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_E_DEPARTMENT",
                table: "Employees",
                column: "E_DEPARTMENT");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_E_EMP_COMM_ID",
                table: "Employees",
                column: "E_EMP_COMM_ID",
                unique: true,
                filter: "[E_EMP_COMM_ID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_RP_PERMISSION_ID",
                table: "RolePermissions",
                column: "RP_PERMISSION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_EMPLOYEEE_ID",
                table: "UserRoles",
                column: "EMPLOYEEE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UR_ROLE_ID",
                table: "UserRoles",
                column: "UR_ROLE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Vacations_V_EMP_ID",
                table: "Vacations",
                column: "V_EMP_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeCommunication_Employees_EMPLOYEEE_ID",
                table: "EmployeeCommunication",
                column: "EMPLOYEEE_ID",
                principalTable: "Employees",
                principalColumn: "E_ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeCommunication_Employees_EMPLOYEEE_ID",
                table: "EmployeeCommunication");

            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "Securities");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Vacations");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "EmployeeCommunication");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RequestPermission.Api.Migrations
{
    /// <inheritdoc />
    public partial class rolesMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacations_Employees_V_EMP_ID",
                table: "Vacations");

            migrationBuilder.DropColumn(
                name: "E_EMAIL",
                table: "Employees");

            migrationBuilder.AlterColumn<string>(
                name: "V_TYPE",
                table: "Vacations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "V_START_DATE",
                table: "Vacations",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "V_REASON",
                table: "Vacations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "V_END_DATE",
                table: "Vacations",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDate",
                table: "Vacations",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "InsertUser",
                table: "Vacations",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Vacations",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdateUser",
                table: "Vacations",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "E_EMP_COMM_ID",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDate",
                table: "Employees",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "InsertUser",
                table: "Employees",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Employees",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdateUser",
                table: "Employees",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDate",
                table: "Departments",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "InsertUser",
                table: "Departments",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Departments",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdateUser",
                table: "Departments",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

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
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateUser = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    InsertUser = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeCommunication", x => x.EC_ID);
                    table.ForeignKey(
                        name: "FK_EmployeeCommunication_Employees_EMPLOYEEE_ID",
                        column: x => x.EMPLOYEEE_ID,
                        principalTable: "Employees",
                        principalColumn: "E_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    P_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    P_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    P_DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.P_ID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    R_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    R_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.R_ID);
                });

            migrationBuilder.CreateTable(
                name: "RolePermission",
                columns: table => new
                {
                    RP_ROLE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RP_PERMISSION_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RP_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermission", x => new { x.RP_ROLE_ID, x.RP_PERMISSION_ID });
                    table.ForeignKey(
                        name: "FK_RolePermission_Permission_RP_PERMISSION_ID",
                        column: x => x.RP_PERMISSION_ID,
                        principalTable: "Permission",
                        principalColumn: "P_ID");
                    table.ForeignKey(
                        name: "FK_RolePermission_Role_RP_ROLE_ID",
                        column: x => x.RP_ROLE_ID,
                        principalTable: "Role",
                        principalColumn: "R_ID");
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
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
                    table.PrimaryKey("PK_UserRole", x => x.UR_ID);
                    table.ForeignKey(
                        name: "FK_UserRole_Employees_EMPLOYEEE_ID",
                        column: x => x.EMPLOYEEE_ID,
                        principalTable: "Employees",
                        principalColumn: "E_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_Role_UR_ROLE_ID",
                        column: x => x.UR_ROLE_ID,
                        principalTable: "Role",
                        principalColumn: "R_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_E_EMP_COMM_ID",
                table: "Employees",
                column: "E_EMP_COMM_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCommunication_EMPLOYEEE_ID",
                table: "EmployeeCommunication",
                column: "EMPLOYEEE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_RP_PERMISSION_ID",
                table: "RolePermission",
                column: "RP_PERMISSION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_EMPLOYEEE_ID",
                table: "UserRole",
                column: "EMPLOYEEE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UR_ROLE_ID",
                table: "UserRole",
                column: "UR_ROLE_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_EmployeeCommunication_E_EMP_COMM_ID",
                table: "Employees",
                column: "E_EMP_COMM_ID",
                principalTable: "EmployeeCommunication",
                principalColumn: "EC_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacations_Employees_V_EMP_ID",
                table: "Vacations",
                column: "V_EMP_ID",
                principalTable: "Employees",
                principalColumn: "E_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmployeeCommunication_E_EMP_COMM_ID",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacations_Employees_V_EMP_ID",
                table: "Vacations");

            migrationBuilder.DropTable(
                name: "EmployeeCommunication");

            migrationBuilder.DropTable(
                name: "RolePermission");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Employees_E_EMP_COMM_ID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "Vacations");

            migrationBuilder.DropColumn(
                name: "InsertUser",
                table: "Vacations");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Vacations");

            migrationBuilder.DropColumn(
                name: "UpdateUser",
                table: "Vacations");

            migrationBuilder.DropColumn(
                name: "E_EMP_COMM_ID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "InsertUser",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "UpdateUser",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "InsertUser",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "UpdateUser",
                table: "Departments");

            migrationBuilder.AlterColumn<string>(
                name: "V_TYPE",
                table: "Vacations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "V_START_DATE",
                table: "Vacations",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "V_REASON",
                table: "Vacations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "V_END_DATE",
                table: "Vacations",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddColumn<string>(
                name: "E_EMAIL",
                table: "Employees",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacations_Employees_V_EMP_ID",
                table: "Vacations",
                column: "V_EMP_ID",
                principalTable: "Employees",
                principalColumn: "E_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

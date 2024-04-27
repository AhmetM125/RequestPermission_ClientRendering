using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RequestPermission.Api.Migrations
{
    /// <inheritdoc />
    public partial class securitytable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolePermission_Permission_RP_PERMISSION_ID",
                table: "RolePermission");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePermission_Role_RP_ROLE_ID",
                table: "RolePermission");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_Employees_EMPLOYEEE_ID",
                table: "UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_Role_UR_ROLE_ID",
                table: "UserRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRole",
                table: "UserRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RolePermission",
                table: "RolePermission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permission",
                table: "Permission");

            migrationBuilder.RenameTable(
                name: "UserRole",
                newName: "UserRoles");

            migrationBuilder.RenameTable(
                name: "RolePermission",
                newName: "RolePermissions");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "Permission",
                newName: "Permissions");

            migrationBuilder.RenameIndex(
                name: "IX_UserRole_UR_ROLE_ID",
                table: "UserRoles",
                newName: "IX_UserRoles_UR_ROLE_ID");

            migrationBuilder.RenameIndex(
                name: "IX_UserRole_EMPLOYEEE_ID",
                table: "UserRoles",
                newName: "IX_UserRoles_EMPLOYEEE_ID");

            migrationBuilder.RenameIndex(
                name: "IX_RolePermission_RP_PERMISSION_ID",
                table: "RolePermissions",
                newName: "IX_RolePermissions_RP_PERMISSION_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles",
                column: "UR_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RolePermissions",
                table: "RolePermissions",
                columns: new[] { "RP_ROLE_ID", "RP_PERMISSION_ID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "R_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permissions",
                table: "Permissions",
                column: "P_ID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissions_Permissions_RP_PERMISSION_ID",
                table: "RolePermissions",
                column: "RP_PERMISSION_ID",
                principalTable: "Permissions",
                principalColumn: "P_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissions_Roles_RP_ROLE_ID",
                table: "RolePermissions",
                column: "RP_ROLE_ID",
                principalTable: "Roles",
                principalColumn: "R_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Employees_EMPLOYEEE_ID",
                table: "UserRoles",
                column: "EMPLOYEEE_ID",
                principalTable: "Employees",
                principalColumn: "E_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles_UR_ROLE_ID",
                table: "UserRoles",
                column: "UR_ROLE_ID",
                principalTable: "Roles",
                principalColumn: "R_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissions_Permissions_RP_PERMISSION_ID",
                table: "RolePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissions_Roles_RP_ROLE_ID",
                table: "RolePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Employees_EMPLOYEEE_ID",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_UR_ROLE_ID",
                table: "UserRoles");

            migrationBuilder.DropTable(
                name: "Securities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RolePermissions",
                table: "RolePermissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permissions",
                table: "Permissions");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                newName: "UserRole");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Role");

            migrationBuilder.RenameTable(
                name: "RolePermissions",
                newName: "RolePermission");

            migrationBuilder.RenameTable(
                name: "Permissions",
                newName: "Permission");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoles_UR_ROLE_ID",
                table: "UserRole",
                newName: "IX_UserRole_UR_ROLE_ID");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoles_EMPLOYEEE_ID",
                table: "UserRole",
                newName: "IX_UserRole_EMPLOYEEE_ID");

            migrationBuilder.RenameIndex(
                name: "IX_RolePermissions_RP_PERMISSION_ID",
                table: "RolePermission",
                newName: "IX_RolePermission_RP_PERMISSION_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRole",
                table: "UserRole",
                column: "UR_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "R_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RolePermission",
                table: "RolePermission",
                columns: new[] { "RP_ROLE_ID", "RP_PERMISSION_ID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permission",
                table: "Permission",
                column: "P_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermission_Permission_RP_PERMISSION_ID",
                table: "RolePermission",
                column: "RP_PERMISSION_ID",
                principalTable: "Permission",
                principalColumn: "P_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermission_Role_RP_ROLE_ID",
                table: "RolePermission",
                column: "RP_ROLE_ID",
                principalTable: "Role",
                principalColumn: "R_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_Employees_EMPLOYEEE_ID",
                table: "UserRole",
                column: "EMPLOYEEE_ID",
                principalTable: "Employees",
                principalColumn: "E_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_Role_UR_ROLE_ID",
                table: "UserRole",
                column: "UR_ROLE_ID",
                principalTable: "Role",
                principalColumn: "R_ID");
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RequestPermission.Api.Infrastracture;

#nullable disable

namespace RequestPermission.Api.Migrations
{
    [DbContext(typeof(RequestPermissionContext))]
    partial class RequestPermissionContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RequestPermission.Api.Entity.Department", b =>
                {
                    b.Property<int>("D_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("D_ID"));

                    b.Property<bool>("D_IS_ACTIVE")
                        .HasColumnType("bit");

                    b.Property<Guid?>("D_MANAGER_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("D_NAME")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("InsertDate")
                        .HasColumnType("datetime");

                    b.Property<string>("InsertUser")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("UpdateUser")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("D_ID");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("RequestPermission.Api.Entity.Employee", b =>
                {
                    b.Property<Guid>("E_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("E_DEPARTMENT")
                        .HasColumnType("int");

                    b.Property<Guid?>("E_EMP_COMM_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("E_NAME")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("E_SURNAME")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("E_TITLE")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("InsertDate")
                        .HasColumnType("datetime");

                    b.Property<string>("InsertUser")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("UpdateUser")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("E_ID");

                    b.HasIndex("E_DEPARTMENT");

                    b.HasIndex("E_EMP_COMM_ID")
                        .IsUnique()
                        .HasFilter("[E_EMP_COMM_ID] IS NOT NULL");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("RequestPermission.Api.Entity.EmployeeCommunication", b =>
                {
                    b.Property<Guid>("EC_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EC_ADDRESS")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("EC_CITY")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EC_COUNTRY")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("EC_EMAIL")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("EC_MOBILE_PHONE")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EC_PHONE")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("EMPLOYEEE_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("InsertDate")
                        .HasColumnType("datetime");

                    b.Property<string>("InsertUser")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("UpdateUser")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("EC_ID");

                    b.HasIndex("EMPLOYEEE_ID");

                    b.ToTable("EmployeeCommunication");
                });

            modelBuilder.Entity("RequestPermission.Api.Entity.Permission", b =>
                {
                    b.Property<Guid>("P_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("P_DESCRIPTION")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("P_NAME")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("P_ID");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("RequestPermission.Api.Entity.Role", b =>
                {
                    b.Property<Guid>("R_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("R_NAME")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("R_ID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("RequestPermission.Api.Entity.RolePermission", b =>
                {
                    b.Property<Guid>("RP_ROLE_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RP_PERMISSION_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RP_ID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RP_ROLE_ID", "RP_PERMISSION_ID");

                    b.HasIndex("RP_PERMISSION_ID");

                    b.ToTable("RolePermissions");
                });

            modelBuilder.Entity("RequestPermission.Api.Entity.Security", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Securities");
                });

            modelBuilder.Entity("RequestPermission.Api.Entity.UserRole", b =>
                {
                    b.Property<Guid>("UR_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EMPLOYEEE_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UR_EMP_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UR_NAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UR_ROLE_ID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UR_ID");

                    b.HasIndex("EMPLOYEEE_ID");

                    b.HasIndex("UR_ROLE_ID");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("RequestPermission.Api.Entity.Vacation", b =>
                {
                    b.Property<Guid>("V_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("InsertDate")
                        .HasColumnType("datetime");

                    b.Property<string>("InsertUser")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("UpdateUser")
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("V_EMP_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("V_END_DATE")
                        .HasColumnType("datetime");

                    b.Property<string>("V_REASON")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("V_START_DATE")
                        .HasColumnType("datetime");

                    b.Property<string>("V_TYPE")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("V_ID");

                    b.HasIndex("V_EMP_ID");

                    b.ToTable("Vacations");
                });

            modelBuilder.Entity("RequestPermission.Api.Entity.Employee", b =>
                {
                    b.HasOne("RequestPermission.Api.Entity.Department", "DEPARTMENT")
                        .WithMany("EMPLOYEES")
                        .HasForeignKey("E_DEPARTMENT")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("RequestPermission.Api.Entity.EmployeeCommunication", "EMPLOYEE_COMMUNICATION")
                        .WithOne()
                        .HasForeignKey("RequestPermission.Api.Entity.Employee", "E_EMP_COMM_ID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("DEPARTMENT");

                    b.Navigation("EMPLOYEE_COMMUNICATION");
                });

            modelBuilder.Entity("RequestPermission.Api.Entity.EmployeeCommunication", b =>
                {
                    b.HasOne("RequestPermission.Api.Entity.Employee", "EMPLOYEE")
                        .WithMany()
                        .HasForeignKey("EMPLOYEEE_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EMPLOYEE");
                });

            modelBuilder.Entity("RequestPermission.Api.Entity.RolePermission", b =>
                {
                    b.HasOne("RequestPermission.Api.Entity.Permission", "PERMISSION")
                        .WithMany("ROLE_PERMISSION")
                        .HasForeignKey("RP_PERMISSION_ID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("RequestPermission.Api.Entity.Role", "ROLE")
                        .WithMany("ROLE_PERMISSIONS")
                        .HasForeignKey("RP_ROLE_ID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("PERMISSION");

                    b.Navigation("ROLE");
                });

            modelBuilder.Entity("RequestPermission.Api.Entity.Security", b =>
                {
                    b.HasOne("RequestPermission.Api.Entity.Employee", "Employee")
                        .WithOne("Security")
                        .HasForeignKey("RequestPermission.Api.Entity.Security", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("RequestPermission.Api.Entity.UserRole", b =>
                {
                    b.HasOne("RequestPermission.Api.Entity.Employee", "EMPLOYEE")
                        .WithMany("USER_ROLES")
                        .HasForeignKey("EMPLOYEEE_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RequestPermission.Api.Entity.Role", "ROLE")
                        .WithMany("USER_ROLES")
                        .HasForeignKey("UR_ROLE_ID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("EMPLOYEE");

                    b.Navigation("ROLE");
                });

            modelBuilder.Entity("RequestPermission.Api.Entity.Vacation", b =>
                {
                    b.HasOne("RequestPermission.Api.Entity.Employee", "V_EMP")
                        .WithMany("VACATIONS")
                        .HasForeignKey("V_EMP_ID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("V_EMP");
                });

            modelBuilder.Entity("RequestPermission.Api.Entity.Department", b =>
                {
                    b.Navigation("EMPLOYEES");
                });

            modelBuilder.Entity("RequestPermission.Api.Entity.Employee", b =>
                {
                    b.Navigation("Security")
                        .IsRequired();

                    b.Navigation("USER_ROLES");

                    b.Navigation("VACATIONS");
                });

            modelBuilder.Entity("RequestPermission.Api.Entity.Permission", b =>
                {
                    b.Navigation("ROLE_PERMISSION");
                });

            modelBuilder.Entity("RequestPermission.Api.Entity.Role", b =>
                {
                    b.Navigation("ROLE_PERMISSIONS");

                    b.Navigation("USER_ROLES");
                });
#pragma warning restore 612, 618
        }
    }
}

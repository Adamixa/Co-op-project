using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityResturantInformation.Migrations
{
    public partial class updatingDatabaseNewTablesFinalFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleNum",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "FromDate",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "ToDate",
                table: "Menus");

            migrationBuilder.AddColumn<bool>(
                name: "IsFinished",
                table: "Votes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "RoleName",
                table: "Roles",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Menus",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFinished",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "RoleName",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Menus");

            migrationBuilder.AddColumn<int>(
                name: "RoleNum",
                table: "Roles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FromDate",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Menus",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ToDate",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityResturantInformation.Migrations
{
<<<<<<<< HEAD:UniversityResturantInformation/Migrations/20230918141511_MenuItemIsDeleted.cs
    public partial class MenuItemIsDeleted : Migration
========
    public partial class AddIsDeletedColumnInMenuItemTable : Migration
>>>>>>>> 06a0a12ba49e6b74051efcc1076f63752a815063:UniversityResturantInformation/Migrations/20230918134132_AddIsDeletedColumnInMenuItemTable.cs
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Menu_Items",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Menu_Items");
        }
    }
}

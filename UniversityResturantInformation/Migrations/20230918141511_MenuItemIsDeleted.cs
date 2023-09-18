using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityResturantInformation.Migrations
{
    public partial class MenuItemIsDeleted : Migration
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

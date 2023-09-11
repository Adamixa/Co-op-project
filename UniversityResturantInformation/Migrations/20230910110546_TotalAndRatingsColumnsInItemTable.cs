using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityResturantInformation.Migrations
{
    public partial class TotalAndRatingsColumnsInItemTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ratings",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "total",
                table: "Items",
                newName: "Total");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfRating",
                table: "Items",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfRating",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "Total",
                table: "Items",
                newName: "total");

            migrationBuilder.AddColumn<int>(
                name: "Ratings",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

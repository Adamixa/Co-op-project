using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityResturantInformation.Migrations
{
    public partial class archive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_List_Menus_List_MenuId",
                table: "Votes");

            migrationBuilder.DropTable(
                name: "List_Menus");

            migrationBuilder.DropTable(
                name: "Lists");

            migrationBuilder.DropIndex(
                name: "IX_Votes_List_MenuId",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "List_MenuId",
                table: "Votes");

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "Votes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsVoteable",
                table: "Menus",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Votes_MenuId",
                table: "Votes",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Menus_MenuId",
                table: "Votes",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Menus_MenuId",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_Votes_MenuId",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "IsVoteable",
                table: "Menus");

            migrationBuilder.AddColumn<int>(
                name: "List_MenuId",
                table: "Votes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Lists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "List_Menus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListId = table.Column<int>(type: "int", nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_List_Menus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_List_Menus_Lists_ListId",
                        column: x => x.ListId,
                        principalTable: "Lists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_List_Menus_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Votes_List_MenuId",
                table: "Votes",
                column: "List_MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_List_Menus_ListId",
                table: "List_Menus",
                column: "ListId");

            migrationBuilder.CreateIndex(
                name: "IX_List_Menus_MenuId",
                table: "List_Menus",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_List_Menus_List_MenuId",
                table: "Votes",
                column: "List_MenuId",
                principalTable: "List_Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

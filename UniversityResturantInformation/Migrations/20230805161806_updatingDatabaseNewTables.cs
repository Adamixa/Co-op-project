using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityResturantInformation.Migrations
{
    public partial class updatingDatabaseNewTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Menus_MenuId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Menus_MenuId",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_Votes_MenuId",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_Items_MenuId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "MId",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "MId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "LMId",
                table: "Votes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "list_MenuId",
                table: "Votes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rate",
                table: "Ratings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemCode",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "List",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_List", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "List_Menu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    menuId = table.Column<int>(nullable: true),
                    MId = table.Column<int>(nullable: false),
                    listId = table.Column<int>(nullable: true),
                    LId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_List_Menu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_List_Menu_List_listId",
                        column: x => x.listId,
                        principalTable: "List",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_List_Menu_Menus_menuId",
                        column: x => x.menuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Votes_list_MenuId",
                table: "Votes",
                column: "list_MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_List_Menu_listId",
                table: "List_Menu",
                column: "listId");

            migrationBuilder.CreateIndex(
                name: "IX_List_Menu_menuId",
                table: "List_Menu",
                column: "menuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_List_Menu_list_MenuId",
                table: "Votes",
                column: "list_MenuId",
                principalTable: "List_Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_List_Menu_list_MenuId",
                table: "Votes");

            migrationBuilder.DropTable(
                name: "List_Menu");

            migrationBuilder.DropTable(
                name: "List");

            migrationBuilder.DropIndex(
                name: "IX_Votes_list_MenuId",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "LMId",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "list_MenuId",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "ItemCode",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "MId",
                table: "Votes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "Votes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Votes_MenuId",
                table: "Votes",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_MenuId",
                table: "Items",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Menus_MenuId",
                table: "Items",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Menus_MenuId",
                table: "Votes",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

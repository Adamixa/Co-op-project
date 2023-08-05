using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityResturantInformation.Migrations
{
    public partial class updatingDatabaseNewTablesFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_List_Menu_List_listId",
                table: "List_Menu");

            migrationBuilder.DropForeignKey(
                name: "FK_List_Menu_Menus_menuId",
                table: "List_Menu");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_List_Menu_list_MenuId",
                table: "Votes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_List_Menu",
                table: "List_Menu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_List",
                table: "List");

            migrationBuilder.RenameTable(
                name: "List_Menu",
                newName: "List_Menus");

            migrationBuilder.RenameTable(
                name: "List",
                newName: "Lists");

            migrationBuilder.RenameIndex(
                name: "IX_List_Menu_menuId",
                table: "List_Menus",
                newName: "IX_List_Menus_menuId");

            migrationBuilder.RenameIndex(
                name: "IX_List_Menu_listId",
                table: "List_Menus",
                newName: "IX_List_Menus_listId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_List_Menus",
                table: "List_Menus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lists",
                table: "Lists",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Menu_Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemId = table.Column<int>(nullable: true),
                    IId = table.Column<int>(nullable: false),
                    menuId = table.Column<int>(nullable: true),
                    MId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menu_Items_Items_itemId",
                        column: x => x.itemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Menu_Items_Menus_menuId",
                        column: x => x.menuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Items_itemId",
                table: "Menu_Items",
                column: "itemId");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Items_menuId",
                table: "Menu_Items",
                column: "menuId");

            migrationBuilder.AddForeignKey(
                name: "FK_List_Menus_Lists_listId",
                table: "List_Menus",
                column: "listId",
                principalTable: "Lists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_List_Menus_Menus_menuId",
                table: "List_Menus",
                column: "menuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_List_Menus_list_MenuId",
                table: "Votes",
                column: "list_MenuId",
                principalTable: "List_Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_List_Menus_Lists_listId",
                table: "List_Menus");

            migrationBuilder.DropForeignKey(
                name: "FK_List_Menus_Menus_menuId",
                table: "List_Menus");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_List_Menus_list_MenuId",
                table: "Votes");

            migrationBuilder.DropTable(
                name: "Menu_Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lists",
                table: "Lists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_List_Menus",
                table: "List_Menus");

            migrationBuilder.RenameTable(
                name: "Lists",
                newName: "List");

            migrationBuilder.RenameTable(
                name: "List_Menus",
                newName: "List_Menu");

            migrationBuilder.RenameIndex(
                name: "IX_List_Menus_menuId",
                table: "List_Menu",
                newName: "IX_List_Menu_menuId");

            migrationBuilder.RenameIndex(
                name: "IX_List_Menus_listId",
                table: "List_Menu",
                newName: "IX_List_Menu_listId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_List",
                table: "List",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_List_Menu",
                table: "List_Menu",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_List_Menu_List_listId",
                table: "List_Menu",
                column: "listId",
                principalTable: "List",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_List_Menu_Menus_menuId",
                table: "List_Menu",
                column: "menuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_List_Menu_list_MenuId",
                table: "Votes",
                column: "list_MenuId",
                principalTable: "List_Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

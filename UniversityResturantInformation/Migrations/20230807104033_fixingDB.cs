using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityResturantInformation.Migrations
{
    public partial class fixingDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_Users_UserId",
                table: "Complaints");

            migrationBuilder.DropForeignKey(
                name: "FK_List_Menus_Lists_listId",
                table: "List_Menus");

            migrationBuilder.DropForeignKey(
                name: "FK_List_Menus_Menus_menuId",
                table: "List_Menus");

            migrationBuilder.DropForeignKey(
                name: "FK_Menu_Items_Items_itemId",
                table: "Menu_Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Menu_Items_Menus_menuId",
                table: "Menu_Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Items_ItemId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Users_UserId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Users_UserId",
                table: "Votes");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_List_Menus_list_MenuId",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "LMId",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "UId",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "RId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "UId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "IId",
                table: "Menu_Items");

            migrationBuilder.DropColumn(
                name: "MId",
                table: "Menu_Items");

            migrationBuilder.DropColumn(
                name: "LId",
                table: "List_Menus");

            migrationBuilder.DropColumn(
                name: "MId",
                table: "List_Menus");

            migrationBuilder.DropColumn(
                name: "UId",
                table: "Complaints");

            migrationBuilder.RenameColumn(
                name: "list_MenuId",
                table: "Votes",
                newName: "List_MenuId");

            migrationBuilder.RenameIndex(
                name: "IX_Votes_list_MenuId",
                table: "Votes",
                newName: "IX_Votes_List_MenuId");

            migrationBuilder.RenameColumn(
                name: "menuId",
                table: "Menu_Items",
                newName: "MenuId");

            migrationBuilder.RenameColumn(
                name: "itemId",
                table: "Menu_Items",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Menu_Items_menuId",
                table: "Menu_Items",
                newName: "IX_Menu_Items_MenuId");

            migrationBuilder.RenameIndex(
                name: "IX_Menu_Items_itemId",
                table: "Menu_Items",
                newName: "IX_Menu_Items_ItemId");

            migrationBuilder.RenameColumn(
                name: "menuId",
                table: "List_Menus",
                newName: "MenuId");

            migrationBuilder.RenameColumn(
                name: "listId",
                table: "List_Menus",
                newName: "ListId");

            migrationBuilder.RenameIndex(
                name: "IX_List_Menus_menuId",
                table: "List_Menus",
                newName: "IX_List_Menus_MenuId");

            migrationBuilder.RenameIndex(
                name: "IX_List_Menus_listId",
                table: "List_Menus",
                newName: "IX_List_Menus_ListId");

            migrationBuilder.AlterColumn<int>(
                name: "List_MenuId",
                table: "Votes",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Votes",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Users",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Ratings",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "Ratings",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "Menu_Items",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "Menu_Items",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "List_Menus",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ListId",
                table: "List_Menus",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Complaints",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_Users_UserId",
                table: "Complaints",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_List_Menus_Lists_ListId",
                table: "List_Menus",
                column: "ListId",
                principalTable: "Lists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_List_Menus_Menus_MenuId",
                table: "List_Menus",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_Items_Items_ItemId",
                table: "Menu_Items",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_Items_Menus_MenuId",
                table: "Menu_Items",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Items_ItemId",
                table: "Ratings",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Users_UserId",
                table: "Ratings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_List_Menus_List_MenuId",
                table: "Votes",
                column: "List_MenuId",
                principalTable: "List_Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Users_UserId",
                table: "Votes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_Users_UserId",
                table: "Complaints");

            migrationBuilder.DropForeignKey(
                name: "FK_List_Menus_Lists_ListId",
                table: "List_Menus");

            migrationBuilder.DropForeignKey(
                name: "FK_List_Menus_Menus_MenuId",
                table: "List_Menus");

            migrationBuilder.DropForeignKey(
                name: "FK_Menu_Items_Items_ItemId",
                table: "Menu_Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Menu_Items_Menus_MenuId",
                table: "Menu_Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Items_ItemId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Users_UserId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_List_Menus_List_MenuId",
                table: "Votes");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Users_UserId",
                table: "Votes");

            migrationBuilder.RenameColumn(
                name: "List_MenuId",
                table: "Votes",
                newName: "list_MenuId");

            migrationBuilder.RenameIndex(
                name: "IX_Votes_List_MenuId",
                table: "Votes",
                newName: "IX_Votes_list_MenuId");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "Menu_Items",
                newName: "menuId");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "Menu_Items",
                newName: "itemId");

            migrationBuilder.RenameIndex(
                name: "IX_Menu_Items_MenuId",
                table: "Menu_Items",
                newName: "IX_Menu_Items_menuId");

            migrationBuilder.RenameIndex(
                name: "IX_Menu_Items_ItemId",
                table: "Menu_Items",
                newName: "IX_Menu_Items_itemId");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "List_Menus",
                newName: "menuId");

            migrationBuilder.RenameColumn(
                name: "ListId",
                table: "List_Menus",
                newName: "listId");

            migrationBuilder.RenameIndex(
                name: "IX_List_Menus_MenuId",
                table: "List_Menus",
                newName: "IX_List_Menus_menuId");

            migrationBuilder.RenameIndex(
                name: "IX_List_Menus_ListId",
                table: "List_Menus",
                newName: "IX_List_Menus_listId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Votes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "list_MenuId",
                table: "Votes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "LMId",
                table: "Votes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UId",
                table: "Votes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "RId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Ratings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "Ratings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "IId",
                table: "Ratings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UId",
                table: "Ratings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "menuId",
                table: "Menu_Items",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "itemId",
                table: "Menu_Items",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "IId",
                table: "Menu_Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MId",
                table: "Menu_Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "menuId",
                table: "List_Menus",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "listId",
                table: "List_Menus",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "LId",
                table: "List_Menus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MId",
                table: "List_Menus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Complaints",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "UId",
                table: "Complaints",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_Users_UserId",
                table: "Complaints",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Menu_Items_Items_itemId",
                table: "Menu_Items",
                column: "itemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_Items_Menus_menuId",
                table: "Menu_Items",
                column: "menuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Items_ItemId",
                table: "Ratings",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Users_UserId",
                table: "Ratings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Users_UserId",
                table: "Votes",
                column: "UserId",
                principalTable: "Users",
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
    }
}

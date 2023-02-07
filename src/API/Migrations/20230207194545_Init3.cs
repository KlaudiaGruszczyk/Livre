using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class Init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersLibraryItems_Books_BookForeignKey",
                table: "UsersLibraryItems");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersLibraryItems_Users_UserForeignKey",
                table: "UsersLibraryItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersLibraryItems",
                table: "UsersLibraryItems");

            migrationBuilder.DropIndex(
                name: "IX_UsersLibraryItems_BookForeignKey",
                table: "UsersLibraryItems");

            migrationBuilder.DropIndex(
                name: "IX_UsersLibraryItems_UserForeignKey",
                table: "UsersLibraryItems");

            migrationBuilder.DropColumn(
                name: "BookForeignKey",
                table: "UsersLibraryItems");

            migrationBuilder.DropColumn(
                name: "UserForeignKey",
                table: "UsersLibraryItems");

            migrationBuilder.AddColumn<int>(
                name: "BookIdItem",
                table: "UsersLibraryItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserIdItem",
                table: "UsersLibraryItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersLibraryItems",
                table: "UsersLibraryItems",
                column: "LibraryItemId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersLibraryItems_BookId",
                table: "UsersLibraryItems",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersLibraryItems_UserId",
                table: "UsersLibraryItems",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersLibraryItems_Books_BookId",
                table: "UsersLibraryItems",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersLibraryItems_Users_UserId",
                table: "UsersLibraryItems",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersLibraryItems_Books_BookId",
                table: "UsersLibraryItems");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersLibraryItems_Users_UserId",
                table: "UsersLibraryItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersLibraryItems",
                table: "UsersLibraryItems");

            migrationBuilder.DropIndex(
                name: "IX_UsersLibraryItems_BookId",
                table: "UsersLibraryItems");

            migrationBuilder.DropIndex(
                name: "IX_UsersLibraryItems_UserId",
                table: "UsersLibraryItems");

            migrationBuilder.DropColumn(
                name: "BookIdItem",
                table: "UsersLibraryItems");

            migrationBuilder.DropColumn(
                name: "UserIdItem",
                table: "UsersLibraryItems");

            migrationBuilder.AddColumn<int>(
                name: "BookForeignKey",
                table: "UsersLibraryItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserForeignKey",
                table: "UsersLibraryItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersLibraryItems",
                table: "UsersLibraryItems",
                columns: new[] { "UserId", "BookId" });

            migrationBuilder.CreateIndex(
                name: "IX_UsersLibraryItems_BookForeignKey",
                table: "UsersLibraryItems",
                column: "BookForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_UsersLibraryItems_UserForeignKey",
                table: "UsersLibraryItems",
                column: "UserForeignKey");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersLibraryItems_Books_BookForeignKey",
                table: "UsersLibraryItems",
                column: "BookForeignKey",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersLibraryItems_Users_UserForeignKey",
                table: "UsersLibraryItems",
                column: "UserForeignKey",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

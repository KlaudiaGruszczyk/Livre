using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class Init5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersLibraryItems_Books_BookId",
                table: "UsersLibraryItems");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersLibraryItems_Users_UserId",
                table: "UsersLibraryItems");

            migrationBuilder.DropIndex(
                name: "IX_UsersLibraryItems_BookId",
                table: "UsersLibraryItems");

            migrationBuilder.DropIndex(
                name: "IX_UsersLibraryItems_UserId",
                table: "UsersLibraryItems");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "UsersLibraryItems");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UsersLibraryItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "UsersLibraryItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UsersLibraryItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}

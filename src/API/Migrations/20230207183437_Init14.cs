using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class Init14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorForeignKey",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "AuthorForeignKey",
                table: "Books",
                newName: "AuthorIdForeignKey");

            migrationBuilder.RenameIndex(
                name: "IX_Books_AuthorForeignKey",
                table: "Books",
                newName: "IX_Books_AuthorIdForeignKey");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorIdForeignKey",
                table: "Books",
                column: "AuthorIdForeignKey",
                principalTable: "Authors",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorIdForeignKey",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "AuthorIdForeignKey",
                table: "Books",
                newName: "AuthorForeignKey");

            migrationBuilder.RenameIndex(
                name: "IX_Books_AuthorIdForeignKey",
                table: "Books",
                newName: "IX_Books_AuthorForeignKey");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorForeignKey",
                table: "Books",
                column: "AuthorForeignKey",
                principalTable: "Authors",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

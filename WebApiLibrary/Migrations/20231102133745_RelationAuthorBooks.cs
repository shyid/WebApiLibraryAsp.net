using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiLibrary.Migrations
{
    /// <inheritdoc />
    public partial class RelationAuthorBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBooks_Authors_AuthorId",
                table: "AuthorBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBooks_Book_BookId",
                table: "AuthorBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorBooks",
                table: "AuthorBooks");

            migrationBuilder.RenameTable(
                name: "AuthorBooks",
                newName: "AuthorBook");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorBooks_BookId",
                table: "AuthorBook",
                newName: "IX_AuthorBook_BookId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "AuthorBook",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorBook",
                table: "AuthorBook",
                columns: new[] { "AuthorId", "BookId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBook_Authors_AuthorId",
                table: "AuthorBook",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBook_Book_BookId",
                table: "AuthorBook",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBook_Authors_AuthorId",
                table: "AuthorBook");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBook_Book_BookId",
                table: "AuthorBook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorBook",
                table: "AuthorBook");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AuthorBook");

            migrationBuilder.RenameTable(
                name: "AuthorBook",
                newName: "AuthorBooks");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorBook_BookId",
                table: "AuthorBooks",
                newName: "IX_AuthorBooks_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorBooks",
                table: "AuthorBooks",
                columns: new[] { "AuthorId", "BookId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBooks_Authors_AuthorId",
                table: "AuthorBooks",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBooks_Book_BookId",
                table: "AuthorBooks",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

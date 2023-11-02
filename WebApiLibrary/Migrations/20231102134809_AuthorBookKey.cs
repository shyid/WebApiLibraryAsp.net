using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiLibrary.Migrations
{
    /// <inheritdoc />
    public partial class AuthorBookKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBook_Authors_AuthorId",
                table: "AuthorBook");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBook_Book_BookId",
                table: "AuthorBook");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBook_Authors_AuthorId",
                table: "AuthorBook",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBook_Book_BookId",
                table: "AuthorBook",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id");
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

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBook_Authors_AuthorId",
                table: "AuthorBook",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBook_Book_BookId",
                table: "AuthorBook",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}

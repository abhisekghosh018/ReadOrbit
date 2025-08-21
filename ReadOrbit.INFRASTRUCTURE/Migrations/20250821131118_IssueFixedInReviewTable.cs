using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReadOrbit.INFRASTRUCTURE.Migrations
{
    /// <inheritdoc />
    public partial class IssueFixedInReviewTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReaderGroup_BookReaders_BookReaderId",
                table: "ReaderGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_ReaderGroup_Books_BookId",
                table: "ReaderGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_BookReaders_BookReaderId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Books_BookId",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Review",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReaderGroup",
                table: "ReaderGroup");

            migrationBuilder.RenameTable(
                name: "Review",
                newName: "Reviews");

            migrationBuilder.RenameTable(
                name: "ReaderGroup",
                newName: "ReaderGroups");

            migrationBuilder.RenameIndex(
                name: "IX_Review_BookReaderId",
                table: "Reviews",
                newName: "IX_Reviews_BookReaderId");

            migrationBuilder.RenameIndex(
                name: "IX_Review_BookId",
                table: "Reviews",
                newName: "IX_Reviews_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_ReaderGroup_BookReaderId",
                table: "ReaderGroups",
                newName: "IX_ReaderGroups_BookReaderId");

            migrationBuilder.RenameIndex(
                name: "IX_ReaderGroup_BookId",
                table: "ReaderGroups",
                newName: "IX_ReaderGroups_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "ReviewId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReaderGroups",
                table: "ReaderGroups",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReaderGroups_BookReaders_BookReaderId",
                table: "ReaderGroups",
                column: "BookReaderId",
                principalTable: "BookReaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReaderGroups_Books_BookId",
                table: "ReaderGroups",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_BookReaders_BookReaderId",
                table: "Reviews",
                column: "BookReaderId",
                principalTable: "BookReaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Books_BookId",
                table: "Reviews",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReaderGroups_BookReaders_BookReaderId",
                table: "ReaderGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_ReaderGroups_Books_BookId",
                table: "ReaderGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_BookReaders_BookReaderId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Books_BookId",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReaderGroups",
                table: "ReaderGroups");

            migrationBuilder.RenameTable(
                name: "Reviews",
                newName: "Review");

            migrationBuilder.RenameTable(
                name: "ReaderGroups",
                newName: "ReaderGroup");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_BookReaderId",
                table: "Review",
                newName: "IX_Review_BookReaderId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_BookId",
                table: "Review",
                newName: "IX_Review_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_ReaderGroups_BookReaderId",
                table: "ReaderGroup",
                newName: "IX_ReaderGroup_BookReaderId");

            migrationBuilder.RenameIndex(
                name: "IX_ReaderGroups_BookId",
                table: "ReaderGroup",
                newName: "IX_ReaderGroup_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Review",
                table: "Review",
                column: "ReviewId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReaderGroup",
                table: "ReaderGroup",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReaderGroup_BookReaders_BookReaderId",
                table: "ReaderGroup",
                column: "BookReaderId",
                principalTable: "BookReaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReaderGroup_Books_BookId",
                table: "ReaderGroup",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_BookReaders_BookReaderId",
                table: "Review",
                column: "BookReaderId",
                principalTable: "BookReaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Books_BookId",
                table: "Review",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

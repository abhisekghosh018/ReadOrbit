using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReadOrbit.INFRASTRUCTURE.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedReaderGroupTabelWithBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReaderGroups_Books_BookId",
                table: "ReaderGroups");

            migrationBuilder.DropIndex(
                name: "IX_ReaderGroups_BookId",
                table: "ReaderGroups");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "ReaderGroups");

            migrationBuilder.AddColumn<string>(
                name: "ReaderGroupId",
                table: "Books",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_ReaderGroupId",
                table: "Books",
                column: "ReaderGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_ReaderGroups_ReaderGroupId",
                table: "Books",
                column: "ReaderGroupId",
                principalTable: "ReaderGroups",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_ReaderGroups_ReaderGroupId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_ReaderGroupId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ReaderGroupId",
                table: "Books");

            migrationBuilder.AddColumn<string>(
                name: "BookId",
                table: "ReaderGroups",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ReaderGroups_BookId",
                table: "ReaderGroups",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReaderGroups_Books_BookId",
                table: "ReaderGroups",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

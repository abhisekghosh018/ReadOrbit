using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReadOrbit.INFRASTRUCTURE.Migrations
{
    /// <inheritdoc />
    public partial class readerGroupToTheTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReaderGroup",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    BookReaderId = table.Column<string>(type: "text", nullable: false),
                    BookId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReaderGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReaderGroup_BookReaders_BookReaderId",
                        column: x => x.BookReaderId,
                        principalTable: "BookReaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReaderGroup_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReaderGroup_BookId",
                table: "ReaderGroup",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_ReaderGroup_BookReaderId",
                table: "ReaderGroup",
                column: "BookReaderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReaderGroup");
        }
    }
}

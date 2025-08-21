using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReadOrbit.INFRASTRUCTURE.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedReaderGroupTabelWithGroupId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GroupId",
                table: "ReaderGroups",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ReaderGroups_GroupId",
                table: "ReaderGroups",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReaderGroups_Groups_GroupId",
                table: "ReaderGroups",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReaderGroups_Groups_GroupId",
                table: "ReaderGroups");

            migrationBuilder.DropIndex(
                name: "IX_ReaderGroups_GroupId",
                table: "ReaderGroups");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "ReaderGroups");
        }
    }
}

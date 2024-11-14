using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pethotel.Migrations
{
    /// <inheritdoc />
    public partial class MinorSpellingMistake : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "checkedinAt",
                table: "Pets",
                newName: "checkedInAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "checkedInAt",
                table: "Pets",
                newName: "checkedinAt");
        }
    }
}

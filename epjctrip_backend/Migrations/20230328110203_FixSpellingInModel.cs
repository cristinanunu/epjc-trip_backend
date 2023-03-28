using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace epjctrip_backend.Migrations
{
    /// <inheritdoc />
    public partial class FixSpellingInModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Destionation",
                table: "Plan",
                newName: "Destination");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Destination",
                table: "Plan",
                newName: "Destionation");
        }
    }
}

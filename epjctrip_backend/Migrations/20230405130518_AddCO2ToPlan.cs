using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace epjctrip_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddCO2ToPlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AccommodationCo2E",
                table: "Plan",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccommodationType",
                table: "Plan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalCo2E",
                table: "Plan",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TransportCo2E",
                table: "Plan",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransportType",
                table: "Plan",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccommodationCo2E",
                table: "Plan");

            migrationBuilder.DropColumn(
                name: "AccommodationType",
                table: "Plan");

            migrationBuilder.DropColumn(
                name: "TotalCo2E",
                table: "Plan");

            migrationBuilder.DropColumn(
                name: "TransportCo2E",
                table: "Plan");

            migrationBuilder.DropColumn(
                name: "TransportType",
                table: "Plan");
        }
    }
}

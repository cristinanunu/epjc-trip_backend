using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace epjctrip_backend.Migrations
{
    /// <inheritdoc />
    public partial class modifiedActivity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_Plan_PlanId",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "TripadvisorId",
                table: "Activity");
            
            migrationBuilder.AlterColumn<int>(
                name: "PlanId",
                table: "Activity",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Activity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_Plan_PlanId",
                table: "Activity",
                column: "PlanId",
                principalTable: "Plan",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_Plan_PlanId",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "User");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Activity");

            migrationBuilder.AlterColumn<int>(
                name: "PlanId",
                table: "Activity",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Latitude",
                table: "Activity",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Longitude",
                table: "Activity",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TripadvisorId",
                table: "Activity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_Plan_PlanId",
                table: "Activity",
                column: "PlanId",
                principalTable: "Plan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

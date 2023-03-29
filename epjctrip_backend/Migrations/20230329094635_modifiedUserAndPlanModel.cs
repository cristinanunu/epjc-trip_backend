using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace epjctrip_backend.Migrations
{
    /// <inheritdoc />
    public partial class modifiedUserAndPlanModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Plan_PlanId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_PlanId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PlanId",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Plan",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Plan");

            migrationBuilder.AddColumn<int>(
                name: "PlanId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_User_PlanId",
                table: "User",
                column: "PlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Plan_PlanId",
                table: "User",
                column: "PlanId",
                principalTable: "Plan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

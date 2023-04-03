using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace epjctrip_backend.Migrations
{
    /// <inheritdoc />
    public partial class modelUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_Plan_PlanId",
                table: "Activity");

            migrationBuilder.DropForeignKey(
                name: "FK_Plan_User_UserId",
                table: "Plan");

            migrationBuilder.DropIndex(
                name: "IX_Plan_UserId",
                table: "Plan");

            migrationBuilder.DropIndex(
                name: "IX_Activity_PlanId",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "Participants",
                table: "Plan");

            migrationBuilder.DropColumn(
                name: "PlanId",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "ReviewsNumber",
                table: "Activity");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Plan",
                newName: "Budget");

            migrationBuilder.RenameColumn(
                name: "Cost",
                table: "Plan",
                newName: "Duration");

            migrationBuilder.AddColumn<int>(
                name: "PlanId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Departure",
                table: "Plan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccommodationType",
                table: "Plan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CarbonFootPrint",
                table: "Plan",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Transport",
                table: "Plan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "Activity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Activity",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Longitude",
                table: "Activity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ranking",
                table: "Activity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ActivityPlan",
                columns: table => new
                {
                    ActivitiesId = table.Column<int>(type: "int", nullable: false),
                    PlansId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityPlan", x => new { x.ActivitiesId, x.PlansId });
                    table.ForeignKey(
                        name: "FK_ActivityPlan_Activity_ActivitiesId",
                        column: x => x.ActivitiesId,
                        principalTable: "Activity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityPlan_Plan_PlansId",
                        column: x => x.PlansId,
                        principalTable: "Plan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_PlanId",
                table: "User",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityPlan_PlansId",
                table: "ActivityPlan",
                column: "PlansId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Plan_PlanId",
                table: "User",
                column: "PlanId",
                principalTable: "Plan",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Plan_PlanId",
                table: "User");

            migrationBuilder.DropTable(
                name: "ActivityPlan");

            migrationBuilder.DropIndex(
                name: "IX_User_PlanId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PlanId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "AccommodationType",
                table: "Plan");

            migrationBuilder.DropColumn(
                name: "CarbonFootPrint",
                table: "Plan");

            migrationBuilder.DropColumn(
                name: "Transport",
                table: "Plan");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "Ranking",
                table: "Activity");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "Plan",
                newName: "Cost");

            migrationBuilder.RenameColumn(
                name: "Budget",
                table: "Plan",
                newName: "UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Departure",
                table: "Plan",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Participants",
                table: "Plan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlanId",
                table: "Activity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Activity",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReviewsNumber",
                table: "Activity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Plan_UserId",
                table: "Plan",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Activity_PlanId",
                table: "Activity",
                column: "PlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_Plan_PlanId",
                table: "Activity",
                column: "PlanId",
                principalTable: "Plan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plan_User_UserId",
                table: "Plan",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

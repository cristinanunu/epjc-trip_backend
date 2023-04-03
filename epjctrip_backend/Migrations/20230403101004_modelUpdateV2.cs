using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace epjctrip_backend.Migrations
{
    /// <inheritdoc />
    public partial class modelUpdateV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "PlanId",
                table: "Activity",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserPlans",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PlanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPlans", x => new { x.UserId, x.PlanId });
                    table.ForeignKey(
                        name: "FK_UserPlans_Plan_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPlans_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activity_PlanId",
                table: "Activity",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPlans_PlanId",
                table: "UserPlans",
                column: "PlanId");

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

            migrationBuilder.DropTable(
                name: "UserPlans");

            migrationBuilder.DropIndex(
                name: "IX_Activity_PlanId",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "PlanId",
                table: "Activity");

            migrationBuilder.AddColumn<int>(
                name: "PlanId",
                table: "User",
                type: "int",
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
    }
}

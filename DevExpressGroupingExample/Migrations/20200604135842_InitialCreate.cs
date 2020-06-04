using Microsoft.EntityFrameworkCore.Migrations;

namespace DevExpressGroupingExample.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    SK = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.SK);
                });

            migrationBuilder.CreateTable(
                name: "Participant",
                columns: table => new
                {
                    SK = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participant", x => x.SK);
                });

            migrationBuilder.CreateTable(
                name: "ActivityParticipants",
                columns: table => new
                {
                    ActivitySK = table.Column<int>(nullable: false),
                    ParticipantSK = table.Column<int>(nullable: false),
                    ResultStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityParticipants", x => new { x.ActivitySK, x.ParticipantSK });
                    table.ForeignKey(
                        name: "FK_ActivityParticipants_Activity_ActivitySK",
                        column: x => x.ActivitySK,
                        principalTable: "Activity",
                        principalColumn: "SK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityParticipants_Participant_ParticipantSK",
                        column: x => x.ParticipantSK,
                        principalTable: "Participant",
                        principalColumn: "SK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParticipantGroup",
                columns: table => new
                {
                    ParticipantSK = table.Column<int>(nullable: false),
                    GroupSK = table.Column<int>(nullable: false),
                    GroupName = table.Column<string>(nullable: true),
                    GroupCategory = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantGroup", x => new { x.ParticipantSK, x.GroupSK });
                    table.ForeignKey(
                        name: "FK_ParticipantGroup_Participant_ParticipantSK",
                        column: x => x.ParticipantSK,
                        principalTable: "Participant",
                        principalColumn: "SK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Activity",
                columns: new[] { "SK", "Name" },
                values: new object[] { 1, "Football" });

            migrationBuilder.InsertData(
                table: "Participant",
                columns: new[] { "SK", "FirstName", "LastName" },
                values: new object[] { 1, "Viktor", "Plane" });

            migrationBuilder.InsertData(
                table: "ActivityParticipants",
                columns: new[] { "ActivitySK", "ParticipantSK", "ResultStatus" },
                values: new object[] { 1, 1, "Victory" });

            migrationBuilder.InsertData(
                table: "ParticipantGroup",
                columns: new[] { "ParticipantSK", "GroupSK", "GroupCategory", "GroupName" },
                values: new object[] { 1, 0, "Company", "Simployer" });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityParticipants_ParticipantSK",
                table: "ActivityParticipants",
                column: "ParticipantSK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityParticipants");

            migrationBuilder.DropTable(
                name: "ParticipantGroup");

            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropTable(
                name: "Participant");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class EngagementMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Engagements",
                columns: table => new
                {
                    StudentID = table.Column<int>(nullable: false),
                    ProjectID = table.Column<long>(nullable: false),
                    DocumentID = table.Column<int>(nullable: false),
                    PhaseID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engagements", x => new { x.ProjectID, x.DocumentID, x.PhaseID, x.StudentID });
                    table.ForeignKey(
                        name: "FK_Engagements_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Engagements_Phases_ProjectID_DocumentID_PhaseID",
                        columns: x => new { x.ProjectID, x.DocumentID, x.PhaseID },
                        principalTable: "Phases",
                        principalColumns: new[] { "ProjectID", "DocumentID", "PhaseID" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Engagements_StudentID",
                table: "Engagements",
                column: "StudentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Engagements");
        }
    }
}

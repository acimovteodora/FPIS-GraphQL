using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class SkillMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    ProjectID = table.Column<long>(nullable: false),
                    DocumentID = table.Column<int>(nullable: false),
                    PhaseID = table.Column<int>(nullable: false),
                    SkillID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => new { x.ProjectID, x.DocumentID, x.PhaseID, x.SkillID });
                    table.ForeignKey(
                        name: "FK_Skills_Phases_ProjectID_DocumentID_PhaseID",
                        columns: x => new { x.ProjectID, x.DocumentID, x.PhaseID },
                        principalTable: "Phases",
                        principalColumns: new[] { "ProjectID", "DocumentID", "PhaseID" },
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Skills");
        }
    }
}

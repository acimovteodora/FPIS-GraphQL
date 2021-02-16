using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class PhaseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Phases",
                columns: table => new
                {
                    ProjectID = table.Column<long>(nullable: false),
                    DocumentID = table.Column<int>(nullable: false),
                    PhaseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Duration = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phases", x => new { x.ProjectID, x.DocumentID, x.PhaseID });
                    table.ForeignKey(
                        name: "FK_Phases_Documents_ProjectID_DocumentID",
                        columns: x => new { x.ProjectID, x.DocumentID },
                        principalTable: "Documents",
                        principalColumns: new[] { "ProjectID", "DocumentID" },
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Phases");
        }
    }
}

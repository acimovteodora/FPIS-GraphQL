using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class ProgressAndChangesReportMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Explanation",
                table: "Documents",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ActivityDescription",
                table: "Documents",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhaseDocumentID",
                table: "Documents",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhaseID",
                table: "Documents",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PhaseProjectID",
                table: "Documents",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_PhaseProjectID_PhaseDocumentID_PhaseID",
                table: "Documents",
                columns: new[] { "PhaseProjectID", "PhaseDocumentID", "PhaseID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Phases_PhaseProjectID_PhaseDocumentID_PhaseID",
                table: "Documents",
                columns: new[] { "PhaseProjectID", "PhaseDocumentID", "PhaseID" },
                principalTable: "Phases",
                principalColumns: new[] { "ProjectID", "DocumentID", "PhaseID" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Phases_PhaseProjectID_PhaseDocumentID_PhaseID",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_PhaseProjectID_PhaseDocumentID_PhaseID",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "Explanation",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "ActivityDescription",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "PhaseDocumentID",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "PhaseID",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "PhaseProjectID",
                table: "Documents");
        }
    }
}

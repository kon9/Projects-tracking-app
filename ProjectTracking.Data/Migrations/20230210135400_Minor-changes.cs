using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectTracking.Data.Migrations
{
    public partial class Minorchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Projects",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "CompletionDate",
                table: "Projects",
                newName: "EndDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Projects",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Projects",
                newName: "CompletionDate");
        }
    }
}

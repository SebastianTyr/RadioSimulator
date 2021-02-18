using Microsoft.EntityFrameworkCore.Migrations;

namespace RadioConsole.Web.Migrations
{
    public partial class IncidentListMigrationUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Group",
                table: "Incidents",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Group",
                table: "Incidents");
        }
    }
}

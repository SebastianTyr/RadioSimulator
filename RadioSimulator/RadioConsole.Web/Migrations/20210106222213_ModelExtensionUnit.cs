using Microsoft.EntityFrameworkCore.Migrations;

namespace RadioConsole.Web.Migrations
{
    public partial class ModelExtensionUnit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Unit",
                table: "Radios",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Unit",
                table: "Radios");
        }
    }
}

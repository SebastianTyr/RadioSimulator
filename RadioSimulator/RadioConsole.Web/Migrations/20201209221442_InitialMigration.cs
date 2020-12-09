using Microsoft.EntityFrameworkCore.Migrations;

namespace RadioConsole.Web.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Radios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    SerialNumber = table.Column<string>(nullable: true),
                    SignalStrength = table.Column<int>(nullable: false),
                    BatteryLevel = table.Column<int>(nullable: false),
                    Mode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radios", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Radios");
        }
    }
}

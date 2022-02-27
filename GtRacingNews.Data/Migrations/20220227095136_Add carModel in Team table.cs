using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GtRacingNews.Data.Migrations
{
    public partial class AddcarModelinTeamtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CarModel",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarModel",
                table: "Teams");
        }
    }
}

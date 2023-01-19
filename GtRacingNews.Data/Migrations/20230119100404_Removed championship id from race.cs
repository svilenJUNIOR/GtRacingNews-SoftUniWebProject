using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GtRacingNews.Data.Migrations
{
    public partial class Removedchampionshipidfromrace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChampionshipId",
                table: "Races");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChampionshipId",
                table: "Races",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

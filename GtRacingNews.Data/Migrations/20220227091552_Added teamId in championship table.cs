using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GtRacingNews.Data.Migrations
{
    public partial class AddedteamIdinchampionshiptable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Championships",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Championships");
        }
    }
}

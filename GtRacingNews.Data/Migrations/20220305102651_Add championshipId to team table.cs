using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GtRacingNews.Data.Migrations
{
    public partial class AddchampionshipIdtoteamtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Championships_ChampionshipId",
                table: "Teams");

            migrationBuilder.AlterColumn<int>(
                name: "ChampionshipId",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Championships_ChampionshipId",
                table: "Teams",
                column: "ChampionshipId",
                principalTable: "Championships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Championships_ChampionshipId",
                table: "Teams");

            migrationBuilder.AlterColumn<int>(
                name: "ChampionshipId",
                table: "Teams",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Championships_ChampionshipId",
                table: "Teams",
                column: "ChampionshipId",
                principalTable: "Championships",
                principalColumn: "Id");
        }
    }
}

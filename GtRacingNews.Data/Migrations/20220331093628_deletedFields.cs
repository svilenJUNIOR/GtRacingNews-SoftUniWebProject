using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GtRacingNews.Data.MIgrations
{
    public partial class deletedFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Championships_Profiles_ProfileId",
                table: "Championships");

            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_Profiles_ProfileId",
                table: "Drivers");

            migrationBuilder.DropForeignKey(
                name: "FK_News_Profiles_ProfileId",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_Races_Profiles_ProfileId",
                table: "Races");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Profiles_ProfileId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_ProfileId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Races_ProfileId",
                table: "Races");

            migrationBuilder.DropIndex(
                name: "IX_News_ProfileId",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_Drivers_ProfileId",
                table: "Drivers");

            migrationBuilder.DropIndex(
                name: "IX_Championships_ProfileId",
                table: "Championships");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Championships");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Teams",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Races",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "News",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Drivers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Championships",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_ProfileId",
                table: "Teams",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Races_ProfileId",
                table: "Races",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_News_ProfileId",
                table: "News",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_ProfileId",
                table: "Drivers",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Championships_ProfileId",
                table: "Championships",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Championships_Profiles_ProfileId",
                table: "Championships",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_Profiles_ProfileId",
                table: "Drivers",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_News_Profiles_ProfileId",
                table: "News",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Races_Profiles_ProfileId",
                table: "Races",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Profiles_ProfileId",
                table: "Teams",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}

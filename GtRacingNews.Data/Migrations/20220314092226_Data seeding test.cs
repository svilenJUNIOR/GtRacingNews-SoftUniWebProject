using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GtRacingNews.Data.Migrations
{
    public partial class Dataseedingtest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Description", "Heading" },
                values: new object[] { 1, "Finally some good news, for the Nismo motorsport team fans!", "Nissan Won Le Mans" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Description", "NewsId" },
                values: new object[] { 1, "I was starting to loose hope.", 1 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Description", "NewsId" },
                values: new object[] { 2, "Go go NISMO.", 1 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Description", "NewsId" },
                values: new object[] { 3, "I told you Alex Buncombe is a fast pilot!!!", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}

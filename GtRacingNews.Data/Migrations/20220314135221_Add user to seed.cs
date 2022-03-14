using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GtRacingNews.Data.Migrations
{
    public partial class Addusertoseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0aba50d0-9907-4442-8bf7-75fd9a1047d3", 0, "0512ef3b-1e61-45d5-bccb-38a5b4d716a6", "svilen@email.com", false, false, null, null, null, "svilen123", null, false, "8d36433f-e04b-4eda-8176-2a73f4335eed", false, "svilen" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0aba50d0-9907-4442-8bf7-75fd9a1047d3");
        }
    }
}

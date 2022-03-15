using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GtRacingNews.Data.Migrations
{
    public partial class InitialCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Championships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Championships", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Heading = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CarModel = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChampionshipId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Championships_ChampionshipId",
                        column: x => x.ChampionshipId,
                        principalTable: "Championships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NewsId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_News_NewsId",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Cup = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drivers_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8c31c2b7-ae56-45e1-8e40-4d596a5bbd91", 0, "4d52fc87-a22f-456b-973b-ad6afa0e7b60", "svilen@email.com", false, false, null, null, null, "be7241573aeb418fd695ba0262f4cad259a5b55fc715eb19c233cf02554813a8", null, false, "a4944627-36eb-4612-bd35-b3a6a81498b8", false, "svilen" });

            migrationBuilder.InsertData(
                table: "Championships",
                columns: new[] { "Id", "LogoUrl", "Name" },
                values: new object[,]
                {
                    { 1, "https://www.gt-world-challenge-europe.com/assets/img/fanatec-gtwc-europe-aws.png", "GT Europe Challenge By Fanatec" },
                    { 2, "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f1/SUPER_GT_logo.svg/640px-SUPER_GT_logo.svg.png", "Super GT" },
                    { 3, "https://www.britishgt.com/timthumb.php?w=1600&src=%2Fimages%2F%2Fnews%2FIntelligent_Money_web.jpg", "Britsh GT" }
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Description", "Heading", "PictureUrl" },
                values: new object[,]
                {
                    { 1, "Finally some good news, for the Nismo motorsport team fans!", "Nissan has won LeMans", "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5b/Nissan_Motorsports_-_Nissan_GT-R_LM_Nismo_-23_%2818860958202%29.jpg/1200px-Nissan_Motorsports_-_Nissan_GT-R_LM_Nismo_-23_%2818860958202%29.jpg" },
                    { 2, "The new dates are 13-15 May!", "Bathurst 2022 with new dates!", "https://upload.wikimedia.org/wikipedia/en/3/3a/Bathurst_12_hour_logo.png" },
                    { 3, "Orange 1 fff racing reveals new team driver!", "The name of the newest driver is Mirko Bortolotti", "https://www.orange1.eu/wp-content/uploads/2022/02/241309495_394364622049303_9048975734763248286_n-2.jpg" },
                    { 4, "Emil Fray steals the title!", "For some it's a beginners luck, for others Emil Fray kicks ass!", "https://www.rmpaint.com/sites/default/files/news/images/DJI_0631-Edit.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Races",
                columns: new[] { "Id", "Date", "Name" },
                values: new object[,]
                {
                    { 1, "12/12/2022", "24h Spa 2022" },
                    { 2, "06/05/2022", "24h Le Mans 2022" },
                    { 3, "23/3/2022", "Imola 1000 kilometers" },
                    { 4, "4/08/2022", "Brands Hatch" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Description", "NewsId", "UserName" },
                values: new object[,]
                {
                    { 1, "Finally!!!", 1, "svilen" },
                    { 2, "I told you Alex Buncome is a fast driver", 1, "svilen" },
                    { 3, "It's not like we haven't waited for the past two years!", 2, "svilen" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CarModel", "ChampionshipId", "LogoUrl", "Name" },
                values: new object[,]
                {
                    { 1, "Lamborghini Huracan GT-3 Evo", 1, "https://logovectordl.com/wp-content/uploads/2020/05/emil-frey-gruppe-logo-vector.png", "Emil Frey" },
                    { 2, "Nissan GT-R", 2, "https://cdn.wallpapersafari.com/48/24/FXydg6.jpg", "Nismo Motorsport" },
                    { 3, "Lamborghini Huracan GT-3 Evo", 1, "https://www.fff-racingteam.com/wp-content/uploads/2019/02/logo.png", "Orange 1 FFF Racing" },
                    { 4, "Bentley Continental GT3", 3, "data:image/jpeg;base64,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", "Asseto Motorsport" }
                });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "Age", "Cup", "ImageUrl", "Name", "TeamId" },
                values: new object[,]
                {
                    { 1, 45, "Pro", "https://www.intercontinentalgtchallenge.com/timthumb.php?w=640&src=%2Fimages%2Fdrivers%2FRolf_Ineichen2018.jpg", "Rolf Ineichen", 1 },
                    { 2, 25, "Pro", "https://www.gt-world-challenge-europe.com/timthumb.php?w=320&src=%2Fimages%2Fdrivers%2Fphoto_2578.jpg", "Ricardo Feller", 1 },
                    { 3, 29, "Pro", "data:image/jpeg;base64,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", "Alex Buncombe", 2 },
                    { 4, 37, "Pro", "https://www.gt-world-challenge-europe.com/timthumb.php?w=320&src=%2Fimages%2Fdrivers%2Fkatsumasa_chiyo.jpg", "Katsumasa Chiyo", 2 },
                    { 5, 19, "Pro", "https://www.gt-world-challenge-europe.com/timthumb.php?w=320&src=%2Fimages%2Fdrivers%2Fphoto_2635.jpg", "Mirko Bortolotti", 3 },
                    { 6, 29, "Pro", "https://www.gt-world-challenge-europe.com/timthumb.php?w=320&src=%2Fimages%2Fdrivers%2Fphoto_2636.jpg", "Marko Mappeli", 3 },
                    { 7, 45, "Pro-Am", "https://www.britishgt.com/timthumb.php?w=320&src=%2Fimages%2Fdrivers%2Fdriver_854.png", "Mark Sanson", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_NewsId",
                table: "Comments",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_TeamId",
                table: "Drivers",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_ChampionshipId",
                table: "Teams",
                column: "ChampionshipId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Races");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Championships");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Poker.API.Migrations
{
    public partial class InitialMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PokerHands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Card1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Card2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Card3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Card4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Card5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokerHands", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "PokerHands",
                columns: new[] { "Id", "Card1", "Card2", "Card3", "Card4", "Card5", "DateCreated", "PlayerName", "Type" },
                values: new object[,]
                {
                    { new Guid("a9ff5f60-3500-4311-bdac-3faacdeb92b1"), "AH", "AS", "AD", "AC", "2H", new DateTimeOffset(new DateTime(2021, 3, 28, 20, 47, 59, 506, DateTimeKind.Unspecified).AddTicks(8130), new TimeSpan(0, -4, 0, 0, 0)), "Berry", "Four of a Kind" },
                    { new Guid("8d6e84de-47ce-4561-9a41-5215eb26526b"), "KC", "2C", "3C", "4C", "8C", new DateTimeOffset(new DateTime(2021, 3, 28, 20, 47, 59, 508, DateTimeKind.Unspecified).AddTicks(9326), new TimeSpan(0, -4, 0, 0, 0)), "Jerry", "Flush" },
                    { new Guid("7d6e84de-47ce-4561-9a41-5215eb26526b"), "KH", "2H", "3H", "4H", "9H", new DateTimeOffset(new DateTime(2021, 3, 28, 20, 47, 59, 508, DateTimeKind.Unspecified).AddTicks(9419), new TimeSpan(0, -4, 0, 0, 0)), "Jerry", "Flush" },
                    { new Guid("6d6e84de-47ce-4561-9a41-5215eb26526b"), "QC", "2D", "7C", "5S", "5H", new DateTimeOffset(new DateTime(2021, 3, 28, 20, 47, 59, 508, DateTimeKind.Unspecified).AddTicks(9431), new TimeSpan(0, -4, 0, 0, 0)), "Jerry", "Pair" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PokerHands");
        }
    }
}

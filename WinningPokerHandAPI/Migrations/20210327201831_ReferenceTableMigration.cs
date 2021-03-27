using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Poker.API.Migrations
{
    public partial class ReferenceTableMigration : Migration
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
                values: new object[] { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "AH", "AS", "AD", "AC", "2H", new DateTimeOffset(new DateTime(2021, 3, 27, 16, 18, 31, 372, DateTimeKind.Unspecified).AddTicks(1403), new TimeSpan(0, -4, 0, 0, 0)), "Berry", "4kind" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PokerHands");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Poker.API.Migrations
{
    public partial class InitialMigration : Migration
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
                    { new Guid("a9ff5f60-3500-4311-bdac-3faacdeb92b1"), "AH", "AS", "AD", "AC", "2H", new DateTimeOffset(new DateTime(2021, 3, 28, 21, 33, 19, 701, DateTimeKind.Unspecified).AddTicks(2128), new TimeSpan(0, -4, 0, 0, 0)), "Berry", "Four of a Kind" },
                    { new Guid("ab28069b-97a6-408d-afee-81faf0360427"), "2D", "2H", "2D", "10D", "10H", new DateTimeOffset(new DateTime(2021, 3, 28, 21, 33, 19, 703, DateTimeKind.Unspecified).AddTicks(5599), new TimeSpan(0, -4, 0, 0, 0)), "Daniel Negranu", "Full House" },
                    { new Guid("28da5c8d-1577-4bd5-9210-73f859fd8533"), "2H", "7D", "6D", "QC", "4S", new DateTimeOffset(new DateTime(2021, 3, 28, 21, 33, 19, 703, DateTimeKind.Unspecified).AddTicks(5592), new TimeSpan(0, -4, 0, 0, 0)), "Tony G", "High Card" },
                    { new Guid("5c06ab27-125f-4a9c-aa0a-f1695aef4271"), "2S", "7C", "6S", "QD", "4C", new DateTimeOffset(new DateTime(2021, 3, 28, 21, 33, 19, 703, DateTimeKind.Unspecified).AddTicks(5585), new TimeSpan(0, -4, 0, 0, 0)), "Phil Hellmuth", "High Card" },
                    { new Guid("a9118362-fb36-4b8a-a657-4d28d673a593"), "2D", "7H", "6H", "10D", "4H", new DateTimeOffset(new DateTime(2021, 3, 28, 21, 33, 19, 703, DateTimeKind.Unspecified).AddTicks(5579), new TimeSpan(0, -4, 0, 0, 0)), "Daniel Negranu", "High Card" },
                    { new Guid("659cf963-4dbd-4053-834f-440ccc402095"), "2H", "7D", "6D", "QC", "4S", new DateTimeOffset(new DateTime(2021, 3, 28, 21, 33, 19, 703, DateTimeKind.Unspecified).AddTicks(5572), new TimeSpan(0, -4, 0, 0, 0)), "Tony G", "High Card" },
                    { new Guid("55744fa9-4334-4e2e-a1ff-70360dd025f7"), "2S", "7C", "6S", "QD", "4C", new DateTimeOffset(new DateTime(2021, 3, 28, 21, 33, 19, 703, DateTimeKind.Unspecified).AddTicks(5566), new TimeSpan(0, -4, 0, 0, 0)), "Phil Hellmuth", "High Card" },
                    { new Guid("82029ec5-4331-44f3-b73f-8ecc10826b92"), "2D", "7H", "6H", "QS", "4H", new DateTimeOffset(new DateTime(2021, 3, 28, 21, 33, 19, 703, DateTimeKind.Unspecified).AddTicks(5559), new TimeSpan(0, -4, 0, 0, 0)), "Daniel Negranu", "High Card" },
                    { new Guid("9051d0d7-6a10-4c23-8b67-1f48fe798a1d"), "2H", "6H", "3D", "4S", "5H", new DateTimeOffset(new DateTime(2021, 3, 28, 21, 33, 19, 703, DateTimeKind.Unspecified).AddTicks(5552), new TimeSpan(0, -4, 0, 0, 0)), "Daniel Negranu", "Straight" },
                    { new Guid("4d42a8e7-c322-4dd5-9b0e-444600da70d4"), "AH", "KH", "10H", "JH", "QH", new DateTimeOffset(new DateTime(2021, 3, 28, 21, 33, 19, 703, DateTimeKind.Unspecified).AddTicks(5546), new TimeSpan(0, -4, 0, 0, 0)), "Phil Hellmuth", "Straight Flush" },
                    { new Guid("18888494-243a-4293-b1b2-364c5fade6fa"), "3H", "7D", "6D", "QC", "4S", new DateTimeOffset(new DateTime(2021, 3, 28, 21, 33, 19, 703, DateTimeKind.Unspecified).AddTicks(5539), new TimeSpan(0, -4, 0, 0, 0)), "Tony G", "High Card" },
                    { new Guid("45aa9d27-16f2-4a81-9528-06fc6393ee5b"), "2S", "7C", "6S", "QD", "4C", new DateTimeOffset(new DateTime(2021, 3, 28, 21, 33, 19, 703, DateTimeKind.Unspecified).AddTicks(5529), new TimeSpan(0, -4, 0, 0, 0)), "Phil Hellmuth", "High Card" },
                    { new Guid("5832f956-2600-4175-b8f3-7f1df28d8b16"), "2D", "7H", "6H", "QS", "4H", new DateTimeOffset(new DateTime(2021, 3, 28, 21, 33, 19, 703, DateTimeKind.Unspecified).AddTicks(5492), new TimeSpan(0, -4, 0, 0, 0)), "Daniel Negranu", "High Card" },
                    { new Guid("6d6e84de-47ce-4561-9a41-5215eb26526b"), "QC", "2D", "7C", "5S", "5H", new DateTimeOffset(new DateTime(2021, 3, 28, 21, 33, 19, 703, DateTimeKind.Unspecified).AddTicks(4243), new TimeSpan(0, -4, 0, 0, 0)), "Jerry", "Pair" },
                    { new Guid("7d6e84de-47ce-4561-9a41-5215eb26526b"), "KH", "2H", "3H", "4H", "9H", new DateTimeOffset(new DateTime(2021, 3, 28, 21, 33, 19, 703, DateTimeKind.Unspecified).AddTicks(4230), new TimeSpan(0, -4, 0, 0, 0)), "Jerry", "Flush" },
                    { new Guid("8d6e84de-47ce-4561-9a41-5215eb26526b"), "KC", "2C", "3C", "4C", "8C", new DateTimeOffset(new DateTime(2021, 3, 28, 21, 33, 19, 703, DateTimeKind.Unspecified).AddTicks(4142), new TimeSpan(0, -4, 0, 0, 0)), "Jerry", "Flush" },
                    { new Guid("9611fc8d-956e-462a-b1b7-1c30f6cc601d"), "4S", "4C", "4S", "QD", "5C", new DateTimeOffset(new DateTime(2021, 3, 28, 21, 33, 19, 703, DateTimeKind.Unspecified).AddTicks(5606), new TimeSpan(0, -4, 0, 0, 0)), "Phil Hellmuth", "Three of a Kind" },
                    { new Guid("93767f99-7c0a-44af-9930-93ad5e323021"), "8H", "8D", "9D", "9C", "6H", new DateTimeOffset(new DateTime(2021, 3, 28, 21, 33, 19, 703, DateTimeKind.Unspecified).AddTicks(5613), new TimeSpan(0, -4, 0, 0, 0)), "Tony G", "Two Pair" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PokerHands");
        }
    }
}

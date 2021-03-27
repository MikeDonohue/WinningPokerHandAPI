using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WinningPokerHandAPI.Migrations
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
                    PlayerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokerHands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    HandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CardId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => new { x.HandId, x.CardId });
                    table.ForeignKey(
                        name: "FK_Cards_PokerHands_HandId",
                        column: x => x.HandId,
                        principalTable: "PokerHands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PokerHands",
                columns: new[] { "Id", "DateCreated", "PlayerName", "Type" },
                values: new object[] { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), new DateTimeOffset(new DateTime(2021, 3, 26, 22, 0, 16, 771, DateTimeKind.Unspecified).AddTicks(3481), new TimeSpan(0, -4, 0, 0, 0)), "Berry", null });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "CardId", "HandId" },
                values: new object[,]
                {
                    { "2C", new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35") },
                    { "3C", new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35") },
                    { "4C", new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35") },
                    { "5C", new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35") },
                    { "6C", new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "PokerHands");
        }
    }
}

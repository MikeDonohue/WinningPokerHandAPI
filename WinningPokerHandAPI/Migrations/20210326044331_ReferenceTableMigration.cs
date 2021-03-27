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
                    PlayerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cards = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokerHands", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "PokerHands",
                columns: new[] { "Id", "Cards", "DateCreated", "PlayerName" },
                values: new object[] { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "AHACADAS2H", new DateTimeOffset(new DateTime(2021, 3, 26, 0, 43, 30, 659, DateTimeKind.Unspecified).AddTicks(3033), new TimeSpan(0, -4, 0, 0, 0)), "Berry" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PokerHands");
        }
    }
}

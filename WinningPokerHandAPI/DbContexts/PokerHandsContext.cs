using Microsoft.EntityFrameworkCore;
using System;
using Poker.API.DataObjects.Entities;

namespace Poker.API.DbContexts
{
    public class PokerHandsContext : DbContext
    {
        public PokerHandsContext(DbContextOptions<PokerHandsContext> options)
           : base(options)
        {
        }

        public DbSet<PokerHand> PokerHands { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // to add additional tables/dummy data
            modelBuilder.Entity<PokerHand>().HasData(new PokerHand()
            {
                Id = Guid.Parse("a9ff5f60-3500-4311-bdac-3faacdeb92b1"),
                PlayerName = "Berry",
                DateCreated = DateTime.Now,
                Type = "Four of a Kind",
                Card1 = "AH",
                Card2 = "AS",
                Card3 = "AD",
                Card4 = "AC",
                Card5 = "2H"
            },
            new PokerHand()
            {
                Id = Guid.Parse("8d6e84de-47ce-4561-9a41-5215eb26526b"),
                PlayerName = "Jerry",
                DateCreated = DateTime.Now,
                Type = "Flush",
                Card1 = "KC",
                Card2 = "2C",
                Card3 = "3C",
                Card4 = "4C",
                Card5 = "8C"
            },
            new PokerHand()
            {
                Id = Guid.Parse("7d6e84de-47ce-4561-9a41-5215eb26526b"),
                PlayerName = "Jerry",
                DateCreated = DateTime.Now,
                Type = "Flush",
                Card1 = "KH",
                Card2 = "2H",
                Card3 = "3H",
                Card4 = "4H",
                Card5 = "9H"
            },
            new PokerHand()
            {
                Id = Guid.Parse("6d6e84de-47ce-4561-9a41-5215eb26526b"),
                PlayerName = "Jerry",
                DateCreated = DateTime.Now,
                Type = "Pair",
                Card1 = "QC",
                Card2 = "2D",
                Card3 = "7C",
                Card4 = "5S",
                Card5 = "5H"
            },
            CreateTestPokerHandDto("5832f956-2600-4175-b8f3-7f1df28d8b16", "Daniel Negranu", "High Card", "2D", "7H", "6H", "QS", "4H"),
            CreateTestPokerHandDto("45aa9d27-16f2-4a81-9528-06fc6393ee5b", "Phil Hellmuth", "High Card", "2S", "7C", "6S", "QD", "4C"),
            CreateTestPokerHandDto("18888494-243a-4293-b1b2-364c5fade6fa", "Tony G", "High Card", "3H", "7D", "6D", "QC", "4S"),
            CreateTestPokerHandDto("4d42a8e7-c322-4dd5-9b0e-444600da70d4", "Phil Hellmuth", "Straight Flush", "AH", "KH", "10H", "JH", "QH"),
            CreateTestPokerHandDto("9051d0d7-6a10-4c23-8b67-1f48fe798a1d", "Daniel Negranu", "Straight", "2H", "6H", "3D", "4S", "5H"),
            CreateTestPokerHandDto("82029ec5-4331-44f3-b73f-8ecc10826b92", "Daniel Negranu", "High Card", "2D", "7H", "6H", "QS", "4H"),
            CreateTestPokerHandDto("55744fa9-4334-4e2e-a1ff-70360dd025f7", "Phil Hellmuth", "High Card", "2S", "7C", "6S", "QD", "4C"),
            CreateTestPokerHandDto("659cf963-4dbd-4053-834f-440ccc402095", "Tony G", "High Card", "2H", "7D", "6D", "QC", "4S"),
            CreateTestPokerHandDto("a9118362-fb36-4b8a-a657-4d28d673a593", "Daniel Negranu", "High Card", "2D", "7H", "6H", "10D", "4H"),
            CreateTestPokerHandDto("5c06ab27-125f-4a9c-aa0a-f1695aef4271", "Phil Hellmuth", "High Card", "2S", "7C", "6S", "QD", "4C"),
            CreateTestPokerHandDto("28da5c8d-1577-4bd5-9210-73f859fd8533", "Tony G", "High Card", "2H", "7D", "6D", "QC", "4S"),
            CreateTestPokerHandDto("ab28069b-97a6-408d-afee-81faf0360427", "Daniel Negranu", "Full House", "2D", "2H", "2D", "10D", "10H"),
            CreateTestPokerHandDto("9611fc8d-956e-462a-b1b7-1c30f6cc601d", "Phil Hellmuth", "Three of a Kind", "4S", "4C", "4D", "QD", "5C"),
            CreateTestPokerHandDto("93767f99-7c0a-44af-9930-93ad5e323021", "Tony G", "Two Pair", "8H", "8D", "9D", "9C", "6H"),
            CreateTestPokerHandDto("655861ee-8a2d-4e8b-9d43-34b050150f11", "Phil Hellmuth", "Pair", "4S", "4C", "6S", "QD", "5C"),
            CreateTestPokerHandDto("5a8222f5-114a-4fd0-b7fb-f28b40796b2e", "Tony G", "Pair", "2H", "8D", "9D", "10C", "8H"));

            base.OnModelCreating(modelBuilder);
        }

        private PokerHand CreateTestPokerHandDto(string guid, string name, string type, string card1, string card2, string card3, string card4, string card5)
        {
            return new PokerHand()
            {
                Id = Guid.Parse(guid),
                PlayerName = name,
                DateCreated = DateTime.Now,
                Type = type,
                Card1 = card1,
                Card2 = card2,
                Card3 = card3,
                Card4 = card4,
                Card5 = card5
            };
        }

    }
}

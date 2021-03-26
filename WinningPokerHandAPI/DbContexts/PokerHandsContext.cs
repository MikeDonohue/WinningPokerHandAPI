using Microsoft.EntityFrameworkCore;
using System;
using WinningPokerHandAPI.DataObjects.Entities;

namespace WinningPokerHandAPI.DbContexts
{
    public class PokerHandsContext : DbContext
    {
        public PokerHandsContext(DbContextOptions<PokerHandsContext> options)
           : base(options)
        {
        }

        public DbSet<PokerHand> PokerHands { get; set; }

        //public DbSet<Card> Cards { get; set; }

        //reference table


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // to add additional tables/dummy data
            modelBuilder.Entity<PokerHand>().HasData(new PokerHand()
            {
                Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                PlayerName = "Berry",
                DateCreated = DateTime.Now,
                Cards = "AHACADAS2H"
            });

            //modelBuilder.Entity<Card>().HasData(
            //    new Card()
            //    {
            //        Id = "2C",
            //        Rank = 2,
            //        Suit = "Club"
            //    },
            //    new Card()
            //    {
            //        Id = "3C",
            //        Rank = 3,
            //        Suit = "Club"
            //    },
            //    new Card()
            //    {
            //        Id = "4C",
            //        Rank = 4,
            //        Suit = "Club"
            //    },
            //    new Card()
            //    {
            //        Id = "5C",
            //        Rank = 5,
            //        Suit = "Club"
            //    },
            //    new Card()
            //    {
            //        Id = "6C",
            //        Rank = 6,
            //        Suit = "Club"
            //    },
            //    new Card()
            //    {
            //        Id = "7C",
            //        Rank = 7,
            //        Suit = "Club"
            //    },
            //    new Card()
            //    {
            //        Id = "8C",
            //        Rank = 8,
            //        Suit = "Club"
            //    },
            //    new Card()
            //    {
            //        Id = "9C",
            //        Rank = 9,
            //        Suit = "Club"
            //    },
            //    new Card()
            //    {
            //        Id = "10C",
            //        Rank = 10,
            //        Suit = "Club"
            //    },
            //    new Card()
            //    {
            //        Id = "JC",
            //        Rank = 11,
            //        Suit = "Club"
            //    },
            //    new Card()
            //    {
            //        Id = "QC",
            //        Rank = 12,
            //        Suit = "Club"
            //    },
            //    new Card()
            //    {
            //        Id = "KC",
            //        Rank = 13,
            //        Suit = "Club"
            //    },
            //    new Card()
            //    {
            //        Id = "AC",
            //        Rank = 14,
            //        Suit = "Club"
            //    },
            //    new Card()
            //    {
            //        Id = "2D",
            //        Rank = 2,
            //        Suit = "Diamond"
            //    },
            //    new Card()
            //    {
            //        Id = "3D",
            //        Rank = 3,
            //        Suit = "Diamond"
            //    },
            //    new Card()
            //    {
            //        Id = "4D",
            //        Rank = 4,
            //        Suit = "Diamond"
            //    },
            //    new Card()
            //    {
            //        Id = "5D",
            //        Rank = 5,
            //        Suit = "Diamond"
            //    },
            //    new Card()
            //    {
            //        Id = "6D",
            //        Rank = 6,
            //        Suit = "Diamond"
            //    },
            //    new Card()
            //    {
            //        Id = "7D",
            //        Rank = 7,
            //        Suit = "Diamond"
            //    },
            //    new Card()
            //    {
            //        Id = "8D",
            //        Rank = 8,
            //        Suit = "Diamond"
            //    },
            //    new Card()
            //    {
            //        Id = "9D",
            //        Rank = 9,
            //        Suit = "Diamond"
            //    },
            //    new Card()
            //    {
            //        Id = "10D",
            //        Rank = 10,
            //        Suit = "Diamond"
            //    },
            //    new Card()
            //    {
            //        Id = "JD",
            //        Rank = 11,
            //        Suit = "Diamond"
            //    },
            //    new Card()
            //    {
            //        Id = "QD",
            //        Rank = 12,
            //        Suit = "Diamond"
            //    },
            //    new Card()
            //    {
            //        Id = "KD",
            //        Rank = 13,
            //        Suit = "Diamond"
            //    },
            //    new Card()
            //    {
            //        Id = "AD",
            //        Rank = 14,
            //        Suit = "Diamond"
            //    },
            //    new Card()
            //    {
            //        Id = "2H",
            //        Rank = 2,
            //        Suit = "Heart"
            //    },
            //    new Card()
            //    {
            //        Id = "3H",
            //        Rank = 3,
            //        Suit = "Heart"
            //    },
            //    new Card()
            //    {
            //        Id = "4H",
            //        Rank = 4,
            //        Suit = "Heart"
            //    },
            //    new Card()
            //    {
            //        Id = "5H",
            //        Rank = 5,
            //        Suit = "Heart"
            //    },
            //    new Card()
            //    {
            //        Id = "6H",
            //        Rank = 6,
            //        Suit = "Heart"
            //    },
            //    new Card()
            //    {
            //        Id = "7H",
            //        Rank = 7,
            //        Suit = "Heart"
            //    },
            //    new Card()
            //    {
            //        Id = "8H",
            //        Rank = 8,
            //        Suit = "Heart"
            //    },
            //    new Card()
            //    {
            //        Id = "9H",
            //        Rank = 9,
            //        Suit = "Heart"
            //    },
            //    new Card()
            //    {
            //        Id = "10H",
            //        Rank = 10,
            //        Suit = "Heart"
            //    },
            //    new Card()
            //    {
            //        Id = "JH",
            //        Rank = 11,
            //        Suit = "Heart"
            //    },
            //    new Card()
            //    {
            //        Id = "QH",
            //        Rank = 12,
            //        Suit = "Heart"
            //    },
            //    new Card()
            //    {
            //        Id = "KH",
            //        Rank = 13,
            //        Suit = "Heart"
            //    },
            //    new Card()
            //    {
            //        Id = "AH",
            //        Rank = 14,
            //        Suit = "Heart"
            //    },
            //    new Card()
            //    {
            //        Id = "2S",
            //        Rank = 2,
            //        Suit = "Spade"
            //    },
            //    new Card()
            //    {
            //        Id = "3S",
            //        Rank = 3,
            //        Suit = "Spade"
            //    },
            //    new Card()
            //    {
            //        Id = "4S",
            //        Rank = 4,
            //        Suit = "Spade"
            //    },
            //    new Card()
            //    {
            //        Id = "5S",
            //        Rank = 5,
            //        Suit = "Spade"
            //    },
            //    new Card()
            //    {
            //        Id = "6S",
            //        Rank = 6,
            //        Suit = "Spade"
            //    },
            //    new Card()
            //    {
            //        Id = "7S",
            //        Rank = 7,
            //        Suit = "Spade"
            //    },
            //    new Card()
            //    {
            //        Id = "8S",
            //        Rank = 8,
            //        Suit = "Spade"
            //    },
            //    new Card()
            //    {
            //        Id = "9S",
            //        Rank = 9,
            //        Suit = "Spade"
            //    },
            //    new Card()
            //    {
            //        Id = "10S",
            //        Rank = 10,
            //        Suit = "Spade"
            //    },
            //    new Card()
            //    {
            //        Id = "JS",
            //        Rank = 11,
            //        Suit = "Spade"
            //    },
            //    new Card()
            //    {
            //        Id = "QS",
            //        Rank = 12,
            //        Suit = "Spade"
            //    },
            //    new Card()
            //    {
            //        Id = "KS",
            //        Rank = 13,
            //        Suit = "Spade"
            //    },
            //    new Card()
            //    {
            //        Id = "AS",
            //        Rank = 14,
            //        Suit = "Spade"
            //    });

            base.OnModelCreating(modelBuilder);
        }

    }
}

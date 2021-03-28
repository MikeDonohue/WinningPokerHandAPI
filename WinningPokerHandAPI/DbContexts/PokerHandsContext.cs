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
            }
            );

            base.OnModelCreating(modelBuilder);
        }

    }
}

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
                Type = "4kind",
                Card1 = "AH",
                Card2 = "AS",
                Card3 = "AD",
                Card4 = "AC",
                Card5 = "2H"
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}

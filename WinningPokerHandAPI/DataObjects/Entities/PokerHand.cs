using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WinningPokerHandAPI.DataObjects.Entities
{
    public class PokerHand
    {
        public PokerHand()
        {
            this.Cards = new HashSet<Card>();
        }
        public Guid Id { get; set; }

        public string PlayerName { get; set; }
        public string Type { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public ICollection<Card> Cards { get; set; }
    }
}

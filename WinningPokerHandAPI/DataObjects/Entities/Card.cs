using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WinningPokerHandAPI.DataObjects.Entities
{
    public class Card
    {
        public Guid HandId;

        public string CardId;

        public int Rank;

        public string Suit;

        public PokerHand PokerHand { get; set; }
    }
}

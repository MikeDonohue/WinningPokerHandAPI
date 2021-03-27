using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace Poker.API.Helpers
{
    public class Card
    {
        public int Rank;
        public string Suit;
    }
}

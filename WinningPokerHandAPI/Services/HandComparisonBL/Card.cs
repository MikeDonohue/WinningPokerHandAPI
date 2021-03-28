using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace Poker.API.Services.HandComparisonBL
{
    public class Card
    {
        public int Rank;
        public string Suit;
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace Poker.API.Services.HandComparisonBL
{
    public class CardFrequency
    {
        public int Rank;
        public int Frequency;
    }
}

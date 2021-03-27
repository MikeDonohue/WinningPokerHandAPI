using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace Poker.API.Helpers
{
    public class CardFrequency
    {
        public int Rank;
        public int Frequency;
    }
}

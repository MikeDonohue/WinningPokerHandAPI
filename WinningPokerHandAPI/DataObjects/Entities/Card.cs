using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace WinningPokerHandAPI.DataObjects.Entities
{
    [Keyless]
    public class Card
    {
        [Required]
        public string Id;

        [Required]
        public int Rank;

        [Required]
        public string Suit;

    }
}

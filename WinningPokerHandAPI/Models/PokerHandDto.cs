using System;

namespace WinningPokerHandAPI.Models
{
    public class PokerHandDto
    {
        public string PokerPlayer { get; set; }

        public CardDto[] Cards { get; set; }
    }
}

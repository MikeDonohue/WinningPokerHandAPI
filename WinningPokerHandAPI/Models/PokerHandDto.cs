using System;

namespace WinningPokerHandAPI.Models
{
    public class PokerHandDto
    {
        public PokerPlayerDto HandOwner { get; set; }

        public CardDto[] Cards { get; set; }
    }
}

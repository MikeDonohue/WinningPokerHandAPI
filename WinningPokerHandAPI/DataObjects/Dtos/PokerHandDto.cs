using System;

namespace WinningPokerHandAPI.DataObjects.Dtos
{
    public class PokerHandDto
    {
        public Guid Id { get; set; }

        public string PokerPlayerName { get; set; }
       
        public string Cards { get; set; }

        public DateTimeOffset DateCreated { get; set; }
    }
}

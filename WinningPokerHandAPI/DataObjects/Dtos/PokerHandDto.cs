using System;
using System.Collections.Generic;

namespace WinningPokerHandAPI.DataObjects.Dtos
{
    public class PokerHandDto
    {
        public Guid Id { get; set; }

        public string PlayerName { get; set; }
       
        public ICollection<string> Cards { get; set; }

        public DateTimeOffset DateCreated { get; set; }
    }
}

using System;

namespace Poker.API.DataObjects.Dtos
{
    public class PokerHandDto : PokerHandForCreationDto
    {
        public Guid Id { get; set; }

        public DateTimeOffset DateCreated { get; set; }

        public string Type { get; set; }
    }
}

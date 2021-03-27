using System;

namespace WinningPokerHandAPI.DataObjects.Dtos
{
    public class PokerHandDto : PokerHandForCreationDto
    {
        public Guid Id { get; set; }

        public DateTimeOffset DateCreated { get; set; }

        public string Type { get; set; }
    }
}

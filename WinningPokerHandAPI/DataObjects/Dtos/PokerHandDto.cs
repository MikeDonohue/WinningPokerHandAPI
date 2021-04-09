using System;

namespace Poker.API.DataObjects.Dtos
{
    public class PokerHandDto : PokerHandForCreationDto
    {
        /// <summary>
        /// The unique id of the poker hand.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Datetime of when the poker hand was created.
        /// </summary>
        public DateTimeOffset DateCreated { get; set; }

        /// <summary>
        /// The type of hand.
        /// </summary>
        public string Type { get; set; }
    }
}

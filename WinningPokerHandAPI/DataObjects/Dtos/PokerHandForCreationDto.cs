using Poker.API.DataObjects.ValidationAttributes;
using Poker.API.Services.HandComparisonBL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Poker.API.DataObjects.Dtos
{
    [CardsMustBeApprovedAttribute]
    [CardsMustBeUniqueAttribute]
    public class PokerHandForCreationDto
    {
        [MaxLength(100, ErrorMessage = "Player Name can be no longer than 100 characters.")]
        [MinLength(4, ErrorMessage = "Player Name must be at least 4 characters long.")]
        [Required(ErrorMessage = "Player Name is a required field.")]
        public string PlayerName { get; set; }

        [Required]
        public string Card1 { get; set; }
        [Required]
        public string Card2 { get; set; }
        [Required]
        public string Card3 { get; set; }
        [Required]
        public string Card4 { get; set; }
        [Required]
        public string Card5 { get; set; }
    }
}

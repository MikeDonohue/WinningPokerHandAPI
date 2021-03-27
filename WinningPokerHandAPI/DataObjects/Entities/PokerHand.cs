using System;
using System.ComponentModel.DataAnnotations;

namespace Poker.API.DataObjects.Entities
{
    public class PokerHand
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string PlayerName { get; set; }

        //With more time changed to a reference table
        [Required]
        public string Type { get; set; }

        //Ideally I would have put cards in a seperate table using a 
        //composite key of pokerhandId and card text.
        //cut due to time limitations
        //could be expanded to include things like order draw and other data
        [Required]
        [StringLength(2)]
        public string Card1 { get; set; }

        [Required]
        [StringLength(2)]
        public string Card2 { get; set; }

        [Required]
        [StringLength(2)]
        public string Card3 { get; set; }

        [Required]
        [StringLength(2)]
        public string Card4 { get; set; }

        [Required]
        [StringLength(2)]
        public string Card5 { get; set; }

        [Required]
        public DateTimeOffset DateCreated { get; set; }
    }
}

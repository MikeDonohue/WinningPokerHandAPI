using System;
using System.ComponentModel.DataAnnotations;

namespace WinningPokerHandAPI.DataObjects.Entities
{
    public class PokerHand
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string PlayerName { get; set; }

        [Required]
        [StringLength(10)]
        public string Cards { get; set; }

        [Required]
        public DateTimeOffset DateCreated { get; set; }
    }
}

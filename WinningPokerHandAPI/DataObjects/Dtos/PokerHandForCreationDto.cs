using Poker.API.DataObjects.ValidationAttributes;
using Poker.API.Services.HandComparisonBL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Poker.API.DataObjects.Dtos
{
    
    public class PokerHandForCreationDto : IValidatableObject
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

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            bool failedFlag = false;
            List<string> failedVars = new List<string>();

            if (!isCardTextValid(Card1))
            {
                failedFlag = true;
                failedVars.Add("Card1");
            }
            if (!isCardTextValid(Card2))
            {
                failedFlag = true;
                failedVars.Add("Card2");
            }
            if (!isCardTextValid(Card3))
            {
                failedFlag = true;
                failedVars.Add("Card3");
            }
            if (!isCardTextValid(Card4))
            {
                failedFlag = true;
                failedVars.Add("Card4");
            }
            if (!isCardTextValid(Card5))
            {
                failedFlag = true;
                failedVars.Add("Card5");
            }
            if (failedFlag)
            {
                yield return new ValidationResult("Must be a valid card in a deck. Please use the number or first letter of the face card followed by the first letter of the desired suit. For example 2 of clubs is 2C, ten of diamons is 10D, and ace of spaces is AS.", failedVars);
            }

            List<string> checkDiffCardsList = new List<string> { Card1, Card2, Card3, Card4, Card5 };


            if (checkDiffCardsList.Distinct().Count() != checkDiffCardsList.Count())
            {
                yield return new ValidationResult("All cards must be unique.", new[] { nameof(PokerHandForCreationDto) });
            }

        }

        private bool isCardTextValid(string cardText)
        {
            if (cardText.Length == 2)
            {
                var char1 = cardText.Substring(0, 1);
                var char2 = cardText.Substring(1, 1);
                if (isNumOrFace(char1) && isSuit(char2))
                    return true;
            }
            else if (cardText.Length == 3)
            {
                var char1 = cardText.Substring(0, 2);
                var char2 = cardText.Substring(2, 1);
                if (char1 == "10" && isSuit(char2))
                    return true;
            }
            return false;
        }

        private bool isSuit(string suit)
        {
            if (suit == "H" || suit == "D" || suit == "C" || suit == "S")
            {
                return true;
            }
            return false;
        }

        private bool isNumOrFace(string char1)
        {
            if (char1 == "J" || char1 == "Q" || char1 == "K" || char1 == "A"
                || char1 == "2" || char1 == "3" || char1 == "4" || char1 == "5"
                || char1 == "6" || char1 == "7" || char1 == "8" || char1 == "9")
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}

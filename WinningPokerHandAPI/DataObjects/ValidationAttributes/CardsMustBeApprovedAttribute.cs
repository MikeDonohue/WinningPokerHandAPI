using Poker.API.DataObjects.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Poker.API.DataObjects.ValidationAttributes
{
    /// <summary>
    /// Class CardsMustBeApprovedAttribute. Checks to see if object is present in approved card dict.
    /// Implements the <see cref="System.ComponentModel.DataAnnotations.ValidationAttribute" />
    /// </summary>
    /// <seealso cref="System.ComponentModel.DataAnnotations.ValidationAttribute" />
    public class CardsMustBeApprovedAttribute : ValidationAttribute
    {
        private static string errorMessage = "Must be a valid card in a deck. Please use the number or first letter of the face card followed by the first letter of the desired suit. For example 2 of clubs is 2C, ten of diamons is 10D, and ace of spaces is AS.";

        protected override ValidationResult IsValid(object value, 
            ValidationContext validationContext)
        {
            var pokerHand = (PokerHandForCreationDto)validationContext.ObjectInstance;
            bool failedFlag = false;
            List<string> failedVars = new List<string>();

            if (!isCardTextValid(pokerHand.Card1))
            {
                failedFlag = true;
                failedVars.Add("Card1");
            }
            if(!isCardTextValid(pokerHand.Card2))
            {
                failedFlag = true;
                failedVars.Add("Card2");
            }
            if (!isCardTextValid(pokerHand.Card3))
            {
                failedFlag = true;
                failedVars.Add("Card3");
            }
            if (!isCardTextValid(pokerHand.Card4))
            {
                failedFlag = true;
                failedVars.Add("Card4");
            }
            if (!isCardTextValid(pokerHand.Card5))
            {
                failedFlag = true;
                failedVars.Add("Card5");
            }
            if (failedFlag)
            {
                return new ValidationResult(errorMessage, failedVars);
            }

            return ValidationResult.Success;
        }

        private bool isCardTextValid(string cardText)
        {
            if (cardText.Length == 2)
            {
                var char1 = cardText.Substring(0, 1);
                var char2 = cardText.Substring(1, 1);
                if(isNumOrFace(char1) && isSuit(char2))
                    return true;
            }
            else if(cardText.Length == 3)
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
            if(suit == "H" || suit == "D" || suit == "C" || suit == "S")
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
    }
}

using Poker.API.DataObjects.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Poker.API.DataObjects.ValidationAttributes
{
    /// <summary>
    /// Class CardsMustBeUniqueAttribute.
    /// Implements the <see cref="System.ComponentModel.DataAnnotations.ValidationAttribute" />
    /// </summary>
    /// <seealso cref="System.ComponentModel.DataAnnotations.ValidationAttribute" />
    public class CardsMustBeUniqueAttribute : ValidationAttribute
    {
        private static string errorMessage = "All cards must be unique.";

        protected override ValidationResult IsValid(object value, 
            ValidationContext validationContext)
        {
            var pokerHand = (PokerHandForCreationDto)validationContext.ObjectInstance;
            List<string> checkDiffCardsList = new List<string>{ pokerHand.Card1, pokerHand.Card2, pokerHand.Card3, pokerHand.Card4, pokerHand.Card5 };

            
            if (checkDiffCardsList.Distinct().Count() != checkDiffCardsList.Count())
            {
                return new ValidationResult(errorMessage, new[] { nameof(PokerHandForCreationDto) });
            }

            return ValidationResult.Success;
        }
 
    }
}

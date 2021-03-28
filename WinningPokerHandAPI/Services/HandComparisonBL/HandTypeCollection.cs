using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Poker.API.Services.HandComparisonBL
{
    /// <summary>
    /// Class HandTypeCollection.
    /// ToDo: move to reference table in db.
    /// </summary>
    public class HandTypeCollection
    {
        private ICollection<HandType> _handRef;

        #region public methods
        public HandTypeCollection()
        {
            _handRef = BuildHandTypeReferenceCollection();
        }

        /// <summary>
        /// Gets the hand type by priority.
        /// </summary>
        /// <param name="priority">The priority.</param>
        /// <returns>HandType.</returns>
        /// <exception cref="ArgumentException">priority must be between 1 to 9</exception>
        public HandType GetHandTypeByPriority(int priority)
        {
            if (priority < 1 || priority > 9)
            {
                throw new ArgumentException(String.Format("{0} is out of bounds. No card priorities less than 1 or greater than 9 exist", priority),
                                      "priority");
            }
            return _handRef.Where(h => h.WinPriority == priority).FirstOrDefault();
        }

        /// <summary>
        /// Gets the name of the hand type by type.
        /// </summary>
        /// <param name="typeName">Name of the type.</param>
        /// <returns>HandType.</returns>
        /// <exception cref="ArgumentNullException">Please provide a non-empty hand type name.</exception>
        /// <exception cref="ArgumentException">Provide a valid hand type.</exception>
        public HandType GetHandTypeByTypeName(string typeName)
        {
            if (string.IsNullOrEmpty(typeName))
            {
                throw new ArgumentNullException("Please provide a non-empty hand type name.");
            }

            var handToReturn = _handRef.Where(h => h.Name == typeName).FirstOrDefault();

            if(handToReturn == null)
            {
                throw new ArgumentException(String.Format("{0} is not a hand type name. Valid Names are Straight Flush, Four of a Kind, Full House, " +
                    "Flush, Straight, Three of a Kind, Two Pairs, Pair, and High Card", typeName), "typeName");
            }
            return handToReturn;
        }
        #endregion

        #region private methods        
        /// <summary>
        /// Builds the hand type reference collection.
        /// List of all hand types in the system.
        /// </summary>
        /// <returns>Collection of hand types.</returns>
        private ICollection<HandType> BuildHandTypeReferenceCollection()
        {
            var handRef = new List<HandType>()
            {
                new HandType()
                {
                    Name = "Straight Flush",
                    WinPriority = 1
                },
                new HandType()
                {
                    Name = "Four of a Kind",
                    WinPriority = 2
                },
                new HandType()
                {
                    Name = "Full House",
                    WinPriority = 3
                },
                new HandType()
                {
                    Name = "Flush",
                    WinPriority = 4
                },
                new HandType()
                {
                    Name = "Straight",
                    WinPriority = 5
                },
                new HandType()
                {
                    Name = "Three of a Kind",
                    WinPriority = 6
                },
                new HandType()
                {
                    Name = "Two Pair",
                    WinPriority = 7
                },
                new HandType()
                {
                    Name = "Pair",
                    WinPriority = 8
                },
                new HandType()
                {
                    Name = "High Card",
                    WinPriority = 9
                }
            };
            return handRef;
        }

        #endregion 
    }
}

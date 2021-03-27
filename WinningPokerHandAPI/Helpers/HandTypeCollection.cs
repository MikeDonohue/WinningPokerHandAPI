using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Poker.API.Helpers
{
    public class HandTypeCollection
    {
        private ICollection<HandType> _handRef;

        #region public methods
        public HandTypeCollection()
        {
            _handRef = BuildHandTypeReferenceCollection();
        }

        public HandType GetHandTypeByPriority(int priority)
        {
            if (priority < 1)
            {
                throw new ArgumentException(String.Format("{0} is out of bounds. No card priorities less than 1 exist", priority),
                                      "priority");
            }
            else if (priority > 8)
            {
                throw new ArgumentException(String.Format("{0} is out of bounds. No card priorities greater than 8 exist", priority),
                                      "priority");
            }
            return _handRef.Where(h => h.WinPriority == priority).FirstOrDefault();
        }

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
                    Name = "Full House",
                    WinPriority = 2
                },
                new HandType()
                {
                    Name = "Flush",
                    WinPriority = 3
                },
                new HandType()
                {
                    Name = "Straight",
                    WinPriority = 4
                },
                new HandType()
                {
                    Name = "Three of a Kind",
                    WinPriority = 5
                },
                new HandType()
                {
                    Name = "Two Pair",
                    WinPriority = 6
                },
                new HandType()
                {
                    Name = "Pair",
                    WinPriority = 7
                },
                new HandType()
                {
                    Name = "High Card",
                    WinPriority = 8
                }
            };
            return handRef;
        }

        private ICollection<HandType> GetHandTypeCollection()
        {
            return _handRef;
        }
        #endregion 
    }
}

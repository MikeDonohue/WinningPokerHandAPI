﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Poker.API.DataObjects.Dtos;
using Poker.API.DataObjects.Entities;

namespace Poker.API.Services.HandComparisonBL
{
    /// <summary>
    /// Class HandComparer.
    /// </summary>
    public class HandComparer
    {
        private ApprovedCardDict _cardDict;
        private HandTypeCollection _handTypes;

        public HandComparer()
        {
            _cardDict = new ApprovedCardDict();
            _handTypes = new HandTypeCollection();
        }

        /// <summary>
        /// Gets the winning hand.
        /// </summary>
        /// <param name="hands">The poker hands.</param>
        /// <returns>List of winning hands. Is a list since ties are possible. Chopped pots.</returns>
        /// <exception cref="ArgumentNullException">hands</exception>
        /// <exception cref="ArgumentException">hands</exception>
        public List<PokerHandDto> GetWinningHand(List<PokerHandDto> hands)
        {
            //null check
            if (hands == null)
            {
                throw new ArgumentNullException(nameof(hands));
            }
            //empty check
            if (!hands.Any())
            {
                throw new ArgumentException(nameof(hands));
            }

            //first winner to first item in list
            List<PokerHandDto> winners = new List<PokerHandDto> { hands[0] };
            var winnerRank = _handTypes.GetHandTypeByTypeName(winners[0].Type).WinPriority;

            for (int i = 1; i < hands.Count(); i++)
            {
                var currentRank = _handTypes.GetHandTypeByTypeName(hands[i].Type).WinPriority;
                if (currentRank < winnerRank)
                {
                    winnerRank = currentRank;
                    winners = new List<PokerHandDto> { hands[i] };
                }
                if(currentRank == winnerRank)
                {
                    winners = CompareKickers(winners, hands[i]);
                }
            }
            return winners;
        }

        /// <summary>
        /// Compares the kickers.
        /// </summary>
        /// <param name="currentWinners">The current winners.</param>
        /// <param name="challenger">The challenger.</param>
        /// <returns>List of winners.</returns>
        private List<PokerHandDto> CompareKickers(List<PokerHandDto> currentWinners, PokerHandDto challenger)
        {
            //if there is more than one currentWinner it is becuase there is already a tie.
            //Therefore the hands are the same so only one needs to be compared
            List<Card> cardsInHand1 = GetCardListFromHand(currentWinners[0]);
            List<Card> cardsInHand2 = GetCardListFromHand(challenger);
            for (int i = 0; i < cardsInHand1.Count(); i++)
            {
                //kickers are the same
                if(cardsInHand1[i].Rank == cardsInHand2[i].Rank)
                {
                    continue;
                }
                //hand1 has better kicker
                else if (cardsInHand1[i].Rank > cardsInHand2[i].Rank)
                {
                    return currentWinners;
                }
                //hand2 has better kicker
                else if (cardsInHand1[i].Rank < cardsInHand2[i].Rank)
                {
                    return new List<PokerHandDto> { challenger };
                }
            }
            //hands are the same. Pot will be chopped.
            currentWinners.Add(challenger);
            return currentWinners;
        }

        /// <summary>
        /// Gets the card list with additional info from hand.
        /// Orders list from highest to lowest value cards
        /// </summary>
        /// <param name="hand">The hand.</param>
        /// <returns>List of cards</returns>
        private List<Card> GetCardListFromHand(PokerHandDto hand)
        {
            List<Card> cardsInHand = new List<Card>();
            cardsInHand.Add(_cardDict.GetCardInfo(hand.Card1));
            cardsInHand.Add(_cardDict.GetCardInfo(hand.Card2));
            cardsInHand.Add(_cardDict.GetCardInfo(hand.Card3));
            cardsInHand.Add(_cardDict.GetCardInfo(hand.Card4));
            cardsInHand.Add(_cardDict.GetCardInfo(hand.Card5));
            cardsInHand = cardsInHand.OrderByDescending(c => c.Rank).ToList();
            return cardsInHand;
        }



       

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Poker.API.DataObjects.Entities;

namespace Poker.API.Services.HandComparisonBL
{
   
    public class HandTypeCalculator
    {
        private ApprovedCardDict _cardDict;
        private HandTypeCollection _handTypes;

        public HandTypeCalculator()
        {
            _cardDict = new ApprovedCardDict();
            _handTypes = new HandTypeCollection();
        }

        /// <summary>
        /// Gets the type of the hand.
        /// </summary>
        /// <param name="hand">The hand.</param>
        /// <returns>HandType.</returns>
        /// <exception cref="ArgumentNullException">Provided poker hand is null.</exception>
        public HandType GetHandType(PokerHand hand)
        {
            //null check
            if(hand == null)
            {
                throw new ArgumentNullException(nameof(hand));
            }

            List<Card> cardsInHand = GetListOfCardsFromHand(hand);

            //check if hand is Straight
            bool isHandStraight = IsHandStraight(cardsInHand);
            //check if hand is flush
            bool isHandFlush = IsHandFlush(cardsInHand);

            //check is hand straight flush
            if (isHandStraight && isHandFlush)
            {
                return _handTypes.GetHandTypeByTypeName("Straight Flush");
            }

            //return if flush
            if (isHandFlush)
            {
                return _handTypes.GetHandTypeByTypeName("Flush");
            }

            //return if straight
            if (isHandStraight)
            {
                return _handTypes.GetHandTypeByTypeName("Straight");
            }

            //Get list of card frequencies
            List<CardFrequency> repeatedHandRankList = new CardFrequencyList().GetCardFrequencyList(cardsInHand);

            //check for quads
            var quads = repeatedHandRankList.Where(cr => cr.Frequency == 4).FirstOrDefault();
            if (quads != null) {
                return _handTypes.GetHandTypeByTypeName("Four of a Kind");
            }

            //check for full house
            var trips = repeatedHandRankList.Where(cr => cr.Frequency == 3).FirstOrDefault();
            if (trips != null)
            {
                //check for full house
                var pairNeededForBoat = repeatedHandRankList.Where(cr => cr.Frequency == 2).FirstOrDefault();
                if (pairNeededForBoat != null)
                {
                    return _handTypes.GetHandTypeByTypeName("Full House");
                }
            }

            //check for trips
            if (trips != null)
            {
                return _handTypes.GetHandTypeByTypeName("Three of a Kind");
            }

            //check for two pair
            var pairs = repeatedHandRankList.Where(cr => cr.Frequency == 2);
            if(pairs.Any())
            {
                if (pairs.Count() == 2) {
                    return _handTypes.GetHandTypeByTypeName("Two Pair");
                }
                //must be pair
                return _handTypes.GetHandTypeByTypeName("Pair");
            }

            //With all other options exausted hand must be a high card
            return _handTypes.GetHandTypeByTypeName("High Card");
        }

        /// <summary>
        /// Determines whether [the specified hand] [is a straight].
        /// </summary>
        /// <param name="hand">The hand.</param>
        /// <returns><c>true</c> if [the specified hand] [is a straight]; otherwise, <c>false</c>.</returns>
        private bool IsHandStraight(List<Card> hand)
        {
            List<Card> orderedHand = hand.OrderByDescending(c => c.Rank).ToList();
            for (int i = 1; i < hand.Count(); i++)
            {
                if (orderedHand[i-1].Rank - orderedHand[i].Rank != 1)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Determines whether [the specified hand] is a flush.
        /// </summary>
        /// <param name="hand">The hand.</param>
        /// <returns><c>true</c> if [the specified hand] is a flush; otherwise, <c>false</c>.</returns>
        private bool IsHandFlush(List<Card> hand)
        {
            string highestCardSuit = hand[0].Suit;
            for (int i = 1; i < hand.Count(); i++)
            {
                if (hand[i].Suit != highestCardSuit)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Gets the list of cards from hand.
        /// </summary>
        /// <param name="hand">The hand.</param>
        /// <returns>List&lt;Card&gt;.</returns>
        private List<Card> GetListOfCardsFromHand(PokerHand hand)
        {
            List<Card> cardsInHand = new List<Card>();
            cardsInHand.Add(_cardDict.GetCardInfo(hand.Card1));
            cardsInHand.Add(_cardDict.GetCardInfo(hand.Card2));
            cardsInHand.Add(_cardDict.GetCardInfo(hand.Card3));
            cardsInHand.Add(_cardDict.GetCardInfo(hand.Card4));
            cardsInHand.Add(_cardDict.GetCardInfo(hand.Card5));
            return cardsInHand;
        }

    }
}

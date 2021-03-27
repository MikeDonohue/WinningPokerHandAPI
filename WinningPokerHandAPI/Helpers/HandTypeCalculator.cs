using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Poker.API.DataObjects.Entities;

namespace Poker.API.Helpers
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

        public HandType GetHandType(PokerHand hand)
        {
            List<Card> cardsInHand = new List<Card>();
            cardsInHand.Add(_cardDict.GetCardInfo(hand.Card1));
            cardsInHand.Add(_cardDict.GetCardInfo(hand.Card2));
            cardsInHand.Add(_cardDict.GetCardInfo(hand.Card3));
            cardsInHand.Add(_cardDict.GetCardInfo(hand.Card4));
            cardsInHand.Add(_cardDict.GetCardInfo(hand.Card5));

            //key is Rank. Value is frequency
            Dictionary<int, int> repeatedHandRanks = new Dictionary<int, int>();
            foreach (var card in cardsInHand)
            {
                if (repeatedHandRanks.ContainsKey(card.Rank))
                {
                    repeatedHandRanks[card.Rank] = repeatedHandRanks[card.Rank] + 1;
                }
                else
                {
                    repeatedHandRanks[card.Rank] = 1;
                }
            }

            //check if hand is Straight
            bool isHandStraight = IsHandStraight(cardsInHand);
            bool isHandFlush = IsHandFlush(cardsInHand);

            //check is hand straight flush
            if (isHandStraight && isHandFlush)
            {
                return _handTypes.GetHandTypeByTypeName("Straight Flush");
            }

            //convert to List to use Linq easily to query collection
            List<CardFrequency> repeatedHandRankList = new List<CardFrequency>();
            foreach (KeyValuePair<int, int> entry in repeatedHandRanks)
            {
                repeatedHandRankList.Add(new CardFrequency() { Rank = entry.Key, Frequency = entry.Value });
            }

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

            //return if flush
            //check is hand straight flush
            if (isHandFlush)
            {
                return _handTypes.GetHandTypeByTypeName("Flush");
            }

            //return if flush
            //check is hand straight flush
            if (isHandStraight)
            {
                return _handTypes.GetHandTypeByTypeName("Straight");
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

    }
}

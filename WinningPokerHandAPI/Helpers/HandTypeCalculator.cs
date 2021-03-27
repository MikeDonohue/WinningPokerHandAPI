using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Poker.API.DataObjects.Entities;

namespace Poker.API.Helpers
{
   
    public class HandTypeCalculator
    {
        ApprovedCardDict _cardDict;

        public HandTypeCalculator()
        {
            _cardDict = new ApprovedCardDict();
        }

        public string GetHandType(PokerHand hand)
        {
            Card[] weightedHand = new Card[5];
            weightedHand[0] = _cardDict.GetCardInfo(hand.Card1);
            weightedHand[1] = _cardDict.GetCardInfo(hand.Card2);
            weightedHand[2] = _cardDict.GetCardInfo(hand.Card3);
            weightedHand[3] = _cardDict.GetCardInfo(hand.Card4);
            weightedHand[4] = _cardDict.GetCardInfo(hand.Card5);

            //Sort from highest to lowest card
            List<Card> OrderedHand = weightedHand.OrderByDescending(c => c.Rank).ToList();

            return "";
        }

        public void GetRepeatedCardRanks(List<Card> orderedHand)
        {
            Dictionary<int, int> repeatedHandRanks = new Dictionary<int, int>();
            foreach(var card in orderedHand)
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
        }

    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Poker.API.Services.HandComparisonBL
{
    public class CardFrequencyList
    {
        //key is Rank. Value is frequency
        public List<CardFrequency> GetCardFrequencyList(List<Card> cardsInHand)
        {
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
            //convert to List to use Linq easily to query collection
            List<CardFrequency> repeatedHandRankList = new List<CardFrequency>();
            foreach (KeyValuePair<int, int> entry in repeatedHandRanks)
            {
                repeatedHandRankList.Add(new CardFrequency() { Rank = entry.Key, Frequency = entry.Value });
            }
            return repeatedHandRankList;
        }
    }
}

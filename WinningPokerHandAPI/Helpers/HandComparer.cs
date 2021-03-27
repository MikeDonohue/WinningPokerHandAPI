using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Poker.API.DataObjects.Entities;

namespace Poker.API.Helpers
{
   
    public class HandComparer
    {
        private ApprovedCardDict _cardDict;
        private HandTypeCollection _handTypes;

        public HandComparer()
        {
            _cardDict = new ApprovedCardDict();
            _handTypes = new HandTypeCollection();
        }

        public List<PokerHand> GetWinningHand(List<PokerHand> hands)
        {
            //first winner to first item in list
            PokerHand winner = hands[0];
            var winnerRank = _handTypes.GetHandTypeByTypeName(winner.Type).WinPriority;

            for (int i = 1; i < hands.Count(); i++)
            {
                var currentRank = _handTypes.GetHandTypeByTypeName(hands[i].Type).WinPriority;
                if (currentRank < winnerRank)
                {
                    winnerRank = currentRank;
                    winner = hands[i];
                }
                if(currentRank == winnerRank)
                {
                    //winner = ()
                }
            }
            return new List<PokerHand> { winner };
        }

        //compare kickers
        private PokerHand CompareKickers()
        {
            //sort based priority
            //loop until one card is better
            //if neither are better return both to indicate a chopped pot
            return null;
        }



       

    }
}

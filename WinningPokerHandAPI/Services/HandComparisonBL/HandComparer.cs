using System;
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
            var winnerWinPriority = _handTypes.GetHandTypeByTypeName(winners[0].Type).WinPriority;

            for (int i = 1; i < hands.Count(); i++)
            {
                var currentWinPriority = _handTypes.GetHandTypeByTypeName(hands[i].Type).WinPriority;
                if (currentWinPriority < winnerWinPriority)
                {
                    winnerWinPriority = currentWinPriority;
                    winners = new List<PokerHandDto> { hands[i] };
                }
                else if(currentWinPriority == winnerWinPriority)
                {
                    winners = ResolveCardRankTie(winners, hands[i], currentWinPriority);
                }
            }
            return winners;
        }

        /// <summary>
        /// Compares hands when they are of the same rank.
        /// </summary>
        /// <param name="currentWinners">The current winners.</param>
        /// <param name="challenger">The challenger.</param>
        /// <param name="handWinPriority">The hand win priority.</param>
        /// <returns>List&lt;PokerHandDto&gt;.</returns>
        private List<PokerHandDto> ResolveCardRankTie(List<PokerHandDto> currentWinners, PokerHandDto challenger, int handWinPriority)
        {
            switch (handWinPriority)
            {
                //Straight Flush
                case 1:
                    return CompareKickers(currentWinners, challenger);
                //Four of a Kind
                case 2:
                    return CompareRankRepatedHand(currentWinners, challenger, 4);
                //Full House
                case 3:
                    return CompareFullHouse(currentWinners, challenger);
                //Flush
                case 4:
                    return CompareKickers(currentWinners, challenger);
                //Straight
                case 5:
                    return CompareKickers(currentWinners, challenger);
                //Three of a Kind
                case 6:
                    return CompareRankRepatedHand(currentWinners, challenger, 3);
                //Two Pair
                case 7:
                    return CompareTwoPairs(currentWinners, challenger);
                //Pair
                case 8:
                    return CompareRankRepatedHand(currentWinners, challenger, 2);
                //High Card
                case 9:
                    return CompareKickers(currentWinners, challenger);
                default:
                    throw new ArgumentException(String.Format("{0} is out of bounds. No card priorities less than 1 or greater than 9 exist", handWinPriority), "priority");
            }
        }

        /// <summary>
        /// Compares the rank repated hand. (Pair, trips, quads)
        /// </summary>
        /// <param name="currentWinners">The current winners.</param>
        /// <param name="challenger">The challenger.</param>
        /// <param name="numberOfRankRepeats">The number of rank repeats.</param>
        /// <returns>List&lt;PokerHandDto&gt;.</returns>
        private List<PokerHandDto> CompareRankRepatedHand(List<PokerHandDto> currentWinners, PokerHandDto challenger, int numberOfRankRepeats)
        {
            //Card Freq list to query
            //Hand 1
            List<Card> currentWinnersCards = GetCardListFromHand(currentWinners[0]);
            List<CardFrequency> currentWinnersCardRankList = new CardFrequencyList().GetCardFrequencyList(currentWinnersCards);
            //Hand 2
            List<Card> challengersCards = GetCardListFromHand(challenger);
            List<CardFrequency> challengerscardRankList = new CardFrequencyList().GetCardFrequencyList(challengersCards);

            int currentWinnerscardRank = currentWinnersCardRankList.Where(cr => cr.Frequency == numberOfRankRepeats).FirstOrDefault().Rank;
            int challengerscardRank = challengerscardRankList.Where(cr => cr.Frequency == numberOfRankRepeats).FirstOrDefault().Rank;

            //compare the strength of trips
            if (currentWinnerscardRank > challengerscardRank)
            {
                return currentWinners;
            }
            else if (currentWinnerscardRank < challengerscardRank)
            {
                return new List<PokerHandDto> { challenger };
            }

            //repeated rank cards are the same only possible to get here for duos
            var kickers1 = currentWinnersCardRankList.Where(cr => cr.Frequency == 1).OrderByDescending(c => c.Rank).ToList();
            var kickers2 = challengerscardRankList.Where(cr => cr.Frequency == 1).OrderByDescending(c => c.Rank).ToList();

            //repeated cards are the same so kickers will be examined
            for (int i = 0; i < kickers1.Count; i++)
            {
                if (kickers1[i].Rank > kickers2[i].Rank)
                {
                    return currentWinners;
                }
                else if (kickers1[i].Rank < kickers2[i].Rank)
                {
                    return new List<PokerHandDto> { challenger };
                }
            }

            //hands are the same in terms of rank. Pot will be chopped.
            currentWinners.Add(challenger);
            return currentWinners;
        }

        /// <summary>
        /// Compares the full houses.
        /// </summary>
        /// <param name="currentWinners">The current winners.</param>
        /// <param name="challenger">The challenger.</param>
        /// <returns>List&lt;PokerHandDto&gt;.</returns>
        private List<PokerHandDto> CompareFullHouse(List<PokerHandDto> currentWinners, PokerHandDto challenger)
        {
            //Card Freq list to query
            //Hand 1
            List<Card> cards1 = GetCardListFromHand(currentWinners[0]);
            List<CardFrequency> cardRankList1 = new CardFrequencyList().GetCardFrequencyList(cards1);
            //Hand 2
            List<Card> cards2 = GetCardListFromHand(challenger);
            List<CardFrequency> cardRankList2 = new CardFrequencyList().GetCardFrequencyList(cards2);

            int currentWinnersTripsRank = cardRankList1.Where(cr => cr.Frequency == 3).FirstOrDefault().Rank;
            int challengerTripsRank = cardRankList2.Where(cr => cr.Frequency == 3).FirstOrDefault().Rank;

            if (currentWinnersTripsRank > challengerTripsRank)
            {
                return currentWinners;
            }
            else if (currentWinnersTripsRank < challengerTripsRank)
            {
                return new List<PokerHandDto> { challenger };
            }

            //Would only be possible to get here in multi deck games. One full house should always be stronger with one deck. 
            int currentWinnersPairRank = cardRankList1.Where(cr => cr.Frequency == 2).FirstOrDefault().Rank;
            int challengerPairRank = cardRankList1.Where(cr => cr.Frequency == 2).FirstOrDefault().Rank;
            //compare the strength of pairs
            if (currentWinnersPairRank > challengerPairRank)
            {
                return currentWinners;
            }
            else if (currentWinnersPairRank < challengerPairRank)
            {
                return new List<PokerHandDto> { challenger };
            }

            //hands are the same in terms of rank. Pot will be chopped.
            currentWinners.Add(challenger);
            return currentWinners;
        }

        /// <summary>
        /// Compares the full houses.
        /// </summary>
        /// <param name="currentWinners">The current winners.</param>
        /// <param name="challenger">The challenger.</param>
        /// <returns>List&lt;PokerHandDto&gt;.</returns>
        private List<PokerHandDto> CompareTwoPairs(List<PokerHandDto> currentWinners, PokerHandDto challenger)
        {
            //Card Freq list to query
            //Hand 1
            List<Card> winnersCards = GetCardListFromHand(currentWinners[0]);
            List<CardFrequency> winnersCardRankList = new CardFrequencyList().GetCardFrequencyList(winnersCards);
            //Hand 2
            List<Card> challengerCards = GetCardListFromHand(challenger);
            List<CardFrequency> challengerCardRankList = new CardFrequencyList().GetCardFrequencyList(challengerCards);

            var winnersTwoPairs = winnersCardRankList.Where(cr => cr.Frequency == 2).OrderByDescending(c => c.Rank).ToList();
            var challengerTwoPairs = challengerCardRankList.Where(cr => cr.Frequency == 2).OrderByDescending(c => c.Rank).ToList();

            int i = 0;
            while (i < 2)
            {
                if (winnersTwoPairs[i].Rank > challengerTwoPairs[i].Rank)
                {
                    return currentWinners;
                }
                else if (winnersTwoPairs[i].Rank < challengerTwoPairs[i].Rank)
                {
                    return new List<PokerHandDto> { challenger };
                }
                i++;
            }
            
            //Would only be possible to get here in multi deck games. One full house should always be stronger with one deck. 
            int winnersKickRank = winnersCardRankList.Where(cr => cr.Frequency == 1).FirstOrDefault().Rank;
            int challengerKickerRank = challengerCardRankList.Where(cr => cr.Frequency == 1).FirstOrDefault().Rank;
            //compare the strength of pairs
            if (winnersKickRank > challengerKickerRank)
            {
                return currentWinners;
            }
            else if (winnersKickRank < challengerKickerRank)
            {
                return new List<PokerHandDto> { challenger };
            }

            //hands are the same in terms of rank. Pot will be chopped.
            currentWinners.Add(challenger);
            return currentWinners;
        }

        /// <summary>
        /// Compares the kickers. This method works for High Card, Flush, Straight, and Straight Flush.
        /// Also called to Compare kickers on four of kind, three of kind, two pair, and pair
        /// </summary>
        /// <param name="currentWinners">The current winners.</param>
        /// <param name="challenger">The challenger.</param>
        /// <returns>List of winners.</returns>
        private List<PokerHandDto> CompareKickers(List<PokerHandDto> currentWinners, PokerHandDto challenger)
        {
            //if there is more than one currentWinner it is becuase there is already a tie.
            //Therefore the hands are the same so only one needs to be compared
            List<Card> cards1 = GetCardListFromHand(currentWinners[0]);
            List<Card> cards2 = GetCardListFromHand(challenger);
            for (int i = 0; i < cards1.Count(); i++)
            {
                //kickers are the same
                if (cards1[i].Rank == cards2[i].Rank)
                {
                    continue;
                }
                //hand1 has better kicker
                else if (cards1[i].Rank > cards2[i].Rank)
                {
                    return currentWinners;
                }
                //hand2 has better kicker
                else if (cards1[i].Rank < cards2[i].Rank)
                {
                    return new List<PokerHandDto> { challenger };
                }
            }
            //hands are the same. Pot will be chopped.
            currentWinners.Add(challenger);
            return currentWinners;
        }

        #region Helper Functions
        /// <summary>
        /// Gets the card list with additional info from hand.
        /// Orders list from highest to lowest value cards
        /// </summary>
        /// <param name="hand">The hand.</param>
        /// <returns>List of cards</returns>
        private List<Card> GetCardListFromHand(PokerHandDto hand)
        {
            List<Card> cards = new List<Card>();
            cards.Add(_cardDict.GetCardInfo(hand.Card1));
            cards.Add(_cardDict.GetCardInfo(hand.Card2));
            cards.Add(_cardDict.GetCardInfo(hand.Card3));
            cards.Add(_cardDict.GetCardInfo(hand.Card4));
            cards.Add(_cardDict.GetCardInfo(hand.Card5));
            cards = cards.OrderByDescending(c => c.Rank).ToList();
            return cards;
        }
        #endregion


    }
}

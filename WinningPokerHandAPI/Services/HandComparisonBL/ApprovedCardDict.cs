using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poker.API.Services.HandComparisonBL
{
    /// <summary>
    /// Class used to check is a card is valid and get additional information about the card - rank, suit.
    /// Eventually this will be moved to a reference table in the db.
    /// </summary>
    public class ApprovedCardDict
    {
        private Dictionary<string, Card> _cardDict;

        public ApprovedCardDict()
        {
            _cardDict = BuildCardDict();
        }

        /// <summary>
        /// Gets the card information.
        /// </summary>
        /// <param name="cardText">The card text.</param>
        /// <returns>Card with rank and suit.</returns>
        /// <exception cref="ArgumentException">cardText</exception>
        public Card GetCardInfo(string cardText)
        {
            Card cardToReturn;
            if (_cardDict.TryGetValue(cardText, out cardToReturn))
            {
                return cardToReturn;
            }
            else
            {
                throw new ArgumentException(String.Format("{0} is not an approved card.", cardText),
                                      "cardText");
            }
        }

        /// <summary>
        /// Builds the card dictionary. Essentially generates a deck
        /// </summary>
        /// <returns>Dictionary of cards.</returns>
        private Dictionary<string, Card> BuildCardDict()
        {
            Dictionary<string, Card> cardDict = new Dictionary<string, Card>();
            string[] suits = { "Club", "Diamond", "Heart", "Spade" };
            string[] suitsShort = { "C", "D", "H", "S" };

            int cardsIndex = 0;
            //loop through 4 suits
            for (int suitIndex = 0; suitIndex < 4; suitIndex++)
            {
                //loop through card values
                for (int cardValue = 2; cardValue <= 14; cardValue++)
                {
                    var idStart = "";
                    if (cardValue > 10)
                    {
                        switch (cardValue)
                        {
                            case 11:
                                idStart = "J";
                                break;
                            case 12:
                                idStart = "Q";
                                break;
                            case 13:
                                idStart = "K";
                                break;
                            case 14:
                                idStart = "A";
                                break;
                        }
                    }
                    else
                    {
                        idStart = cardValue.ToString();
                    }
                    cardDict.Add(idStart + suitsShort[suitIndex], new Card()
                    {
                        Rank = cardValue,
                        Suit = suits[suitIndex]
                    });

                    cardsIndex++;
                }
            }
            return cardDict;
        }
    }
}

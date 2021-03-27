using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinningPokerHandAPI.DataObjects.Entities;

namespace WinningPokerHandAPI.Helpers
{
    public class HandStrength
    {
        Dictionary<string, Card> _cardDict;

        public HandStrength()
        {
            _cardDict = BuildCardDict();
        }

        //Public Methods
        public void GetHandType(string cards)
        {

        }


        //Private Methods
        private Card GetCardInfo(string card)
        {
            Card cardToReturn;
            if (_cardDict.TryGetValue(card, out cardToReturn))
            {
                return cardToReturn;
            }
            return null;
        }




        // <summary>
        /// Create dictionary of all card values
        /// </summary>
        /// <returns>Array of 52 cards</returns>
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

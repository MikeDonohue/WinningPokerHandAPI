using Poker.API.DataObjects.Dtos;
using Poker.API.DataObjects.Entities;
using Poker.API.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Poker.API.Test.HelperTests
{
    public class HandComparerShould
    {

        [Fact]
        public void CreateHandComparer()
        {
            HandComparer sut = new HandComparer();

            Assert.IsType<HandComparer>(sut);
        }

        [Fact]
        public void NotAllowNullPokerHandList()
        {
            HandComparer sut = new HandComparer();
            Assert.Throws<ArgumentNullException>("hands", () => sut.GetWinningHand(null));
        }

        [Fact]
        public void NotAllowEmptyPokerHandList()
        {
            HandComparer sut = new HandComparer();
            //empty list
            var list = new List<PokerHandDto>();
            Assert.Throws<ArgumentException>(() => sut.GetWinningHand(list));
        }

        [Fact]
        public void GetWinningHand_StraightFlushVsStraighFlushDifferent_PhilWins()
        {
            var testHandCalc = new HandComparer();
            var testPokHand1 = CreateTestPokerHandDto("Phil Hellmuth", "Straight Flush", "AH", "KH", "10H", "JH", "QH");
            var testPokHand2 = CreateTestPokerHandDto("Daniel Negranu", "Straight Flush", "2H", "6H", "3H", "4H", "5H");

            string expectedWinnerName = "Phil Hellmuth";

             var pokerHandReturned = testHandCalc.GetWinningHand(new List<PokerHandDto> { testPokHand1, testPokHand2 });
            Assert.Single(pokerHandReturned);
            Assert.Equal(expectedWinnerName, pokerHandReturned.FirstOrDefault().PlayerName);
        }

        [Fact]
        public void GetWinningHand_StraightFlushVsStraighFlushVsStraightFlushDifferent_PhilWins()
        {
            var testHandCalc = new HandComparer();
            var testPokHand1 = CreateTestPokerHandDto("Daniel Negranu", "Straight Flush", "2H", "6H", "3H", "4H", "5H");
            var testPokHand2 = CreateTestPokerHandDto("Phil Hellmuth", "Straight Flush", "AH", "KH", "10H", "JH", "QH");
            var testPokHand3 = CreateTestPokerHandDto("Tony G", "Straight Flush", "8D", "6D", "7D", "9D", "10D");

            string expectedWinnerName = "Phil Hellmuth";

            var pokerHandReturned = testHandCalc.GetWinningHand(new List<PokerHandDto> { testPokHand1, testPokHand2, testPokHand3 });
            Assert.Single(pokerHandReturned);
            Assert.Equal(expectedWinnerName, pokerHandReturned.FirstOrDefault().PlayerName);
        }

        [Fact]
        public void GetWinningHand_HighCardVsHighCardVsHighCard_TwoWayChopPhilAndTony()
        {
            var testHandCalc = new HandComparer();
            var testPokHand1 = CreateTestPokerHandDto("Daniel Negranu", "High Card", "2D", "7H", "6H", "10D", "4H");
            var testPokHand2 = CreateTestPokerHandDto("Phil Hellmuth", "High Card", "2S", "7C", "6S", "QD", "4C");
            var testPokHand3 = CreateTestPokerHandDto("Tony G", "High Card", "2H", "7D", "6D", "QC", "4S");

            string expectedWinnerName1 = "Phil Hellmuth";
            string expectedWinnerName2 = "Tony G";

            var pokerHandReturned = testHandCalc.GetWinningHand(new List<PokerHandDto> { testPokHand1, testPokHand2, testPokHand3 });
            Assert.Equal(2, pokerHandReturned.Count());
            Assert.Equal(expectedWinnerName1, pokerHandReturned[0].PlayerName);
            Assert.Equal(expectedWinnerName2, pokerHandReturned[1].PlayerName);
        }

        [Fact]
        public void GetWinningHand_HighCardVsHighCardVsHighCard_ThreeWayChopAllWin()
        {
            var testHandCalc = new HandComparer();
            var testPokHand1 = CreateTestPokerHandDto("Daniel Negranu", "High Card", "2D", "7H", "6H", "QS", "4H");
            var testPokHand2 = CreateTestPokerHandDto("Phil Hellmuth", "High Card", "2S", "7C", "6S", "QD", "4C");
            var testPokHand3 = CreateTestPokerHandDto("Tony G", "High Card", "2H", "7D", "6D", "QC", "4S");


            string expectedWinnerName1 = "Daniel Negranu";
            string expectedWinnerName2 = "Phil Hellmuth";
            string expectedWinnerName3 = "Tony G";

            var pokerHandReturned = testHandCalc.GetWinningHand(new List<PokerHandDto> { testPokHand1, testPokHand2, testPokHand3 });
            Assert.Equal(3, pokerHandReturned.Count());
            Assert.Equal(expectedWinnerName1, pokerHandReturned[0].PlayerName);
            Assert.Equal(expectedWinnerName2, pokerHandReturned[1].PlayerName);
            Assert.Equal(expectedWinnerName3, pokerHandReturned[2].PlayerName);
        }

        [Fact]
        public void GetWinningHand_HighCardVsHighCardVsHighCard_TonyWins()
        {
            var testHandCalc = new HandComparer();
            var testPokHand1 = CreateTestPokerHandDto("Daniel Negranu", "High Card", "2D", "7H", "6H", "QS", "4H");
            var testPokHand2 = CreateTestPokerHandDto("Phil Hellmuth", "High Card", "2S", "7C", "6S", "QD", "4C");
            var testPokHand3 = CreateTestPokerHandDto("Tony G", "High Card", "3H", "7D", "6D", "QC", "4S");


            string expectedWinnerName1 = "Tony G";

            var pokerHandReturned = testHandCalc.GetWinningHand(new List<PokerHandDto> { testPokHand1, testPokHand2, testPokHand3 });
            Assert.Single(pokerHandReturned);
            Assert.Equal(expectedWinnerName1, pokerHandReturned.FirstOrDefault().PlayerName);
        }

        [Fact]
        public void GetWinningHand_StraightFlushVsStraight_PhilWins()
        {
            var testHandCalc = new HandComparer();
            var testPokHand1 = CreateTestPokerHandDto("Phil Hellmuth", "Straight Flush", "AH", "KH", "10H", "JH", "QH");
            var testPokHand2 = CreateTestPokerHandDto("Daniel Negranu", "Straight", "2H", "6H", "3D", "4S", "5H");

            string expectedWinnerName = "Phil Hellmuth";

            var pokerHandReturned = testHandCalc.GetWinningHand(new List<PokerHandDto> { testPokHand1, testPokHand2 });
            Assert.Single(pokerHandReturned);
            Assert.Equal(expectedWinnerName, pokerHandReturned.FirstOrDefault().PlayerName);
        }

        [Fact]
        public void GetWinningHand_SingleHand_PhilWins()
        {
            var testHandCalc = new HandComparer();
            var testPokHand1 = CreateTestPokerHandDto("Phil Hellmuth", "Straight Flush", "AH", "KH", "10H", "JH", "QH");

            string expectedWinnerName = "Phil Hellmuth";

            var pokerHandReturned = testHandCalc.GetWinningHand(new List<PokerHandDto> { testPokHand1 });
            Assert.Single(pokerHandReturned);
            Assert.Equal(expectedWinnerName, pokerHandReturned.FirstOrDefault().PlayerName);
        }



        private PokerHandDto CreateTestPokerHandDto(string name, string type, string card1, string card2, string card3, string card4, string card5)
        {
            return new PokerHandDto()
            {
                Id = new Guid(),
                PlayerName = name,
                DateCreated = DateTime.Now,
                Type = type,
                Card1 = card1,
                Card2 = card2,
                Card3 = card3,
                Card4 = card4,
                Card5 = card5
            };
        }
    }
}

using Poker.API.DataObjects.Entities;
using Poker.API.Helpers;
using System;
using Xunit;

namespace Poker.API.Test.HelperTests
{
    public class HandTypeCalculatorShould
    {

        [Fact]
        public void CreateHandTypeCalculator()
        {
            HandTypeCalculator sut = new HandTypeCalculator();

            Assert.IsType<HandTypeCalculator>(sut);
        }

        [Fact]
        public void NotAllowNullPokerHand()
        {
            HandTypeCalculator sut = new HandTypeCalculator();

            // Assert.Throws<ArgumentNullException>(() => sut.Create(null));
            Assert.Throws<ArgumentNullException>("hand", () => sut.GetHandType(null));
        }

        [Fact]
        public void CreateStraightFlush()
        {
            var testHandCalc = new HandTypeCalculator();
            string expectedType = "Straight Flush";
            var testPokHand = CreateTestPokerHand("Phil Hellmuth1", "AH", "KH", "10H", "JH", "QH");

            var pokerHandReturned = testHandCalc.GetHandType(testPokHand);
            Assert.Equal(expectedType, pokerHandReturned.Name);
        }

        [Fact]
        public void CreateStraightFlush2()
        {
            var testHandCalc = new HandTypeCalculator();
            string expectedType = "Straight Flush";
            var testPokHand = CreateTestPokerHand("Phil Hellmuth1", "2H", "6H", "3H", "4H", "5H");

            var pokerHandReturned = testHandCalc.GetHandType(testPokHand);
            Assert.Equal(expectedType, pokerHandReturned.Name);
        }

        [Fact]
        public void CreateFourOfAKind()
        {
            var testHandCalc = new HandTypeCalculator();
            string expectedType = "Four of a Kind";
            var testPokHand = CreateTestPokerHand("Phil Hellmuth", "AH", "AS", "AD", "AC", "2H");

            var pokerHandReturned = testHandCalc.GetHandType(testPokHand);
            Assert.Equal(expectedType, pokerHandReturned.Name);
        }

        [Fact]
        public void CreateFourOfAKind2()
        {
            var testHandCalc = new HandTypeCalculator();
            string expectedType = "Four of a Kind";
            var testPokHand = CreateTestPokerHand("Phil Hellmuth", "4H", "4S", "AD", "4C", "4D");

            var pokerHandReturned = testHandCalc.GetHandType(testPokHand);
            Assert.Equal(expectedType, pokerHandReturned.Name);
        }

        [Fact]
        public void CreateFullHouse()
        {
            var testHandCalc = new HandTypeCalculator();
            string expectedType = "Full House";
            var testPokHand = CreateTestPokerHand("Phil Hellmuth", "AH", "AS", "AD", "6C", "6H");

            var pokerHandReturned = testHandCalc.GetHandType(testPokHand);
            Assert.Equal(expectedType, pokerHandReturned.Name);
        }

        [Fact]
        public void CreateFullHouse2()
        {
            var testHandCalc = new HandTypeCalculator();
            string expectedType = "Full House";
            var testPokHand = CreateTestPokerHand("Tony G", "4H", "2S", "4D", "4C", "2H");

            var pokerHandReturned = testHandCalc.GetHandType(testPokHand);
            Assert.Equal(expectedType, pokerHandReturned.Name);
        }

        [Fact]
        public void CreateFlush()
        {
            var testHandCalc = new HandTypeCalculator();
            string expectedType = "Flush";
            var testPokHand = CreateTestPokerHand("Tony G", "AH", "4H", "8H", "3H", "2H");

            var pokerHandReturned = testHandCalc.GetHandType(testPokHand);
            Assert.Equal(expectedType, pokerHandReturned.Name);
        }

        [Fact]
        public void CreateFlush2()
        {
            var testHandCalc = new HandTypeCalculator();
            string expectedType = "Flush";
            var testPokHand = CreateTestPokerHand("Tony G", "AC", "4C", "10C", "QC", "2C");

            var pokerHandReturned = testHandCalc.GetHandType(testPokHand);
            Assert.Equal(expectedType, pokerHandReturned.Name);
        }

        [Fact]
        public void CreateStraight()
        {
            var testHandCalc = new HandTypeCalculator();
            string expectedType = "Straight";
            var testPokHand = CreateTestPokerHand("Toby Maguire", "AS", "KH", "10C", "JH", "QH");

            var pokerHandReturned = testHandCalc.GetHandType(testPokHand);
            Assert.Equal(expectedType, pokerHandReturned.Name);
        }

        [Fact]
        public void CreateStraight2()
        {
            var testHandCalc = new HandTypeCalculator();
            string expectedType = "Straight";
            var testPokHand = CreateTestPokerHand("Toby Maguire", "2H", "6D", "3S", "4H", "5C");

            var pokerHandReturned = testHandCalc.GetHandType(testPokHand);
            Assert.Equal(expectedType, pokerHandReturned.Name);
        }

        [Fact]
        public void CreateTrips()
        {
            var testHandCalc = new HandTypeCalculator();
            string expectedType = "Three of a Kind";
            var testPokHand = CreateTestPokerHand("Toby Maguire", "AS", "KH", "AC", "JH", "AH");

            var pokerHandReturned = testHandCalc.GetHandType(testPokHand);
            Assert.Equal(expectedType, pokerHandReturned.Name);
        }

        [Fact]
        public void CreateTrips2()
        {
            var testHandCalc = new HandTypeCalculator();
            string expectedType = "Three of a Kind";
            var testPokHand = CreateTestPokerHand("Toby Maguire", "2D", "6H", "6S", "6D", "3D");

            var pokerHandReturned = testHandCalc.GetHandType(testPokHand);
            Assert.Equal(expectedType, pokerHandReturned.Name);
        }

        [Fact]
        public void CreateTwoPair()
        {
            var testHandCalc = new HandTypeCalculator();
            string expectedType = "Two Pair";
            var testPokHand = CreateTestPokerHand("Toby Maguire", "AS", "KH", "AC", "JH", "JC");

            var pokerHandReturned = testHandCalc.GetHandType(testPokHand);
            Assert.Equal(expectedType, pokerHandReturned.Name);
        }

        [Fact]
        public void CreateTwoPair2()
        {
            var testHandCalc = new HandTypeCalculator();
            string expectedType = "Two Pair";
            var testPokHand = CreateTestPokerHand("Daniel Negreanu", "2D", "2H", "6S", "6D", "3D");

            var pokerHandReturned = testHandCalc.GetHandType(testPokHand);
            Assert.Equal(expectedType, pokerHandReturned.Name);
        }

        [Fact]
        public void CreatePair()
        {
            var testHandCalc = new HandTypeCalculator();
            string expectedType = "Pair";
            var testPokHand = CreateTestPokerHand("Toby Maguire", "AS", "KH", "AC", "3H", "JC");

            var pokerHandReturned = testHandCalc.GetHandType(testPokHand);
            Assert.Equal(expectedType, pokerHandReturned.Name);
        }

        [Fact]
        public void CreatePair2()
        {
            var testHandCalc = new HandTypeCalculator();
            string expectedType = "Pair";
            var testPokHand = CreateTestPokerHand("Daniel Negreanu", "2D", "3H", "6S", "7D", "7C");

            var pokerHandReturned = testHandCalc.GetHandType(testPokHand);
            Assert.Equal(expectedType, pokerHandReturned.Name);
        }

        [Fact]
        public void CreateHighCard()
        {
            var testHandCalc = new HandTypeCalculator();
            string expectedType = "High Card";
            var testPokHand = CreateTestPokerHand("Toby Maguire", "AS", "KH", "6C", "3H", "JC");

            var pokerHandReturned = testHandCalc.GetHandType(testPokHand);
            Assert.Equal(expectedType, pokerHandReturned.Name);
        }

        [Fact]
        public void CreateHighCard2()
        {
            var testHandCalc = new HandTypeCalculator();
            string expectedType = "High Card";
            var testPokHand = CreateTestPokerHand("Daniel Negreanu", "2D", "7H", "6S", "10D", "4C");

            var pokerHandReturned = testHandCalc.GetHandType(testPokHand);
            Assert.Equal(expectedType, pokerHandReturned.Name);
        }


        private PokerHand CreateTestPokerHand(string name, string card1, string card2, string card3, string card4, string card5)
        {
            return new PokerHand()
            {
                Id = new Guid(),
                PlayerName = name,
                DateCreated = DateTime.Now,
                Card1 = card1,
                Card2 = card2,
                Card3 = card3,
                Card4 = card4,
                Card5 = card5
            };
        }
    }
}

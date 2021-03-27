using Poker.API.DataObjects.Entities;
using Poker.API.Helpers;
using System;
using Xunit;

namespace Poker.API.Test.HelperTests
{
    public class HandTypeCalculatorShould
    {
        [Fact]
        public void Test1()
        {
            var testHandCalc = new HandTypeCalculator();
            var testPokHand = new PokerHand()
            {
                Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                PlayerName = "Berry",
                DateCreated = DateTime.Now,
                Type = "4kind",
                Card1 = "AH",
                Card2 = "AS",
                Card3 = "AD",
                Card4 = "AC",
                Card5 = "2H"
            };
            testHandCalc.GetHandType(testPokHand);
        }
    }
}

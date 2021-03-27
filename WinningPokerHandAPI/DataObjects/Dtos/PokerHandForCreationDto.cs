using System;
using System.Collections.Generic;

namespace WinningPokerHandAPI.DataObjects.Dtos
{
    public class PokerHandForCreationDto
    {
        public string PlayerName { get; set; }
        public string Card1 { get; set; }
        public string Card2 { get; set; }
        public string Card3 { get; set; }
        public string Card4 { get; set; }
        public string Card5 { get; set; }
    }
}

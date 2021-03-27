using System;
using System.Collections.Generic;

namespace WinningPokerHandAPI.DataObjects.Dtos
{
    public class PokerHandForCreationDto
    {
        public string PlayerName { get; set; }
       
        public ICollection<CardForCreationDto> Cards { get; set; }
    }
}

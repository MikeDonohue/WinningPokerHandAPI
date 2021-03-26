using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinningPokerHandAPI.DataObjects.Dtos;
using WinningPokerHandAPI.DataObjects.Entities;

namespace WinningPokerHandAPI.Services
{
    public interface IPokerHandsService
    {
        public PokerHand AddPokerHand(PokerHandForCreationDto pokerHandDto);
        public PokerHandDto GetPokerHand(Guid pokerHandId);
    }
}

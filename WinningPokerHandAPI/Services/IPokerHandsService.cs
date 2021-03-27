using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Poker.API.DataObjects.Dtos;
using Poker.API.DataObjects.Entities;

namespace Poker.API.Services
{
    public interface IPokerHandsService
    {
        public PokerHand AddPokerHand(PokerHandForCreationDto pokerHandDto);
        public PokerHandDto GetPokerHand(Guid pokerHandId);
    }
}

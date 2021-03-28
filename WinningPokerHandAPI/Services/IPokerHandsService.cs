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
        public PokerHandDto AddPokerHand(PokerHandForCreationDto pokerHandDto);

        public IEnumerable<PokerHandDto> AddPokerHands(IEnumerable<PokerHandForCreationDto> pokerHandDtos);
        public PokerHandDto GetPokerHand(Guid pokerHandId);

        public IEnumerable<PokerHandDto> GetAllPokerHands();

        public IEnumerable<PokerHandDto> GetPokerHands(IEnumerable<Guid> pokerHandIds);

        public IEnumerable<PokerHandDto> GetWinningPokerHands(IEnumerable<Guid> pokerHandIds);
    }
}

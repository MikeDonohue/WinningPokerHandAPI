using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Poker.API.DataObjects.Dtos;
using Poker.API.DataObjects.Entities;
using Poker.API.Repositories;
using Poker.API.Helpers;

namespace Poker.API.Services
{
    public class PokerHandsService : IPokerHandsService
    {
        private readonly IPokerHandsRepository _pokerHandsRepository;
        private readonly IMapper _mapper;
        private readonly HandTypeCalculator _handTypeCalculator;
        private readonly HandComparer _handComparer;

        public PokerHandsService(IPokerHandsRepository pokerHandsRepository,
           IMapper mapper)
        {
            _pokerHandsRepository = pokerHandsRepository ??
                throw new ArgumentNullException(nameof(pokerHandsRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
            _handTypeCalculator = new HandTypeCalculator();
            _handComparer = new HandComparer();
        }

        public IEnumerable<PokerHandDto> AddPokerHands(IEnumerable<PokerHandForCreationDto> pokerHandDtos)
        {
            List <PokerHandDto> pokerHandDtosToReturn = new List<PokerHandDto>();
            foreach (var pokerHandDto in pokerHandDtos)
            {
                pokerHandDtosToReturn.Add(AddPokerHand(pokerHandDto));
            }
            return pokerHandDtosToReturn;
        }

        public IEnumerable<PokerHandDto> GetWinningPokerHands(IEnumerable<Guid> pokerHandIds)
        {
            List<PokerHandDto> handsToReturn = new List<PokerHandDto>();
            foreach (var pokerHandId in pokerHandIds)
            {
                handsToReturn.Add(GetPokerHand(pokerHandId));
            }
            handsToReturn = _handComparer.GetWinningHand(handsToReturn);
            return handsToReturn;
        }

        public IEnumerable<PokerHandDto> GetPokerHands(IEnumerable<Guid> pokerHandIds)
        {
            List<PokerHandDto> handsToReturn = new List<PokerHandDto>();
            foreach (var pokerHandId in pokerHandIds)
            {
                handsToReturn.Add(GetPokerHand(pokerHandId));
            }
            return handsToReturn;
        }

        public PokerHandDto AddPokerHand(PokerHandForCreationDto pokerHandDto)
        {
            var pokerHandToAdd = _mapper.Map<PokerHand>(pokerHandDto);
            //Add call to determine card type
            pokerHandToAdd.Type = _handTypeCalculator.GetHandType(pokerHandToAdd).Name;
            _pokerHandsRepository.AddPokerHand(pokerHandToAdd);
            var pokerDtoToReturn = _mapper.Map<PokerHandDto>(pokerHandToAdd);
            return pokerDtoToReturn;
        }

        public PokerHandDto GetPokerHand(Guid pokerHandId)
        {
            var pokerHandToReturn = _pokerHandsRepository.GetPokerHand(pokerHandId);
            return _mapper.Map<DataObjects.Dtos.PokerHandDto>(pokerHandToReturn);
        }
    }
}

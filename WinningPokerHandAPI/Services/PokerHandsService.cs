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

        public PokerHandsService(IPokerHandsRepository pokerHandsRepository,
           IMapper mapper)
        {
            _pokerHandsRepository = pokerHandsRepository ??
                throw new ArgumentNullException(nameof(pokerHandsRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
            _handTypeCalculator = new HandTypeCalculator();
        }

        PokerHand IPokerHandsService.AddPokerHand(PokerHandForCreationDto pokerHandDto)
        {
            var pokerHandToAdd = _mapper.Map<PokerHand>(pokerHandDto);
            //Add call to determine card type
            pokerHandToAdd.Type = _handTypeCalculator.GetHandType(pokerHandToAdd).Name;
            _pokerHandsRepository.AddPokerHand(pokerHandToAdd);
            return pokerHandToAdd;
        }

        PokerHandDto IPokerHandsService.GetPokerHand(Guid pokerHandId)
        {
            var pokerHandToReturn = _pokerHandsRepository.GetPokerHand(pokerHandId);
            return _mapper.Map<DataObjects.Dtos.PokerHandDto>(pokerHandToReturn);
        }
    }
}

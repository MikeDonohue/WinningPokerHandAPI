using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinningPokerHandAPI.DataObjects.Dtos;
using WinningPokerHandAPI.DataObjects.Entities;
using WinningPokerHandAPI.Repositories;

namespace WinningPokerHandAPI.Services
{
    public class PokerHandsService : IPokerHandsService
    {
        private readonly IPokerHandsRepository _pokerHandsRepository;
        private readonly IMapper _mapper;

        public PokerHandsService(IPokerHandsRepository pokerHandsRepository,
           IMapper mapper)
        {
            _pokerHandsRepository = pokerHandsRepository ??
                throw new ArgumentNullException(nameof(pokerHandsRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        PokerHand IPokerHandsService.AddPokerHand(PokerHandForCreationDto pokerHandDto)
        {
            var pokerHandToAdd = _mapper.Map<PokerHand>(pokerHandDto);
            _pokerHandsRepository.AddPokerHand(pokerHandToAdd);
            _pokerHandsRepository.Save();
            return pokerHandToAdd;
        }

        PokerHandDto IPokerHandsService.GetPokerHand(Guid pokerHandId)
        {
            var pokerHandToReturn = _pokerHandsRepository.GetPokerHand(pokerHandId);
            return _mapper.Map<DataObjects.Dtos.PokerHandDto>(pokerHandToReturn);
        }
    }
}

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poker.API.DataObjects.Mappings
{
    public class PokerHandProfile : Profile
    {
        public PokerHandProfile()
        {
            CreateMap<DataObjects.Entities.PokerHand, DataObjects.Dtos.PokerHandDto>().ReverseMap();

            CreateMap<DataObjects.Dtos.PokerHandForCreationDto, DataObjects.Entities.PokerHand>();
        }
    }
}

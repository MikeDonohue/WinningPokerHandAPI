using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinningPokerHandAPI.Models;

namespace WinningPokerHandAPI.Services
{
    public interface IPokerHandsService
    {
        public PokerHandDto CreatePokerHand(PokerHandDto pokerHandDto);

        public PokerHandDto GetPokerHand(Guid pokerHandDto);
    }
}

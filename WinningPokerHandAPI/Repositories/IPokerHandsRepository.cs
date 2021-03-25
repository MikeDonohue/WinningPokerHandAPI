using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinningPokerHandAPI.Models;

namespace WinningPokerHandAPI.Repositories
{
    public interface IPokerHandsRepository
    {
        public string GetPokerHand(Guid pokerHandDto);

    }
}

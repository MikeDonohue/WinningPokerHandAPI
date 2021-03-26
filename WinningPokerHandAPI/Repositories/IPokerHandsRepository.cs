using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinningPokerHandAPI.DataObjects;
using WinningPokerHandAPI.DataObjects.Entities;

namespace WinningPokerHandAPI.Repositories
{
    public interface IPokerHandsRepository
    {
        public PokerHand AddPokerHand(PokerHand pokerHand);
        public PokerHand GetPokerHand(Guid pokerHandId);
        public bool Save();

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Poker.API.DataObjects;
using Poker.API.DataObjects.Entities;

namespace Poker.API.Repositories
{
    public interface IPokerHandsRepository
    {
        public PokerHand AddPokerHand(PokerHand pokerHand);
        public PokerHand GetPokerHand(Guid pokerHandId);
        public bool Save();

    }
}

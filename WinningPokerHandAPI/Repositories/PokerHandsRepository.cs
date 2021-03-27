using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinningPokerHandAPI.DbContexts;
using WinningPokerHandAPI.DataObjects;
using WinningPokerHandAPI.DataObjects.Entities;

namespace WinningPokerHandAPI.Repositories
{
    public class PokerHandsRepository : IPokerHandsRepository, IDisposable
    {
        private readonly PokerHandsContext _context;

        public PokerHandsRepository(PokerHandsContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public PokerHand AddPokerHand(PokerHand pokerHand)
        {
            if (pokerHand == null)
            {
                throw new ArgumentNullException(nameof(pokerHand));
            }
            
            pokerHand.Id = Guid.NewGuid();
            pokerHand.DateCreated = DateTime.Now;
            _context.PokerHands.Add(pokerHand);
            
            return pokerHand;
        }

        public PokerHand GetPokerHand(Guid pokerHandId)
        {
            if (pokerHandId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(pokerHandId));
            }

            return _context.PokerHands
              .Where(c => c.Id == pokerHandId).FirstOrDefault();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }
    }
}

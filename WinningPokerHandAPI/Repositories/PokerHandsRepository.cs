using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Poker.API.DbContexts;
using Poker.API.DataObjects;
using Poker.API.DataObjects.Entities;
using Microsoft.EntityFrameworkCore;

namespace Poker.API.Repositories
{
    /// <summary>
    /// Class PokerHandsRepository.
    /// Implements the <see cref="Poker.API.Repositories.IPokerHandsRepository" />
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="Poker.API.Repositories.IPokerHandsRepository" />
    /// <seealso cref="System.IDisposable" />
    public class PokerHandsRepository : IPokerHandsRepository, IDisposable
    {
        private PokerHandsContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="PokerHandsRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <exception cref="ArgumentNullException">context</exception>
        public PokerHandsRepository(PokerHandsContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Adds the poker hand. Shouldn't be async since adding something to the context isnt IO bound. Saving is though.
        /// </summary>
        /// <param name="pokerHand">The poker hand.</param>
        /// <returns>PokerHand.</returns>
        /// <exception cref="ArgumentNullException">pokerHand</exception>
        public PokerHand AddPokerHand(PokerHand pokerHand)
        {
            if (pokerHand == null)
            {
                throw new ArgumentNullException(nameof(pokerHand));
            }
            
            //Generate new Guid as primary key in db.
            pokerHand.Id = Guid.NewGuid();
            //Get current datetime
            pokerHand.DateCreated = DateTime.Now;
            _context.PokerHands.Add(pokerHand);
            return pokerHand;
        }

        /// <summary>
        /// Gets the poker hand.
        /// </summary>
        /// <param name="pokerHandId">The poker hand identifier.</param>
        /// <returns>PokerHand.</returns>
        /// <exception cref="ArgumentNullException">pokerHandId</exception>
        public PokerHand GetPokerHand(Guid pokerHandId)
        {
            if (pokerHandId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(pokerHandId));
            }

            return _context.PokerHands
              .Where(c => c.Id == pokerHandId).FirstOrDefault();
        }

        /// <summary>
        /// Gets all poker hands.
        /// </summary>
        /// <returns>Entity objects of all poker hands in the db.</returns>
        public IEnumerable<PokerHand> GetAllPokerHands()
        {
            return _context.PokerHands;
        }


        public async Task<PokerHand> GetPokerHandAsync(Guid pokerHandId)
        {
            if (pokerHandId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(pokerHandId));
            }

            return await _context.PokerHands
              .Where(c => c.Id == pokerHandId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PokerHand>> GetAllPokerHandsAsync()
        {
            return await _context.PokerHands.ToListAsync();
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public async Task<bool> SaveAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
               if(_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }

    }
}

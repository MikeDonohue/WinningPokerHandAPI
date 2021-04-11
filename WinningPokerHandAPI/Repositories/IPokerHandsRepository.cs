using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Poker.API.DataObjects;
using Poker.API.DataObjects.Entities;

namespace Poker.API.Repositories
{
    /// <summary>
    /// Interface IPokerHandsRepository
    /// </summary>
    public interface IPokerHandsRepository
    {
        /// <summary>
        /// Adds the poker hand.
        /// </summary>
        /// <param name="pokerHand">The poker hand.</param>
        /// <returns>PokerHand.</returns>
        public PokerHand AddPokerHand(PokerHand pokerHand);

        /// <summary>
        /// Gets the poker hand.
        /// </summary>
        /// <param name="pokerHandId">The poker hand identifier.</param>
        /// <returns>PokerHand.</returns>
        public PokerHand GetPokerHand(Guid pokerHandId);

        /// <summary>
        /// Gets all poker hands.
        /// </summary>
        /// <returns>IEnumerable&lt;PokerHand&gt;.</returns>
        public IEnumerable<PokerHand> GetAllPokerHands();

        /// <summary>
        /// Gets the poker hand.
        /// </summary>
        /// <param name="pokerHandId">The poker hand identifier.</param>
        /// <returns>PokerHand.</returns>
        public Task<PokerHand> GetPokerHandAsync(Guid pokerHandId);

        /// <summary>
        /// Gets all poker hands.
        /// </summary>
        /// <returns>IEnumerable&lt;PokerHand&gt;.</returns>
        public Task<IEnumerable<PokerHand>> GetAllPokerHandsAsync();

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Save();

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public Task<bool> SaveAsync();
    }
}

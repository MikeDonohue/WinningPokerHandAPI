using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Poker.API.DataObjects.Dtos;
using Poker.API.DataObjects.Entities;

namespace Poker.API.Services
{
    /// <summary>
    /// Interface for IPokerHandsService. 
    /// </summary>
    public interface IPokerHandsService
    {
        /// <summary>
        /// Gets the poker hand.
        /// </summary>
        /// <param name="pokerHandId">The poker hand identifier.</param>
        /// <returns>PokerHandDto of hand with provided Id</returns>
        public PokerHandDto GetPokerHand(Guid pokerHandId);

        /// <summary>
        /// Gets the poker hands.
        /// </summary>
        /// <param name="pokerHandIds">The poker hand ids.</param>
        /// <returns>List of poker hands with provided ids</returns>
        public IEnumerable<PokerHandDto> GetPokerHands(IEnumerable<Guid> pokerHandIds);

        /// <summary>
        /// Gets all poker hands. Todo: add paging.
        /// </summary>
        /// <returns>List of all hands in Db.</returns>
        public IEnumerable<PokerHandDto> GetAllPokerHands();

        /// <summary>
        /// Gets the winning poker hands.
        /// </summary>
        /// <param name="pokerHandIds">The poker hand ids.</param>
        /// <returns>List of winning poker hands with provided ids. Can be more than one in case of a tie</returns>
        public IEnumerable<PokerHandDto> GetWinningPokerHands(IEnumerable<Guid> pokerHandIds);

        /// <summary>
        /// Saves the poker hand to the db.
        /// </summary>
        /// <param name="pokerHandDto">The poker hand dto that will be saved.</param>
        /// <returns>The poker hand dto that was saved.</returns>
        public PokerHandDto AddPokerHand(PokerHandForCreationDto pokerHandDto);

        /// <summary>
        /// Saves the poker hands to the database.
        /// </summary>
        /// <param name="pokerHandDtos">The poker hand dtos to save.</param>
        /// <returns>The poker hand dto that were saved to the db.</returns>
        public IEnumerable<PokerHandDto> AddPokerHands(IEnumerable<PokerHandForCreationDto> pokerHandDtos);
       
    }
}

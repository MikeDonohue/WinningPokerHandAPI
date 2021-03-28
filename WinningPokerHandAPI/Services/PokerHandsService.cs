using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Poker.API.DataObjects.Dtos;
using Poker.API.DataObjects.Entities;
using Poker.API.Repositories;
using Poker.API.Services.HandComparisonBL;

namespace Poker.API.Services
{
    /// <summary>
    /// Class PokerHandsService. Business Logic for Poker Hands. 
    /// Used for Mapping and calling into Hand Comparison classes to determine winners or hand types.
    /// Implements the <see cref="Poker.API.Services.IPokerHandsService" />
    /// </summary>
    /// <seealso cref="Poker.API.Services.IPokerHandsService" />
    public class PokerHandsService : IPokerHandsService
    {
        private readonly IPokerHandsRepository _pokerHandsRepository;
        private readonly IMapper _mapper;
        private readonly HandTypeCalculator _handTypeCalculator;
        private readonly HandComparer _handComparer;

        /// <summary>
        /// Initializes a new instance of the <see cref="PokerHandsService"/> class.
        /// </summary>
        /// <param name="pokerHandsRepository">The poker hands repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <exception cref="ArgumentNullException">pokerHandsRepository</exception>
        /// <exception cref="ArgumentNullException">mapper</exception>
        public PokerHandsService(IPokerHandsRepository pokerHandsRepository,
           IMapper mapper)
        {
            _pokerHandsRepository = pokerHandsRepository ??
                throw new ArgumentNullException(nameof(pokerHandsRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
            _handTypeCalculator = new HandTypeCalculator();
            _handComparer = new HandComparer();
        }

        #region Get Methods
        /// <summary>
        /// Gets the poker hand.
        /// </summary>
        /// <param name="pokerHandId">The poker hand identifier.</param>
        /// <returns>PokerHandDto of hand with provided Id</returns>
        public PokerHandDto GetPokerHand(Guid pokerHandId)
        {
            var pokerHandToReturn = _pokerHandsRepository.GetPokerHand(pokerHandId);
            return _mapper.Map<DataObjects.Dtos.PokerHandDto>(pokerHandToReturn);
        }

        /// <summary>
        /// Gets the poker hands.
        /// </summary>
        /// <param name="pokerHandIds">The poker hand ids.</param>
        /// <returns>List of poker hands with provided ids</returns>
        public IEnumerable<PokerHandDto> GetPokerHands(IEnumerable<Guid> pokerHandIds)
        {
            List<PokerHandDto> handsToReturn = new List<PokerHandDto>();
            foreach (var pokerHandId in pokerHandIds)
            {
                handsToReturn.Add(GetPokerHand(pokerHandId));
            }
            return handsToReturn;
        }

        /// <summary>
        /// Gets the winning poker hands.
        /// </summary>
        /// <param name="pokerHandIds">The poker hand ids.</param>
        /// <returns>List of winning poker hands with provided ids. Can be more than one in case of a tie</returns>
        public IEnumerable<PokerHandDto> GetWinningPokerHands(IEnumerable<Guid> pokerHandIds)
        {
            List<PokerHandDto> handsToReturn = new List<PokerHandDto>();
            foreach (var pokerHandId in pokerHandIds)
            {
                handsToReturn.Add(GetPokerHand(pokerHandId));
            }
            handsToReturn = _handComparer.GetWinningHand(handsToReturn);
            return handsToReturn;
        }

        /// <summary>
        /// Gets all poker hands. Todo: add paging.
        /// </summary>
        /// <returns>List of all hands in Db.</returns>
        public IEnumerable<PokerHandDto> GetAllPokerHands()
        {
            return _mapper.Map<IEnumerable<PokerHandDto>>(_pokerHandsRepository.GetAllPokerHands());
        }
        #endregion

        #region Add Methods        
        /// <summary>
        /// Saves the poker hand to the db.
        /// </summary>
        /// <param name="pokerHandDto">The poker hand dto that will be saved.</param>
        /// <returns>The poker hand dto that was saved.</returns>
        public PokerHandDto AddPokerHand(PokerHandForCreationDto pokerHandDto)
        {
            var pokerHandToAdd = _mapper.Map<PokerHand>(pokerHandDto);
            //Add call to determine card type
            pokerHandToAdd.Type = _handTypeCalculator.GetHandType(pokerHandToAdd).Name;
            _pokerHandsRepository.AddPokerHand(pokerHandToAdd);
            var pokerDtoToReturn = _mapper.Map<PokerHandDto>(pokerHandToAdd);
            return pokerDtoToReturn;
        }

        /// <summary>
        /// Saves the poker hands to the database.
        /// </summary>
        /// <param name="pokerHandDtos">The poker hand dtos to save.</param>
        /// <returns>The poker hand dto that were saved to the db.</returns>
        public IEnumerable<PokerHandDto> AddPokerHands(IEnumerable<PokerHandForCreationDto> pokerHandDtos)
        {
            List<PokerHandDto> pokerHandDtosToReturn = new List<PokerHandDto>();
            foreach (var pokerHandDto in pokerHandDtos)
            {
                pokerHandDtosToReturn.Add(AddPokerHand(pokerHandDto));
            }
            return pokerHandDtosToReturn;
        }
        #endregion



        

        

        

        
    }
}

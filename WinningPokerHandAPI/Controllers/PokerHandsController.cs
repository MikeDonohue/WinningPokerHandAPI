using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using Poker.API.DataObjects.Dtos;
using Poker.API.Services;
using System.Collections.Generic;
using Poker.API.Helpers;
using System.Dynamic;
using System.Linq;

namespace Poker.API.Controllers
{
    [ApiController]
    [Route("pokerhands")]
    public class PokerHandsController : ControllerBase
    {
        private readonly IPokerHandsService _pokerHandsService;

        public PokerHandsController(IPokerHandsService PokerHandsService)
        {
            _pokerHandsService = PokerHandsService ?? throw new ArgumentNullException(nameof(PokerHandsService));
        }

        #region Http Requests         
        /// <summary>
        /// Gets all poker hands.
        /// </summary>
        /// <returns>Action result containing a list of pokerhands saved.</returns>
        [HttpGet(Name = "GetAllPokerHands")]
        [HttpHead]
        [ResponseCache(Duration = 120)]
        public IActionResult GetAllPokerHands()
        {
            //get all poker hands currently saved in the db
            var savedHands = _pokerHandsService.GetAllPokerHands();

            //Generate Links to return to consumer
            var shapedPokerHands = new List<ExpandoObject>();
            foreach(var pokHand in savedHands)
            {
                shapedPokerHands.Add(pokHand.ShapeData(null));
            }

            var shapedPokerHandssWithLinks = shapedPokerHands.Select(pokerHand =>
            {
                var pokerHandAsDictionary = pokerHand as IDictionary<string, object>;
                var pokerHandLinks = CreateLinksForPokerHand((Guid)pokerHandAsDictionary["Id"], "self");
                pokerHandAsDictionary.Add("links", pokerHandLinks);
                return pokerHandAsDictionary;
            });

            //return 200 status code
            return Ok(shapedPokerHandssWithLinks);
        }

        /// <summary>
        /// Gets the poker hand.
        /// </summary>
        /// <param name="pokerHandId">The poker hand identifier.</param>
        /// <returns>Action result containing the name of poker player and cards in hand.</returns>
        [HttpGet("{pokerHandId}", Name = "GetPokerHand")]
        [ResponseCache(Duration = 120)]
        public IActionResult GetPokerHand(Guid pokerHandId)
        {
            //Get poker hand with given guid from the db.
            var savedHand = _pokerHandsService.GetPokerHand(pokerHandId);

            //throws 404 if the poker hand guid requested is not present
            if (savedHand == null)
            {
                return NotFound();
            }

            //Generate Links to return to consumer
            var linkedResourceToReturn = savedHand.ShapeData(null) as IDictionary<string, object>;
            linkedResourceToReturn.Add("links", CreateLinksForPokerHand(savedHand.Id, "self"));

            //return 200 status code
            return Ok(linkedResourceToReturn);
        }

        /// <summary>
        /// Creates the poker hand.
        /// </summary>
        /// <param name="pokerHandDto">Poker player name and 5 cards in hand.</param>
        /// <returns>Action result containing the details of the hand successully saved on the server including the id associated with this hand, poker player name, hand type, and 5 cards in hand.</returns>
        [HttpPost(Name = "CreatePokerHand")]
        public ActionResult<PokerHandDto> CreatePokerHand(PokerHandForCreationDto pokerHandDto)
        {
            //Save Poker Hand to DB
            var pokerHandCreated = _pokerHandsService.AddPokerHand(pokerHandDto);

            //Generate Links to return to consumer
            var linkedResourceToReturn = pokerHandCreated.ShapeData(null) as IDictionary<string, object>;
            linkedResourceToReturn.Add("links", CreateLinksForPokerHand(pokerHandCreated.Id, "GetPokerHand"));

            //return response status code 201 successfully created
            return CreatedAtRoute("GetPokerHand", new { pokerHandId = pokerHandCreated.Id }, linkedResourceToReturn);
        }

        /// <summary>
        /// Gets the poker hand options.
        /// </summary>
        /// <returns>Action result containing Http actions available for this resource.</returns>
        [HttpOptions(Name = "GetPokerHandOptions")]
        public IActionResult GetPokerHandOptions()
        {
            Response.Headers.Add("Allow", "OPTIONS,POST,GET");
            return Ok();
        }
        #endregion

        #region HATEOAS Methods        
        /// <summary>
        /// Creates the links for poker hand.
        /// </summary>
        /// <param name="pokerHandId">The poker hand identifier.</param>
        /// <returns>Links of follow on actions that can be performed with the current response.</returns>
        private IEnumerable<LinkDto> CreateLinksForPokerHand(Guid pokerHandId, string relatedMethod)
        {
            var links = new List<LinkDto>();

            links.Add(new LinkDto(Url.Link("GetPokerHand", new { pokerHandId }), relatedMethod, "GET"));

            return links;
        }
        #endregion
    }


}

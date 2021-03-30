using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Poker.API.DataObjects.Dtos;
using Poker.API.Helpers;
using Poker.API.Services;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace Poker.API.Controllers
{
    [ApiController]
    [Route("pokerhandcollections")]
    public class PokerHandCollectionsController : ControllerBase
    {
        private readonly IPokerHandsService _pokerHandsService;

        public PokerHandCollectionsController(IPokerHandsService pokerHandsService)
        {
            _pokerHandsService = pokerHandsService ??
                throw new ArgumentNullException(nameof(PokerHandsService));
        }


        #region Http Requests

        /// <summary>
        /// Gets the poker hand collection.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet("({ids})", Name ="GetPokerHandCollection")]
        [ResponseCache(Duration = 120)]
        public IActionResult GetPokerHandCollection(
        [FromRoute]
        [ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            //if id is null throw 400 bad request
            if (ids == null)
            {
                return BadRequest();
            }

            //get poker hands from db
            var pokerHandDtos = _pokerHandsService.GetPokerHands(ids);

            //check that the proper number of pokerhands were retrieved
            if (ids.Count() != pokerHandDtos.Count())
            {
                return NotFound();
            }

            //Generate Links to return to consumer
            var shapedPokerHands = new List<ExpandoObject>();
            foreach (var pokHand in pokerHandDtos)
            {
                shapedPokerHands.Add(pokHand.ShapeData(null));
            }

            var shapedPokerHandssWithLinks = shapedPokerHands.Select(pokerHand =>
            {
                var pokerHandAsDictionary = pokerHand as IDictionary<string, object>;
                var collectionLinks = CreateLinksForPokerHandCollections(pokerHandDtos.ToList(), (Guid)pokerHandAsDictionary["Id"], "self");
                pokerHandAsDictionary.Add("links", collectionLinks);
                return pokerHandAsDictionary;
            });

            //return status code 200
            return Ok(shapedPokerHandssWithLinks);
        }

        /// <summary>
        /// Creates the poker hand collection.
        /// </summary>
        /// <param name="pokerHandCollection">The poker hand collection.</param>
        /// <returns>ActionResult&lt;IEnumerable&lt;PokerHandDto&gt;&gt;.</returns>
        [HttpPost(Name="CreatePokerHandCollection")]
        public ActionResult<IEnumerable<PokerHandDto>> CreatePokerHandCollection(
            IEnumerable<PokerHandForCreationDto> pokerHandCollection)
        {
            //save pokerHands to DB
            var pokerHandsCreated = _pokerHandsService.AddPokerHands(pokerHandCollection);
            var idsAsString = string.Join(",", pokerHandsCreated.Select(a => a.Id));

            //Generate Links to return to consumer
            var shapedPokerHands = new List<ExpandoObject>();
            foreach (var pokHand in pokerHandsCreated)
            {
                shapedPokerHands.Add(pokHand.ShapeData(null));
            }

            var shapedPokerHandssWithLinks = shapedPokerHands.Select(pokerHand =>
            {
                var pokerHandAsDictionary = pokerHand as IDictionary<string, object>;
                var collectionLinks = CreateLinksForPokerHandCollections(pokerHandsCreated.ToList(), (Guid)pokerHandAsDictionary["Id"], "GetPokerHandCollection");
                pokerHandAsDictionary.Add("links", collectionLinks);
                return pokerHandAsDictionary;
            });

            //return 201 status code
            return CreatedAtRoute("GetPokerHandCollection", new { ids = idsAsString }, shapedPokerHandssWithLinks);
        }
        #endregion

        #region HATEOAS Methods
        /// <summary>
        /// Creates the links for poker hand collections.
        /// </summary>
        /// <param name="pokerHandId">The poker hand identifier.</param>
        /// <returns>IEnumerable&lt;LinkDto&gt;.</returns>
        private IEnumerable<LinkDto> CreateLinksForPokerHandCollections(List<PokerHandDto> pokerHandDtos, Guid pokerHandId, string relText)
        {
            var links = new List<LinkDto>();
            string ids = string.Join(",", pokerHandDtos.Select(a => a.Id));

            links.Add(new LinkDto(Url.Link("GetPokerHand", new { pokerHandId }), "GetPokerHand", "GET"));

            links.Add(new LinkDto(Url.Link("GetPokerHandCollection", new { ids }), relText, "GET"));

            links.Add(new LinkDto(Url.Link("GetWinningPokerHands", new { ids } ), "GetWinningPokerHands", "GET"));

            return links;
        }
        #endregion
    }
}
 

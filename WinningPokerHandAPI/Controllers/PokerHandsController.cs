using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using Poker.API.DataObjects.Dtos;
using Poker.API.Services;
using System.Collections.Generic;

namespace Poker.API.Controllers
{
    [ApiController]
    [Route("pokerhands")]
    public class PokerHandsController : ControllerBase
    {
        private readonly IPokerHandsService _pokerHandsService;

        public PokerHandsController(IPokerHandsService PokerHandsService)
        {
            _pokerHandsService = PokerHandsService ??
                throw new ArgumentNullException(nameof(PokerHandsService));
        }

        #region Http Requests 
        [HttpGet(Name = "GetAllPokerHands")]
        public IActionResult GetAllPokerHands()
        {
            var savedHands = _pokerHandsService.GetAllPokerHands();

            return Ok(savedHands);
        }

        [HttpGet("{pokerHandId}", Name = "GetPokerHand")]
        public IActionResult GetPokerHand(Guid pokerHandId)
        {
            var savedHand = _pokerHandsService.GetPokerHand(pokerHandId);

            if (savedHand == null)
            {
                return NotFound();
            }

            var linksToReturn = CreateLinksForPokerHand(pokerHandId);
            (PokerHandDto, IEnumerable<LinkDto>) toReturn = (savedHand, CreateLinksForPokerHand(pokerHandId));

            return Ok(toReturn);
        }

        [HttpPost(Name = "CreatePokerHand")]
        public ActionResult<PokerHandDto> CreatePokerHand(PokerHandForCreationDto pokerHandDto)
        {
            var pokerHandCreated = _pokerHandsService.AddPokerHand(pokerHandDto);
            (PokerHandDto, IEnumerable<LinkDto>) toReturn = (pokerHandCreated, CreateLinksForPokerHand(pokerHandCreated.Id));

            return CreatedAtRoute("GetPokerHand",
                new { pokerHandId = pokerHandCreated.Id },
                toReturn);
        }

        [HttpOptions(Name = "GetPokerHandOptions")]
        public IActionResult GetPokerHandOptions()
        {
            Response.Headers.Add("Allow", "OPTIONS,POST,GET");
            return Ok();
        }
        #endregion

        #region HATEOAS Methods

        private IEnumerable<LinkDto> CreateLinksForPokerHand(Guid pokerHandId)
        {
            var links = new List<LinkDto>();

            links.Add(new LinkDto(Url.Link("GetPokerHand", new { pokerHandId }), "self", "GET"));

            return links;
        }
        #endregion
    }


}

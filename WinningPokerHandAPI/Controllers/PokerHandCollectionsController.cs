using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Poker.API.DataObjects.Dtos;
using Poker.API.Helpers;
using Poker.API.Services;
using System;
using System.Collections.Generic;
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
        [HttpGet("({ids})", Name ="GetPokerHandCollection")]
        public IActionResult GetPokerHandCollection(
        [FromRoute]
        [ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            if (ids == null)
            {
                return BadRequest();
            }

            var pokerHandDtos = _pokerHandsService.GetPokerHands(ids);

            if (ids.Count() != pokerHandDtos.Count())
            {
                return NotFound();
            }

            return Ok(pokerHandDtos);
        }

        [HttpPost]
        public ActionResult<IEnumerable<PokerHandDto>> CreatePokerHandCollection(
            IEnumerable<PokerHandForCreationDto> pokerHandCollection)
        {
            var pokerHandDtos = _pokerHandsService.AddPokerHands(pokerHandCollection);
            var idsAsString = string.Join(",", pokerHandDtos.Select(a => a.Id));
            return CreatedAtRoute("GetPokerHandCollection",
             new { ids = idsAsString },
             pokerHandDtos);
        }
        #endregion

        #region HATEOAS Methods

        private IEnumerable<LinkDto> CreateLinksForPokerHandCollections(Guid pokerHandId)
        {
            var links = new List<LinkDto>();

            links.Add(new LinkDto(Url.Link("GetPokerHand", new { pokerHandId }), "self", "GET"));

            return links;
        }
        #endregion
    }
}
 

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Poker.API.DataObjects.Dtos;
using Poker.API.Helpers;
using Poker.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Poker.API.DataObjects.Entities;
using System.Threading.Tasks;

namespace Poker.API.Controllers
{
    [ApiController]
    [Route("pokerHandCollections")]
    public class PokerHandCollectionsController : ControllerBase
    {
        private readonly IPokerHandsService _pokerHandsService;
        private readonly IMapper _mapper;

        public PokerHandCollectionsController(IPokerHandsService pokerHandsService,
            IMapper mapper)
        {
            _pokerHandsService = pokerHandsService ??
                throw new ArgumentNullException(nameof(PokerHandsService));
        }

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
    }
}
 

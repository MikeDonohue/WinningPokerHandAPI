using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using WinningPokerHandAPI.DataObjects.Dtos;
using WinningPokerHandAPI.Services;

namespace WinningPokerHandAPI.Controllers
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


        [HttpGet("{handId}", Name = "GetPokerHand")]
        public IActionResult GetPokerHand(Guid pokerHandId)
        {
            var savedHand = _pokerHandsService.GetPokerHand(pokerHandId);

            if (savedHand == null)
            {
                return NotFound();
            }

            return Ok(savedHand);
        }

        [HttpPost(Name = "CreateHand")]
        public ActionResult<PokerHandDto> CreatePokerHand(PokerHandForCreationDto pokerHandDto)
        {
            var pokerHandCreated = _pokerHandsService.AddPokerHand(pokerHandDto);

            return CreatedAtRoute("GetPokerHand",
                new { authorId = pokerHandCreated.Id },
                pokerHandCreated);
        }

        [HttpOptions]
        public IActionResult GetPokerHandOptions()
        {
            Response.Headers.Add("Allow", "OPTIONS,POST,GET");
            return Ok();
        }
    }
}

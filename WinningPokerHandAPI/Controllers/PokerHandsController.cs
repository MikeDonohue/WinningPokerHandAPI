using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinningPokerHandAPI.Models;
using WinningPokerHandAPI.Services;

namespace WinningPokerHandAPI.Controllers
{
    [ApiController]
    [Route("pokerhand")]
    public class PokerHandsController : ControllerBase
    {
        private readonly IPokerHandsService _pokerHandsService;

        public PokerHandsController(IPokerHandsService PokerHandsService)
        {
            _pokerHandsService = PokerHandsService ??
                throw new ArgumentNullException(nameof(PokerHandsService));
        }


        [HttpGet("{handId}")]
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
        public ActionResult<PokerHandDto> CreatePokerHand(PokerHandDto pokerHandDto)
        {

            var savedHand = _pokerHandsService.CreatePokerHand(pokerHandDto);

            //placeholder return code
            return Ok(savedHand);
        }



        [HttpOptions]
        public IActionResult GetPokerHandOptions()
        {
            Response.Headers.Add("Allow", "OPTIONS,POST,GET");
            return Ok();
        }
    }
}

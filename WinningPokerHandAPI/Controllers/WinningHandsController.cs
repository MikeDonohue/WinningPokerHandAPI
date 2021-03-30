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
    /// <summary>
    /// While this is not a resource I believe this operation belongs in its own controller. This is becuase I dont want to run this 
    /// every time I return a collection or handle through sorting parameters. While a controller of this 
    /// type is not strictly rest since it doesnt map to a resource I think this is the correct move.
    /// </summary>
    [ApiController]
    [Route("pokerhandcollections/({ids})/winninghands")]
    public class WinningHandsController : ControllerBase
    {
        private readonly IPokerHandsService _pokerHandsService;

        public WinningHandsController(IPokerHandsService pokerHandsService)
        {
            _pokerHandsService = pokerHandsService ??
                throw new ArgumentNullException(nameof(PokerHandsService));
        }

        /// <summary>
        /// Gets the winning poker hands.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet(Name = "GetWinningPokerHands")]
        [ResponseCache(Duration = 120)]
        public IActionResult GetWinningPokerHands(
        [FromRoute]
        [ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            if (ids == null)
            {
                return BadRequest();
            }

            var pokerHandDtos = _pokerHandsService.GetWinningPokerHands(ids);

            return Ok(pokerHandDtos);
        }
    }
}
 

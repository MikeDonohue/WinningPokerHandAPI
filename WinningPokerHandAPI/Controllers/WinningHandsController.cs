﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Poker.API.DataObjects.Dtos;
using Poker.API.Helpers;
using Poker.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Poker.API.DataObjects.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

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
        /// <param name="ids">The ids of the hands to compare.</param>
        /// <returns>Action result containing a collection of poker hands that win. Usually one hand but in case of a tie multiple will be returned. For each hand the details of the hand are returned including the id associated with this hand, poker player name, hand type, and 5 cards in hand.</returns>
        [HttpGet(Name = "GetWinningPokerHands")]
        [ResponseCache(Duration = 120)]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetWinningPokerHands(
        [FromRoute]
        [ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            if (ids == null)
            {
                return BadRequest();
            }

            var pokerHandDtos = _pokerHandsService.GetWinningPokerHands(ids);

            //check a winner was were retrieved
            if (pokerHandDtos.Count() == 0)
            {
                return NotFound();
            }

            return Ok(pokerHandDtos);
        }
    }
}
 

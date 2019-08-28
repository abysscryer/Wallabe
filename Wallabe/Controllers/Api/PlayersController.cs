﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wallabe.Business;
using Wallabe.Data;
using Wallabe.Domains;
using Wallabe.Models;

namespace Wallabe.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayersController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public IEnumerable<PlayerViewModel> GetPlayers()
        {
            return _playerService.List();
        }

        #region comment

        //private readonly ApplicationDbContext _context;

        //public PlayersController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        //// GET: api/Players
        //[HttpGet]
        //public IEnumerable<Player> GetPlayers()
        //{
        //    return _context.Players;
        //}

        //// GET: api/Players/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetPlayer([FromRoute] string id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var player = await _context.Players.FindAsync(id);

        //    if (player == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(player);
        //}

        //// PUT: api/Players/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPlayer([FromRoute] string id, [FromBody] Player player)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != player.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(player).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PlayerExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Players
        //[HttpPost]
        //public async Task<IActionResult> PostPlayer([FromBody] Player player)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _context.Players.Add(player);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetPlayer", new { id = player.Id }, player);
        //}

        //// DELETE: api/Players/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeletePlayer([FromRoute] string id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var player = await _context.Players.FindAsync(id);
        //    if (player == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Players.Remove(player);
        //    await _context.SaveChangesAsync();

        //    return Ok(player);
        //}

        //private bool PlayerExists(string id)
        //{
        //    return _context.Players.Any(e => e.Id == id);
        //}

        #endregion
    }
}
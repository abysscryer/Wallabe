using System;
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
using Wallabe.Service;

namespace Wallabe.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public IEnumerable<GameViewModel> GetProducts()
        {
            return _gameService.List();
        }

        [HttpGet("order/{id:guid}")]
        public IEnumerable<GameViewModel> GetGamesByOrderId([FromRoute]string id)
        {
            return _gameService.ListByOrderId(id);
        }

        [HttpGet("player/{id:guid}")]
        public IEnumerable<GameViewModel> GetGamesByPlayerId([FromRoute]string id)
        {
            return _gameService.ListByPlayerId(id);
        }

        [HttpGet("crane/{id:guid}")]
        public IEnumerable<GameViewModel> GetGamesByCraneId([FromRoute]string id)
        {
            return _gameService.ListByCraneId(id);
        }

        [HttpGet("crane/ready/{id:guid}")]
        public IEnumerable<GameViewModel> GetReadyGamesByCraneId([FromRoute]string id)
        {
            return _gameService.ListReadyByCraneId(id);
        }

        #region comment

        //private readonly ApplicationDbContext _context;

        //public GamesController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        //// GET: api/Games
        //[HttpGet]
        //public IEnumerable<Game> GetGames()
        //{
        //    return _context.Games;
        //}

        //// GET: api/Games/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetGame([FromRoute] string id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var game = await _context.Games.FindAsync(id);

        //    if (game == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(game);
        //}

        //// PUT: api/Games/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutGame([FromRoute] string id, [FromBody] Game game)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != game.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(game).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!GameExists(id))
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

        //// POST: api/Games
        //[HttpPost]
        //public async Task<IActionResult> PostGame([FromBody] Game game)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _context.Games.Add(game);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetGame", new { id = game.Id }, game);
        //}

        //// DELETE: api/Games/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteGame([FromRoute] string id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var game = await _context.Games.FindAsync(id);
        //    if (game == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Games.Remove(game);
        //    await _context.SaveChangesAsync();

        //    return Ok(game);
        //}

        //private bool GameExists(string id)
        //{
        //    return _context.Games.Any(e => e.Id == id);
        //}


        #endregion
    }
}
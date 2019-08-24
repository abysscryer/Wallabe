using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wallabe.Business;
using Wallabe.Models;

namespace Wallabe.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaysController : ControllerBase
    {
        private readonly IPlayService _playService;

        public PlaysController(IPlayService playService)
        {
            _playService = playService;
        }

        [HttpGet("{gameId:guid}")]
        public IEnumerable<PlayViewModel> GetPlays([FromRoute] string gameId)
        {
            return _playService.ListByGameId(gameId);
        }

        [HttpPost]
        public async Task<IActionResult> PostPlay([FromBody] PlayCreateModel createModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var viewModel =  await _playService.CreatePlay(createModel);
            
            return CreatedAtAction("GetPlay", new { id = viewModel.Id }, viewModel);
        }


        //private readonly ApplicationDbContext _context;

        //public PlaysController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        //// GET: api/Plays
        //[HttpGet]
        //public IEnumerable<Play> GetPlays()
        //{
        //    return _context.Plays;
        //}

        //// GET: api/Plays/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetPlay([FromRoute] string id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var play = await _context.Plays.FindAsync(id);

        //    if (play == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(play);
        //}

        //// PUT: api/Plays/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPlay([FromRoute] string id, [FromBody] Play play)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != play.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(play).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PlayExists(id))
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

        //// POST: api/Plays
        //[HttpPost]
        //public async Task<IActionResult> PostPlay([FromBody] Play play)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _context.Plays.Add(play);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetPlay", new { id = play.Id }, play);
        //}

        //// DELETE: api/Plays/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeletePlay([FromRoute] string id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var play = await _context.Plays.FindAsync(id);
        //    if (play == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Plays.Remove(play);
        //    await _context.SaveChangesAsync();

        //    return Ok(play);
        //}

        //private bool PlayExists(string id)
        //{
        //    return _context.Plays.Any(e => e.Id == id);
        //}
    }
}
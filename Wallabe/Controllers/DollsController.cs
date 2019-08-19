using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wallabe.Data;
using Wallabe.Domains;
using Wallabe.Models;
using Wallabe.Service;

namespace Wallabe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DollsController : ControllerBase
    {
        private readonly IDollService _dollService;

        public DollsController(IDollService dollService)
        {
            _dollService = dollService;
        }

        // GET: api/cranes
        [HttpGet]
        public IEnumerable<DollViewModel> GetDolls()
        {
            return _dollService.List();
        }

        // GET: api/Dolls
        [HttpGet("{count:int}")]
        //[HttpGet("{id}")]
        public IEnumerable<DollViewModel> GetDolls([FromRoute]int count)
        {
            return _dollService.List(count);
        }

        #region comment

        //// GET: api/Dolls/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetDoll([FromRoute] string id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var doll = await _context.Dolls.FindAsync(id);

        //    if (doll == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(doll);
        //}

        //// PUT: api/Dolls/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutDoll([FromRoute] string id, [FromBody] Doll doll)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != doll.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(doll).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DollExists(id))
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

        //// POST: api/Dolls
        //[HttpPost]
        //public async Task<IActionResult> PostDoll([FromBody] Doll doll)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _context.Dolls.Add(doll);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetDoll", new { id = doll.Id }, doll);
        //}

        //// DELETE: api/Dolls/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteDoll([FromRoute] string id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var doll = await _context.Dolls.FindAsync(id);
        //    if (doll == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Dolls.Remove(doll);
        //    await _context.SaveChangesAsync();

        //    return Ok(doll);
        //}

        //private bool DollExists(string id)
        //{
        //    return _context.Dolls.Any(e => e.Id == id);
        //}

        #endregion
    }
}
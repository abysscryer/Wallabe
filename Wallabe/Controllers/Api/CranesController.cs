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

namespace Wallabe.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CranesController : ControllerBase
    {

        private readonly ICraneService _craneService;

        public CranesController(ICraneService craneService)
        {
            _craneService = craneService;
        }

        // GET: api/cranes
        [HttpGet("{craneId:guid}")]
        public CraneViewModel GetCrane([FromRoute]string craneId)
        {
            return _craneService.Get(craneId);
        }

        // GET: api/cranes
        [HttpGet]
        public IEnumerable<CraneViewModel> GetCranes()
        {
            return _craneService.List();
        }

        #region comment

        //private readonly ApplicationDbContext _context;

        //public CranesController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        //// GET: api/Cranes
        //[HttpGet]
        //public IEnumerable<Crane> GetCranes()
        //{
        //    return _context.Cranes;
        //}

        //// GET: api/Cranes/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetCrane([FromRoute] string id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var crane = await _context.Cranes.FindAsync(id);

        //    if (crane == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(crane);
        //}

        //// PUT: api/Cranes/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCrane([FromRoute] string id, [FromBody] Crane crane)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != crane.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(crane).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CraneExists(id))
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

        //// POST: api/Cranes
        //[HttpPost]
        //public async Task<IActionResult> PostCrane([FromBody] Crane crane)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _context.Cranes.Add(crane);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetCrane", new { id = crane.Id }, crane);
        //}

        //// DELETE: api/Cranes/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCrane([FromRoute] string id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var crane = await _context.Cranes.FindAsync(id);
        //    if (crane == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Cranes.Remove(crane);
        //    await _context.SaveChangesAsync();

        //    return Ok(crane);
        //}

        //private bool CraneExists(string id)
        //{
        //    return _context.Cranes.Any(e => e.Id == id);
        //}

        #endregion


    }
}
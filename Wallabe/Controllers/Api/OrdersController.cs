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
using Wallabe.Service;

namespace Wallabe.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> PostOrder([FromBody] OrderCreateModel createModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var viewModel = await _orderService.CreateAsync(createModel);

            return CreatedAtAction("GetOrder", new { id = viewModel?.Id }, viewModel);
        }

        // GET: api/Orders
        [HttpGet("{playerId:guid}")]
        public IEnumerable<OrderViewModel> GetOrders([FromRoute] string playerId)
        {
            return _orderService.ListByPlayerId(playerId);
        }

        #region comment

        //// GET: api/Orders
        //[HttpGet]
        //public IEnumerable<Order> GetOrders()
        //{
        //    return _context.Orders;
        //}

        //// GET: api/Orders/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetOrder([FromRoute] string id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var order = await _context.Orders.FindAsync(id);

        //    if (order == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(order);
        //}

        //// PUT: api/Orders/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutOrder([FromRoute] string id, [FromBody] Order order)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != order.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(order).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!OrderExists(id))
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

        //// POST: api/Orders
        //[HttpPost]
        //public async Task<IActionResult> PostOrder([FromBody] Order order)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _context.Orders.Add(order);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        //}

        //// DELETE: api/Orders/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteOrder([FromRoute] string id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var order = await _context.Orders.FindAsync(id);
        //    if (order == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Orders.Remove(order);
        //    await _context.SaveChangesAsync();

        //    return Ok(order);
        //}

        //private bool OrderExists(string id)
        //{
        //    return _context.Orders.Any(e => e.Id == id);
        //}

        #endregion

    }
}
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
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService )
        {
            _productService = productService;
        }

        [HttpGet]
        public IEnumerable<ProductViewModel> GetProducts()
        {
            return _productService.List();
        }

        // GET: api/cranes
        [HttpGet("{craneId:guid}")]
        public IEnumerable<ProductViewModel> GetProducts([FromRoute]string craneId)
        {
            return _productService.List(craneId);
        }

        #region comment

        //private readonly ApplicationDbContext _context;

        //public ProductsController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        //// GET: api/Products
        //[HttpGet]
        //public IEnumerable<Product> GetProducts()
        //{
        //    return _context.Products;
        //}

        //// GET: api/Products/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetProduct([FromRoute] string id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var product = await _context.Products.FindAsync(id);

        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(product);
        //}

        //// PUT: api/Products/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutProduct([FromRoute] string id, [FromBody] Product product)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != product.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(product).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ProductExists(id))
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

        //// POST: api/Products
        //[HttpPost]
        //public async Task<IActionResult> PostProduct([FromBody] Product product)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _context.Products.Add(product);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        //}

        //// DELETE: api/Products/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteProduct([FromRoute] string id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var product = await _context.Products.FindAsync(id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Products.Remove(product);
        //    await _context.SaveChangesAsync();

        //    return Ok(product);
        //}

        //private bool ProductExists(string id)
        //{
        //    return _context.Products.Any(e => e.Id == id);
        //}

        #endregion
    }
}
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallabe.Business;
using Wallabe.Data;
using Wallabe.Models;

namespace Wallabe.Service
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ProductService> _logger;
        private readonly IMapper _mapper;

        public ProductService(ApplicationDbContext context, ILogger<ProductService> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<ProductViewModel> List()
        {
            var items = _context.Products
                .OrderByDescending(x => x.OnCreated)
                .Select(x => new ProductViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Quantity = x.Quantity,
                    Price = x.Price,
                    OnCreated = x.OnCreated,
                    CraneId = x.CraneId,
                    CraneName = x.Crane.Name
                })
                .ToList();

            return items;
        }


        public IEnumerable<ProductViewModel> List(string craneId)
        {
            var items = _context.Products
                .Where(x => x.CraneId == craneId)
                .OrderByDescending(x => x.OnCreated)
                .Select(x => new ProductViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Quantity = x.Quantity,
                    Price = x.Price,
                    OnCreated = x.OnCreated,
                    CraneId = x.CraneId,
                    CraneName = x.Crane.Name
                })
                .ToList();

            return items;
        }

    }
}

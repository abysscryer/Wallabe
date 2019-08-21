using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallabe.Data;
using Wallabe.Models;

namespace Wallabe.Service
{
    public class DollService : IDollService
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public DollService(ApplicationDbContext context, IMapper mapper, ILogger<DollService> logger)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<DollViewModel> List(int count)
        {
            var items = _context.Dolls
                .OrderByDescending(x => x.OnCreated)
                .Take(count)
                .Select(result => new DollViewModel
                {
                    Id = result.Id,
                    Name = result.Name,
                    ImaagePath = result.ImagePath,
                    Quantity = result.Quantity,
                    CraneId = result.CraneId,
                    Status = result.Crane.Status
                })
                .ToList();

            return items;
        }

        public IEnumerable<DollViewModel> List()
        {
            var items = _context.Dolls
                .OrderByDescending(x => x.OnCreated)
                .Select(result => new DollViewModel
                {
                    Id = result.Id,
                    Name = result.Name,
                    ImaagePath = result.ImagePath,
                    Quantity = result.Quantity,
                    CraneId = result.CraneId,
                    Status = result.Crane.Status
                })
                .ToList();

            return items;
        }

        public IEnumerable<DollViewModel> ListByCraneId(string craneId)
        {
            var items = _context.Dolls
                .Where(x => x.CraneId == craneId)
                .OrderByDescending(x => x.OnCreated)
                .Select(result => new DollViewModel
                {
                    Id = result.Id,
                    Name = result.Name,
                    ImaagePath = result.ImagePath,
                    Quantity = result.Quantity,
                    CraneId = result.CraneId,
                    Status = result.Crane.Status
                })
                .ToList();

            return items;
        }

        public IEnumerable<DollViewModel> ListByCraneId(string craneId, int count)
        {
            var items = _context.Dolls
                .Where(x => x.CraneId == craneId)
                .OrderByDescending(x => x.OnCreated)
                .Take(count)
                .Select(result => new DollViewModel
                {
                    Id = result.Id,
                    Name = result.Name,
                    ImaagePath = result.ImagePath,
                    Quantity = result.Quantity,
                    CraneId = result.CraneId,
                    Status = result.Crane.Status
                })
                .ToList();

            return items;
        }
    }
}

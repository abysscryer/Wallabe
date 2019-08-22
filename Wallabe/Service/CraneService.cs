﻿using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallabe.Data;
using Wallabe.Models;

namespace Wallabe.Service
{
    public class CraneService : ICraneService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CraneService(ApplicationDbContext context, IMapper mapper, ILogger<CraneService> logger)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<CraneViewModel> List()
        {
            var items = _context.Cranes
                .Select(x => new CraneViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImagePath = x.ImagePath,
                    Status = x.Status
                    // performance issue
                    // Waitings = x.Games.Where(g => g.Status < Domains.PlayStatus.Over).Count()
                })
                .ToList();
           

            return items;
        }

        public CraneViewModel Get(string craneId)
        {
            var item = _context.Cranes
                .Select(x => new CraneViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImagePath = x.ImagePath,
                    Status = x.Status,
                    Waitings = x.Games.Where(g => g.Status < Domains.PlayStatus.Over).Count()
                })
                .SingleOrDefault(x => x.Id == craneId);

            return item;
        }
    }
}

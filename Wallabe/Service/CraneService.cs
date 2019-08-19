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
            var items = _context.Cranes.ToList();
            var model = _mapper.Map<IEnumerable<CraneViewModel>>(items);

            return model;
        }
    }
}

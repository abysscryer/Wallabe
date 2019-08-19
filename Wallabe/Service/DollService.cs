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
            var items = _context.Dolls.OrderByDescending(x => x.OnCreated).Take(count).ToList();
            var model = _mapper.Map<IEnumerable<DollViewModel>>(items);

            return model;
        }

        public IEnumerable<DollViewModel> List()
        {
            var items = _context.Dolls.OrderBy(x => x.OnCreated).ToList();
            var model = _mapper.Map<IEnumerable<DollViewModel>>(items);

            return model;
        }
    }
}

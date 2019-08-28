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
    public class PlayerService : IPlayerService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<PlayerService> _logger;
        private readonly IMapper _mapper;

        public PlayerService(ApplicationDbContext context, ILogger<PlayerService> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<PlayerViewModel> List()
        {
            var items = _context.Players
                .Select(x => new PlayerViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Cash = x.Cash,
                    ImagePath = x.ImagePath,
                    OnCreated = x.OnCreated
                })
                .ToList();
            return items;
        }
    }
}

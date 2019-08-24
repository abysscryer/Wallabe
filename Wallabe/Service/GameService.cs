using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallabe.Business;
using Wallabe.Data;
using Wallabe.Domains;
using Wallabe.Models;

namespace Wallabe.Service
{
    public class GameService : IGameService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<GameService> _logger;
        private readonly IMapper _mapper;

        public GameService(ApplicationDbContext context, ILogger<GameService> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<GameViewModel> List()
        {
            var items = _context.Games
                .OrderByDescending(x => x.OnCreated)
                .Select(x => new GameViewModel
                {
                    Id = x.Id,
                    OrderId = x.OrderId,
                    PlayerName = x.Player.Name,
                    CraneId = x.CraneId,
                    CraneName = x.Crane.Name,
                    Status = x.Status,
                    State = x.State,
                    OnCreated = x.OnCreated,
                    OnUpdated = x.OnUpdated
                })
                .ToList();

            return items;
        }

        public IEnumerable<GameViewModel> ListByOrderId(string orderId)
        {
            var items = _context.Games
                .Where(x => x.OrderId == orderId)
                .OrderByDescending(x => x.OnCreated)
                .Select(x => new GameViewModel
                {
                    Id = x.Id,
                    OrderId = x.OrderId,
                    PlayerName = x.Player.Name,
                    CraneId = x.CraneId,
                    CraneName = x.Crane.Name,
                    Status = x.Status,
                    State = x.State,
                    OnCreated = x.OnCreated,
                    OnUpdated = x.OnUpdated
                })
                .ToList();

            return items;
        }

        public IEnumerable<GameViewModel> ListByCraneId(string craneId)
        {
            var items = _context.Games
                .Where(x => x.CraneId == craneId)
                .OrderByDescending(x => x.OnCreated)
                .Select(x => new GameViewModel
                {
                    Id = x.Id,
                    OrderId = x.OrderId,
                    PlayerName = x.Player.Name,
                    CraneId = x.CraneId,
                    CraneName = x.Crane.Name,
                    Status = x.Status,
                    State = x.State,
                    OnCreated = x.OnCreated,
                    OnUpdated = x.OnUpdated
                })
                .ToList();

            return items;
        }

        public IEnumerable<GameViewModel> ListByPlayerId(string playerId)
        {
            var items = _context.Games
                .Where(x => x.PlayerId == playerId)
                .OrderByDescending(x => x.OnCreated)
                .Select(x => new GameViewModel
                {
                    Id = x.Id,
                    OrderId = x.OrderId,
                    PlayerName = x.Player.Name,
                    CraneId = x.CraneId,
                    CraneName = x.Crane.Name,
                    Status = x.Status,
                    State = x.State,
                    OnCreated = x.OnCreated,
                    OnUpdated = x.OnUpdated
                })
                .ToList();

            return items;
        }

        //public async Task<bool> UpdateGame(string id, PlayStatus status, PlayState state)
        //{
        //    // collect user ip
        //    var effected = 0;

        //    var item = _context.Games
        //        .Where(x => x.Id == id && x.State == PlayState.Ready && x.Status < status)
        //        .SingleOrDefault();

        //    var now = DateTime.Now;

        //    if (item != null)
        //    {
        //        item.Status = status;
        //        item.State = state;
        //        item.OnUpdated = now;
        //        item.Plays.Add(new Play
        //        {
        //            Id = Guid.NewGuid().ToString(),
        //            Status = status,
        //            State = state,
        //            OnCreated = now
        //        });

        //        _context.Games.Update(item);
        //        effected = await _context.SaveChangesAsync();
        //    }

        //    return effected > 0;
        //}
    }
}

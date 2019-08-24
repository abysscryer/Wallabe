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
    public class PlayService : IPlayService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<PlayService> _logger;
        private readonly IMapper _mapper;

        public PlayService(ApplicationDbContext context, ILogger<PlayService> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<PlayViewModel> CreatePlay(PlayCreateModel createModel)
        {
            // collect user ip
            var effected = 0;

            var game = _context.Games
                .Where(x => x.Id == createModel.GameId && x.State == PlayState.Ready && x.Status < createModel.Status)
                .SingleOrDefault();

            var now = DateTime.Now;

            if (game != null)
            {
                try
                {
                    game.Status = createModel.Status;
                    game.State = createModel.State;
                    game.OnUpdated = now;

                    var play = new Play
                    {
                        Id = Guid.NewGuid().ToString(),
                        Status = createModel.Status,
                        State = createModel.State,
                        OnCreated = now
                    };
                    game.Plays.Add(play);

                    _context.Games.Update(game);
                    effected = await _context.SaveChangesAsync();

                    if (effected > 0)
                        return _mapper.Map<PlayViewModel>(play);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"error occured on craete play.", createModel);
                    throw;
                }
            }

            return new PlayViewModel();
        }

        public IEnumerable<PlayViewModel> ListByGameId(string id)
        {
            var items = _context.Plays
                .Where(x => x.GameId == id)
                .OrderByDescending(x => x.OnCreated)
                .Select(x => new PlayViewModel
                {
                    Id = x.Id,
                    Status = x.Status,
                    State = x.State,
                    OnCreated = x.OnCreated,
                    GameId = x.GameId
                })
                .ToList();

            return items;
        }
    }

}

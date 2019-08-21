using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallabe.Data;
using Wallabe.Domains;
using Wallabe.Models;

namespace Wallabe.Service
{
    public class RankService : IRankService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public RankService(ApplicationDbContext context, IMapper mapper, ILogger<RankService> logger)
        {
            _context = context;
            _mapper = mapper;
        }

        public RankViewModel GetByPlayerId(string playerId)
        {
            var item = _context.CraneRecords
                .Where(rank => rank.PlayerId == playerId)
                .GroupBy(rank => rank.PlayerId)
                .Select(filtered => new CraneRecord
                {
                    PlayerId = filtered.Key,
                    Try = filtered.Sum(result => result.Try),
                    Hit = filtered.Sum(result => result.Hit)
                });

            var model = _mapper.Map<RankViewModel>(item);

            return model;
        }

        public RankViewModel GetByPlayerIdNCraneId(string playerId, string craneId)
        {
            throw new NotImplementedException();
        }

        public RankViewModel GetByPlayerName(string playerName)
        {
            var item = _context.CraneRecords
                .Where(rank => rank.Player.Name == playerName)
                .Select( filtered => new CraneRecord
                {
                    PlayerId = filtered.PlayerId,
                    Player = filtered.Player,
                    Try = filtered.Try,
                    Hit = filtered.Hit
                })
                .GroupBy(filtered => filtered.PlayerId)
                .Select(group => new CraneRecord
                {
                    Player = group.FirstOrDefault().Player,
                    Try = group.Sum(result => result.Try),
                    Hit = group.Sum(result => result.Hit)
                });

            var model = _mapper.Map<RankViewModel>(item);

            return model;
        }

        public RankViewModel GetByPlayerNameNCraneId(string playerName, string craneId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RankViewModel> List(int count)
        {
            var items = _context.CraneRecords.ToList();
            var model = _mapper.Map<IEnumerable<RankViewModel>>(items);

            return model;
        }

        public IEnumerable<RankViewModel> List()
        {
            var items = _context.CraneRecords.ToList();
            var model = _mapper.Map<IEnumerable<RankViewModel>>(items);

            return model;
        }

        public IEnumerable<RankViewModel> ListByCraneId(string craneId)
        {
            var items = _context.CraneRecords.ToList();
            var model = _mapper.Map<IEnumerable<RankViewModel>>(items);

            return model;
        }

        public IEnumerable<RankViewModel> ListByCraneId(string craneId, int count)
        {
            var items = _context.CraneRecords.ToList();
            var model = _mapper.Map<IEnumerable<RankViewModel>>(items);

            return model;
        }
    }
}

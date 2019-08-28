using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallabe.Business;
using Wallabe.Data;
using Wallabe.Domains;
using Wallabe.Extensions;
using Wallabe.Models;

namespace Wallabe.Service
{
    public class RankService : IRankService
    {
        private readonly string _yesterday;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<RankService> _logger;
        
        public RankService(ApplicationDbContext context, ILogger<RankService> logger, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _yesterday = DateTime.Now.AddDays(-1).ToString("yyyyMMdd");
        }

        public IEnumerable<RankViewModel> List()
        {
            var items = _context.Records
                .Where(x => x.Date == _yesterday)
                .OrderBy(x => x.Rank)
                .ThenBy(x => x.Try)
                .ThenBy(x => x.Shift)
                .Select(x => new RankViewModel
                {
                    Date = x.Date,
                    Rank = x.Rank,
                    Shift = x.Shift,
                    Try = x.Try,
                    Hit = x.Hit,
                    Rate = x.Rate,
                    PlayerName = x.Player.Name,
                    ImagePath = x.Player.ImagePath
                })
                .ToList();

            if (items.Count == 0)
            {
                var task = Task.Run(() => CreateRecords());
                task.Wait();

                items = _context.Records
                    .Where(x => x.Date == _yesterday)
                    .OrderBy(x => x.Rank)
                    .ThenBy(x => x.Try)
                    .ThenBy(x => x.Shift)
                    .Select(x => new RankViewModel
                    {
                        Date = x.Date,
                        Rank = x.Rank,
                        Shift = x.Shift,
                        Try = x.Try,
                        Hit = x.Hit,
                        Rate = x.Rate,
                        PlayerName = x.Player.Name,
                        ImagePath = x.Player.ImagePath
                    })
                .ToList();
            }

            return items;
        }

        public IEnumerable<RankViewModel> List(int count)
        {
            var items = _context.Records
                .Where(x => x.Date == _yesterday)
                .OrderBy(x => x.Rank)
                .ThenBy(x => x.Try)
                .ThenBy(x => x.Shift)
                .Take(count)
                .Select(x => new RankViewModel
                {
                    Date = x.Date,
                    Rank = x.Rank,
                    Shift = x.Shift,
                    Try = x.Try,
                    Hit = x.Hit,
                    Rate = x.Rate,
                    PlayerName = x.Player.Name,
                    ImagePath = x.Player.ImagePath
                })
                .ToList();

            if (items.Count == 0)
            {
                var task = Task.Run(() => CreateRecords());
                task.Wait();

                items = _context.Records
                    .Where(x => x.Date == _yesterday)
                    .OrderBy(x => x.Rank)
                    .ThenBy(x => x.Try)
                    .ThenBy(x => x.Shift)
                    .Take(count)
                    .Select(x => new RankViewModel
                    {
                        Date = x.Date,
                        Rank = x.Rank,
                        Shift = x.Shift,
                        Try = x.Try,
                        Hit = x.Hit,
                        Rate = x.Rate,
                        PlayerName = x.Player.Name,
                        ImagePath = x.Player.ImagePath
                    })
                    .ToList();
            }

            return items;
        }

        public RankViewModel GetByPlayerId(string playerId)
        {
            var item = _context.Records
                .Where(x => x.Date == _yesterday && x.PlayerId == playerId)
                .Select(x => new RankViewModel
                {
                    Date = x.Date,
                    PlayerName = x.Player.Name,
                    ImagePath = x.Player.ImagePath,
                    Rank = x.Rank,
                    Shift = x.Shift,
                    Try = x.Try,
                    Hit = x.Hit,
                    Rate = x.Rate
                })
                .SingleOrDefault();

            return item;
        }

        public RankViewModel GetByPlayerName(string playerName)
        {
            var item = _context.Records
                .Where(x => x.Date == _yesterday && x.Player.Name == playerName)
                .Select(x => new RankViewModel
                {
                    Date = x.Date,
                    PlayerName = x.Player.Name,
                    ImagePath = x.Player.ImagePath,
                    Rank = x.Rank,
                    Shift = x.Shift,
                    Try = x.Try,
                    Hit = x.Hit,
                    Rate = x.Rate
                })
                .SingleOrDefault();

            return item;
        }

        public IEnumerable<RankViewModel> ListByCraneId(string craneId)
        {
            var items = _context.CraneRecords
                .Where(x => x.Date == _yesterday && x.CraneId == craneId)
                .OrderBy(x => x.Rank)
                .ThenBy(x => x.Try)
                .ThenBy(x => x.Shift)
                .Select(x => new RankViewModel
                {
                    Date = x.Date,
                    Rank = x.Rank,
                    Shift = x.Shift,
                    Try = x.Try,
                    Hit = x.Hit,
                    Rate = x.Rate,
                    PlayerName = x.Player.Name,
                    ImagePath = x.Player.ImagePath
                })
                .ToList();

            if (items.Count == 0)
            {
                var task = Task.Run(() => CreateCraneRecords(craneId));
                task.Wait();

                items = _context.CraneRecords
                    .Where(x => x.Date == _yesterday && x.CraneId == craneId)
                    .OrderBy(x => x.Rank)
                    .ThenBy(x => x.Try)
                    .ThenBy(x => x.Shift)
                    .Select(x => new RankViewModel
                    {
                        Date = x.Date,
                        Rank = x.Rank,
                        Shift = x.Shift,
                        Try = x.Try,
                        Hit = x.Hit,
                        Rate = x.Rate,
                        PlayerName = x.Player.Name,
                        ImagePath = x.Player.ImagePath
                    })
                .ToList();
            }

            return items;
        }

        public IEnumerable<RankViewModel> ListByCraneId(string craneId, int count)
        {
            var items = _context.CraneRecords
                .Where(x => x.Date == _yesterday && x.CraneId == craneId)
                .OrderBy(x => x.Rank)
                .ThenBy(x => x.Try)
                .ThenBy(x => x.Shift)
                .Take(count)
                .Select(x => new RankViewModel
                {
                    Date = x.Date,
                    Rank = x.Rank,
                    Shift = x.Shift,
                    Try = x.Try,
                    Hit = x.Hit,
                    Rate = x.Rate,
                    PlayerName = x.Player.Name,
                    ImagePath = x.Player.ImagePath
                })
                .ToList();

            if (items.Count == 0)
            {
                var task = Task.Run(() => CreateCraneRecords(craneId));
                task.Wait();

                items = _context.CraneRecords
                    .Where(x => x.Date == _yesterday && x.CraneId == craneId)
                    .OrderBy(x => x.Rank)
                    .ThenBy(x => x.Try)
                    .ThenBy(x => x.Shift)
                    .Take(count)
                    .Select(x => new RankViewModel
                    {
                        Date = x.Date,
                        Rank = x.Rank,
                        Shift = x.Shift,
                        Try = x.Try,
                        Hit = x.Hit,
                        Rate = x.Rate,
                        PlayerName = x.Player.Name,
                        ImagePath = x.Player.ImagePath
                    })
                    .ToList();
            }

            return items;
        }

        public RankViewModel GetByCraneIdNPlayerId(string craneId, string playerId)
        {
            var item = _context.CraneRecords
                .Where(x => x.Date == _yesterday && x.CraneId == craneId && x.PlayerId == playerId)
                .Select(x => new RankViewModel
                {
                    Date = x.Date,
                    PlayerName = x.Player.Name,
                    ImagePath = x.Player.ImagePath,
                    Rank = x.Rank,
                    Shift = x.Shift,
                    Try = x.Try,
                    Hit = x.Hit,
                    Rate = x.Rate
                })
                .SingleOrDefault();

            return item;
        }

        

        public RankViewModel GetByCraneIdNPlayerName(string craneId, string playerName)
        {
            var item = _context.CraneRecords
                .Where(x => x.Date == _yesterday && x.CraneId == craneId && x.Player.Name == playerName)
                .Select(x => new RankViewModel
                {
                    Date = x.Date,
                    PlayerName = x.Player.Name,
                    ImagePath = x.Player.ImagePath,
                    Rank = x.Rank,
                    Shift = x.Shift,
                    Try = x.Try,
                    Hit = x.Hit,
                    Rate = x.Rate
                })
                .SingleOrDefault();

            return item;
        }


        private void CreateCraneRecords(string craneId)
        {
            try
            {
                // 금주 월요일
                var monday = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
                var today = DateTime.Today;

                // 금주 월요일부터 금일 자정까지의 게임 데이터 중 종료 된 게임
                var todayRecords = _context.Players.GroupJoin(_context.Games,
                    player => player.Id,
                    game => game.PlayerId, (player, games) => new
                    {
                        Id = player.Id,
                        Games = games.DefaultIfEmpty().Where(g => g.OnCreated >= monday && g.OnCreated < today && g.CraneId == craneId && g.Status == PlayStatus.Over)
                    })
                    .Select(x => new
                    {
                        PlayerId = x.Id,
                        Try = x.Games.Count(),
                        Hit = x.Games.Sum(r => r == null ? 0 : r.State == PlayState.Win ? 1 : 0),
                    })
                    .Select(x => new Record
                    {
                        Date = _yesterday,
                        PlayerId = x.PlayerId,
                        Try = x.Try,
                        Hit = x.Hit,
                        Rate = (x.Try == 0 || x.Hit == 0) ? 0 : ((float)x.Hit / (float)x.Try * 100),
                        Rank = 0,
                        Shift = 0
                    })
                    .ToList();

                // 랭크 업데이트
                todayRecords.ForEach(x => x.Rank = todayRecords.Count(c => c.Rate > x.Rate) + 1);

                // 최근 레코드 기준일
                var lastDate = DateTime.Now.AddDays(-2).ToString("yyyyMMdd");

                // 최근 누적 집계 레코드
                var yesterdayRecodes = _context.CraneRecords
                    .Where(x => x.Date == lastDate && x.CraneId == craneId)
                    .ToList();

                // 변동 업데이트
                var newRecords = todayRecords.GroupJoin(yesterdayRecodes, t => t.PlayerId, y => y.PlayerId, (t, y) => new
                {
                    Today = t,
                    Yesterday = y.DefaultIfEmpty()
                })
                .Select(x => new CraneRecord
                {
                    Date = x.Today.Date,
                    CraneId = craneId,
                    PlayerId = x.Today.PlayerId,
                    Try = x.Today.Try,
                    Hit = x.Today.Hit,
                    Rate = x.Today.Rate,
                    Rank = x.Today.Rank,
                    Shift = x.Yesterday.FirstOrDefault() == null
                       ? (yesterdayRecodes.Count == 0
                           ? todayRecords.Count - x.Today.Rank
                           : yesterdayRecodes.Max(m => m == null ? 0 : m.Rank) - x.Today.Rank)
                       : x.Yesterday.FirstOrDefault().Rank - x.Today.Rank
                })
                .ToList();

                _context.CraneRecords.AddRange(newRecords);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"error occured on craete crane rank.", craneId);
                throw;
            }
        }

        private void CreateRecords()
        {
            try
            {
                // 금주 월요일
                var monday = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
                var today = DateTime.Today;

                // 금주 월요일부터 금일 자정까지의 게임 데이터 중 종료 된 게임
                var todayRecords = _context.Players.GroupJoin(_context.Games,
                    player => player.Id,
                    game => game.PlayerId, (player, games) => new
                    {
                        Id = player.Id,
                        Games = games.DefaultIfEmpty().Where(g => g.OnCreated >= monday && g.OnCreated < today && g.Status == PlayStatus.Over)
                    })
                    .Select(x => new
                    {
                        PlayerId = x.Id,
                        Try = x.Games.Count(),
                        Hit = x.Games.Sum(r => r == null ? 0 : r.State == PlayState.Win ? 1 : 0),
                    })
                    .Select(x => new Record
                    {
                        Date = _yesterday,
                        PlayerId = x.PlayerId,
                        Try = x.Try,
                        Hit = x.Hit,
                        Rate = (x.Try == 0 || x.Hit == 0) ? 0 : ((float)x.Hit / (float)x.Try * 100),
                        Rank = 0,
                        Shift = 0
                    })
                    .ToList();
                
                // 랭크 업데이트
                todayRecords.ForEach(x => x.Rank = todayRecords.Count(c => c.Rate > x.Rate) + 1);
                

                // 최근 레코드 기준일
                var lastDate = DateTime.Now.AddDays(-2).ToString("yyyyMMdd");

                // 최근 누적 집계 레코드
                var yesterdayRecodes = _context.Records
                    .Where(x => x.Date == lastDate)
                    .ToList();

                // 변동 업데이트
                var newRecords = todayRecords.GroupJoin(yesterdayRecodes, t => t.PlayerId, y => y.PlayerId, (t, y) => new
                {
                    Today = t,
                    Yesterday = y.DefaultIfEmpty()
                })
                .Select(x => new Record
                {
                    Date = x.Today.Date,
                    PlayerId = x.Today.PlayerId,
                    Try = x.Today.Try,
                    Hit = x.Today.Hit,
                    Rate = x.Today.Rate,
                    Rank = x.Today.Rank,
                    Shift = x.Yesterday.FirstOrDefault() == null
                       ? (yesterdayRecodes.Count == 0
                           ? todayRecords.Count - x.Today.Rank
                           : yesterdayRecodes.Max(m => m == null ? 0 : m.Rank) - x.Today.Rank)
                       : x.Yesterday.FirstOrDefault().Rank - x.Today.Rank
                })
                .ToList();

                _context.Records.AddRange(newRecords);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"error occured on craete crane rank.");
                throw;
            }


        }
    }
}

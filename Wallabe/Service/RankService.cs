﻿using AutoMapper;
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
        private readonly string _yesterday;
        private readonly DateTime _today;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<RankService> _logger;
        public RankService(ApplicationDbContext context, IMapper mapper, ILogger<RankService> logger)
        {
            _context = context;
            _mapper = mapper;
            _yesterday = DateTime.Now.AddDays(-1).ToString("yyyyMMdd");
            _today = DateTime.Today;
            _logger = logger;
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
                .Where(r => r.Date == _yesterday && r.PlayerId == playerId)
                .Select(f => new RankViewModel
                {
                    PlayerName = f.Player.Name,
                    ImagePath = f.Player.ImagePath,
                    Rank = f.Rank,
                    Shift = f.Shift,
                    Try = f.Try,
                    Hit = f.Hit,
                    Rate = f.Rate
                })
                .SingleOrDefault();

            return item;
        }

        public RankViewModel GetByPlayerName(string playerName)
        {
            var item = _context.Records
                .Where(r => r.Date == _yesterday && r.Player.Name == playerName)
                .Select(f => new RankViewModel
                {
                    PlayerName = f.Player.Name,
                    ImagePath = f.Player.ImagePath,
                    Rank = f.Rank,
                    Shift = f.Shift,
                    Try = f.Try,
                    Hit = f.Hit,
                    Rate = f.Rate
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
                .Where(r => r.Date == _yesterday && r.CraneId == craneId && r.PlayerId == playerId)
                .Select(f => new RankViewModel
                {
                    PlayerName = f.Player.Name,
                    ImagePath = f.Player.ImagePath,
                    Rank = f.Rank,
                    Shift = f.Shift,
                    Try = f.Try,
                    Hit = f.Hit,
                    Rate = f.Rate
                })
                .SingleOrDefault();

            return item;
        }

        

        public RankViewModel GetByCraneIdNPlayerName(string craneId, string playerName)
        {
            var item = _context.CraneRecords
                .Where(r => r.Date == _yesterday && r.CraneId == craneId && r.Player.Name == playerName)
                .Select(f => new RankViewModel
                {
                    PlayerName = f.Player.Name,
                    ImagePath = f.Player.ImagePath,
                    Rank = f.Rank,
                    Shift = f.Shift,
                    Try = f.Try,
                    Hit = f.Hit,
                    Rate = f.Rate
                })
                .SingleOrDefault();

            return item;
        }


        private void CreateCraneRecords(string craneId)
        {
            //if (!_context.CraneRecords.Any(x => x.CraneId == craneId && x.Date == yesterday))
            //{
                // 금주 월요일
                var monday = DateTime.Today.AddDays(Convert.ToInt32(DayOfWeek.Monday) - Convert.ToInt32(DateTime.Today.DayOfWeek));

                // 금주 월요일부터 금일 자정까지의 게임 데이터 중 종료 된 게임
                var games = _context.Games
                    .Where(x => x.OnCreated >= monday 
                        && x.OnCreated < _today
                        && x.CraneId == craneId
                        && x.Status == PlayStatus.Over)
                    .ToList();

                // 게임 데이터 집계하여 주간 누적 레코드 생성
                var records = games
                    .GroupBy(x => x.PlayerId)
                    .Select(x => new
                    {
                        PlayerId = x.Key,
                        Try = x.Count(),
                        Hit = x.Sum(r => r.State == PlayState.Win ? 1 : 0)
                    })
                    .Select(y => new
                    {
                        PlayerId = y.PlayerId,
                        Try = y.Try,
                        Hit = y.Hit,
                        Rate = ((float)y.Hit / (float)y.Try * 100)
                    })
                    .ToList();

            // 누적 레코드의 랭킹 업데이트
            var curRecords = records.OrderByDescending(x => x.Rate)
                .Select((record, index) => new CraneRecord
                {
                    Date = _yesterday,
                    CraneId = craneId,
                    PlayerId = record.PlayerId,
                    Try = record.Try,
                    Hit = record.Hit,
                    Rate = record.Rate,
                    Rank = records.Count(c => c.Rate > record.Rate) + 1,
                    Shift = 0
                })
                .ToList();

                // 최근 레코드 기준일
                var lastDate = DateTime.Now.AddDays(-2).ToString("yyyyMMdd");

            // 최근 누적 집계 레코드
            var oldRecords = _context.CraneRecords
                .Where(x => x.Date == lastDate && x.CraneId == craneId)
                .ToList();

            // 신규 레코드와 최근 레코드와의 변동 수치 연산
            var newRecords = (from cur in curRecords
                                join old in oldRecords on cur.PlayerId equals old.PlayerId into tmp
                                from old in tmp.DefaultIfEmpty()
                                select new CraneRecord
                                {
                                    Date = cur.Date,
                                    CraneId = cur.CraneId,
                                    PlayerId = cur.PlayerId,
                                    Try = cur.Try,
                                    Hit = cur.Hit,
                                    Rate = cur.Rate,
                                    Rank = cur.Rank,
                                    Shift = old?.Rank == null ? 0 : (int)old?.Rank - cur.Rank
                                }).ToList();

            //var newRecords = curRecords.Join(oldRecords.DefaultIfEmpty(), 
            //    curRecord => curRecord.PlayerId, 
            //    oldRecord => oldRecord.PlayerId, 
            //    (curRecord, oldRecord) => new CraneRecord
            //    {
            //        Date = curRecord.Date,
            //        CraneId = curRecord.CraneId,
            //        PlayerId = curRecord.PlayerId,
            //        Try = curRecord.Try,
            //        Hit = curRecord.Hit,
            //        Rate = curRecord.Rate,
            //        Rank = curRecord.Rank,
            //        Shift = oldRecord.Rank - curRecord.Rank
            //    })
            //    .ToList();

            if (newRecords.Count == 0)
                return;

            _context.CraneRecords.AddRange(newRecords);
            _context.SaveChanges();

            //};
        }

        private void CreateRecords()
        {
            //if (!_context.CraneRecords.Any(x => x.CraneId == craneId && x.Date == yesterday))
            //{
            // 금주 월요일
            var monday = DateTime.Today.AddDays(Convert.ToInt32(DayOfWeek.Monday) - Convert.ToInt32(DateTime.Today.DayOfWeek));
            
            // 금주 월요일부터 금일 자정까지의 게임 데이터 중 종료 된 게임
            var games = _context.Games
                .Where(x => x.OnCreated >= monday
                    && x.OnCreated < _today
                    && x.Status == PlayStatus.Over)
                .ToList();

            // 게임 데이터 집계하여 주간 누적 레코드 생성
            var records = games
                .GroupBy(x => x.PlayerId)
                .Select(x => new
                {
                    PlayerId = x.Key,
                    Try = x.Count(),
                    Hit = x.Sum(r => r.State == PlayState.Win ? 1 : 0)
                })
                .Select(y => new
                {
                    PlayerId = y.PlayerId,
                    Try = y.Try,
                    Hit = y.Hit,
                    Rate = ((float)y.Hit / (float)y.Try * 100)
                })
                .ToList();

            // 누적 레코드의 랭킹 업데이트
            var curRecords = records.OrderByDescending(x => x.Rate)
                .Select((record, index) => new Record
                {
                    Date = _yesterday,
                    PlayerId = record.PlayerId,
                    Try = record.Try,
                    Hit = record.Hit,
                    Rate = record.Rate,
                    Rank = records.Count(c => c.Rate > record.Rate) + 1,
                    Shift = 0
                })
                .ToList();

            // 최근 레코드 기준일
            var lastDate = DateTime.Now.AddDays(-2).ToString("yyyyMMdd");

            // 최근 누적 집계 레코드
            var oldRecords = _context.Records
                .Where(x => x.Date == lastDate)
                .ToList();

            // 신규 레코드와 최근 레코드와의 변동 수치 연산
            var newRecords = (from cur in curRecords
                                join old in oldRecords on cur.PlayerId equals old.PlayerId into tmp
                                from old in tmp.DefaultIfEmpty()
                                select new Record
                                {
                                    Date = cur.Date,
                                    PlayerId = cur.PlayerId,
                                    Try = cur.Try,
                                    Hit = cur.Hit,
                                    Rate = cur.Rate,
                                    Rank = cur.Rank,
                                    Shift = old?.Rank == null ? 0 : (int)old?.Rank - cur.Rank
                                }).ToList();

            //var newRecords = curRecords.Join(oldRecords.DefaultIfEmpty(), 
            //    curRecord => curRecord.PlayerId, 
            //    oldRecord => oldRecord.PlayerId, 
            //    (curRecord, oldRecord) => new CraneRecord
            //    {
            //        Date = curRecord.Date,
            //        CraneId = curRecord.CraneId,
            //        PlayerId = curRecord.PlayerId,
            //        Try = curRecord.Try,
            //        Hit = curRecord.Hit,
            //        Rate = curRecord.Rate,
            //        Rank = curRecord.Rank,
            //        Shift = oldRecord.Rank - curRecord.Rank
            //    })
            //    .ToList();

            if (newRecords.Count == 0)
                return;

            _context.Records.AddRange(newRecords);
            _context.SaveChanges();

            //};
        }
    }
}

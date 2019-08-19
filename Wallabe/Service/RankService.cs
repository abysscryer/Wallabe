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
    public class RankService : IRankService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public RankService(ApplicationDbContext context, IMapper mapper, ILogger<RankService> logger)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<RankViewModel> MonthlyList(int count)
        {
            // make duration 

            var items = _context.Ranks.ToList();
            var model = _mapper.Map<IEnumerable<RankViewModel>>(items);

            // order by rate desc
            // take count

            return model;
        }

        public IEnumerable<RankViewModel> MonthlyList()
        {
            var items = _context.Ranks.ToList();
            var model = _mapper.Map<IEnumerable<RankViewModel>>(items);

            return model;
        }

        public IEnumerable<RankViewModel> MonthlyListByCrane(int count)
        {
            var items = _context.Ranks.ToList();
            var model = _mapper.Map<IEnumerable<RankViewModel>>(items);

            return model;
        }

        public IEnumerable<RankViewModel> MonthlyListByCrane()
        {
            var items = _context.Ranks.ToList();
            var model = _mapper.Map<IEnumerable<RankViewModel>>(items);

            return model;
        }

        public IEnumerable<RankViewModel> WeeklyList(int count)
        {
            var items = _context.Ranks.ToList();
            var model = _mapper.Map<IEnumerable<RankViewModel>>(items);

            return model;
        }

        public IEnumerable<RankViewModel> WeeklyList()
        {
            var items = _context.Ranks.ToList();
            var model = _mapper.Map<IEnumerable<RankViewModel>>(items);

            return model;
        }

        public IEnumerable<RankViewModel> WeeklyListByCrane(int count)
        {
            var items = _context.Ranks.ToList();
            var model = _mapper.Map<IEnumerable<RankViewModel>>(items);

            return model;
        }

        public IEnumerable<RankViewModel> WeeklyListByCrane()
        {
            var items = _context.Ranks.ToList();
            var model = _mapper.Map<IEnumerable<RankViewModel>>(items);

            return model;
        }

        /// <summary>
        /// weekly, monthly, byCrane
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        //public IEnumerable<RankViewModel> ListAsync(int count)
        //{
        //    var items = _context.Ranks.ToList();
        //    var model = _mapper.Map<IEnumerable<RankViewModel>>(items);

        //    return model;
        //}

        //public IEnumerable<RankViewModel> ListAsync()
        //{
        //    var items = _context.Ranks.ToList();
        //    var model = _mapper.Map<IEnumerable<RankViewModel>>(items);

        //    return model;
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wallabe.Data;
using Wallabe.Domains;
using Wallabe.Models;
using Wallabe.Service;

namespace Wallabe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RanksController : ControllerBase
    {
        private readonly IRankService _rankService;

        public RanksController(IRankService rankService)
        {
            _rankService = rankService;
        }

        // GET: api/cranes
        [HttpGet("month/{count:int}")]
        public IEnumerable<RankViewModel> GeMonthlyRanks([FromRoute]int count)
        {
            return _rankService.MonthlyList(count);
        }

        // GET: api/cranes
        [HttpGet("month")]
        public IEnumerable<RankViewModel> GeMonthlyRanks()
        {
            return _rankService.MonthlyList();
        }

        // GET: api/cranes
        [HttpGet("month/{id:guid}/{count:int}")]
        public IEnumerable<RankViewModel> GeMonthlyRanksByCrane([FromRoute]string id, [FromRoute]int count)
        {
            return _rankService.MonthlyListByCrane(count);
        }

        // GET: api/cranes
        [HttpGet("month/{id:guid}")]
        public IEnumerable<RankViewModel> GeMonthlyRanksByCrane([FromRoute]string id)
        {
            return _rankService.MonthlyListByCrane();
        }

        // GET: api/cranes
        [HttpGet("week/{count:int}")]
        public IEnumerable<RankViewModel> GetWeeklyRanks([FromRoute]int count)
        {
            return _rankService.WeeklyList(count);
        }

        // GET: api/cranes
        [HttpGet("week")]
        public IEnumerable<RankViewModel> GetWeeklyRanks()
        {
            return _rankService.WeeklyList();
        }

        // GET: api/cranes
        [HttpGet("week/{id:guid}/{count:int}")]
        public IEnumerable<RankViewModel> GetWeeklyRanksByCrane([FromRoute]string id, [FromRoute]int count)
        {
            return _rankService.WeeklyListByCrane(count);
        }

        // GET: api/cranes
        [HttpGet("week/{id:guid}")]
        public IEnumerable<RankViewModel> GetWeeklyRanksByCrane([FromRoute]string id)
        {
            return _rankService.WeeklyListByCrane();
        }
    }
}
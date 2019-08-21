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

namespace Wallabe.Controllers.Api
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

        /// <summary>
        /// GET: api/ranks/{palyerId}
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>
        [HttpGet("{playerId:guid}")]
        public RankViewModel GeByPalyerId([FromRoute]string playerId)
        {
            return _rankService.GetByPlayerId(playerId);
        }

        /// <summary>
        /// GET: api/ranks/{playerId}/{craneId}
        /// </summary>
        /// <param name="playerId"></param>
        /// <param name="craneId"></param>
        /// <returns></returns>
        [HttpGet("{playerId:guid}/{craneId:guid}")]
        public RankViewModel GeByPaylerIdNCraneId([FromRoute]string playerId, [FromRoute]string craneId)
        {
            return _rankService.GetByPlayerIdNCraneId(playerId, craneId);
        }

        /// <summary>
        /// GET: api/ranks/{playerName}
        /// </summary>
        /// <param name="playerName"></param>
        /// <returns></returns>
        [HttpGet("{playerName}")]
        public RankViewModel GeByPlayerName([FromRoute]string playerName)
        {
            return _rankService.GetByPlayerName(playerName);
        }

        /// <summary>
        /// GET: api/ranks/{playerName}/{craneId}
        /// </summary>
        /// <param name="playerName"></param>
        /// <param name="craneId"></param>
        /// <returns></returns>
        [HttpGet("{playerName}/{craneId:guid}")]
        public RankViewModel GeByPlayerNameNCraneId([FromRoute]string playerName, [FromRoute]string craneId)
        {
            return _rankService.GetByPlayerNameNCraneId(playerName, craneId);
        }

        // GET: api/cranes
        [HttpGet("{count:int}")]
        public IEnumerable<RankViewModel> GetRanks([FromRoute]int count)
        {
            return _rankService.List(count);
        }

        // GET: api/cranes
        [HttpGet]
        public IEnumerable<RankViewModel> GetRanks()
        {
            return _rankService.List();
        }

        // GET: api/cranes
        [HttpGet("{craneId:guid}/{count:int}")]
        public IEnumerable<RankViewModel> GetByCraneId([FromRoute]string craneId, [FromRoute]int count)
        {
            return _rankService.ListByCraneId(craneId, count);
        }

        // GET: api/cranes
        [HttpGet("{craneId:guid}")]
        public IEnumerable<RankViewModel> GetByCraneId([FromRoute]string craneId)
        {
            return _rankService.ListByCraneId(craneId);
        }
    }
}
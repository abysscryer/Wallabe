using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wallabe.Business;
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
        /// GET: api/ranks 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<RankViewModel> GetRanks()
        {
            return _rankService.List();
        }

        /// <summary>
        /// GET: api/ranks/{count:int} 
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        [HttpGet("{count:int}")]
        public IEnumerable<RankViewModel> GetRanks([FromRoute]int count)
        {
            return _rankService.List(count);
        }

        /// <summary>
        /// GET: api/ranks/{palyerId:guid}
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>
        [HttpGet("{playerId:guid}")]
        public RankViewModel GeByPalyerId([FromRoute]string playerId)
        {
            return _rankService.GetByPlayerId(playerId);
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
        /// GET: api/ranks/crane/{craneId:guid} 
        /// </summary>
        /// <param name="craneId"></param>
        /// <returns></returns>
        [HttpGet("crane/{craneId:guid}")]
        public IEnumerable<RankViewModel> GetByCraneId([FromRoute]string craneId)
        {
            return _rankService.ListByCraneId(craneId);
        }

        /// <summary>
        /// GET: api/ranks/crane/{craneId:guid}/{count:int} 
        /// </summary>
        /// <param name="craneId"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [HttpGet("crane/{craneId:guid}/{count:int}")]
        public IEnumerable<RankViewModel> GetByCraneId([FromRoute]string craneId, [FromRoute]int count)
        {
            return _rankService.ListByCraneId(craneId, count);
        }

        /// <summary>
        /// GET: api/ranks/crane/{craneId:guid}/{playerId:guid}
        /// </summary>
        /// <param name="playerId"></param>
        /// <param name="craneId"></param>
        /// <returns></returns>
        [HttpGet("crane/{craneId:guid}/{playerId:guid}")]
        public RankViewModel GeByPaylerIdNCraneId([FromRoute]string craneId, [FromRoute]string playerId)
        {
            return _rankService.GetByCraneIdNPlayerId(craneId, playerId);
        }

        /// <summary>
        /// GET: api/ranks/crane/{craneId:guid}/{playerName}/
        /// </summary>
        /// <param name="playerName"></param>
        /// <param name="craneId"></param>
        /// <returns></returns>
        [HttpGet("crane/{craneId:guid}/{playerName}")]
        public RankViewModel GeByPlayerNameNCraneId([FromRoute]string craneId, [FromRoute]string playerName)
        {
            return _rankService.GetByCraneIdNPlayerName(craneId, playerName);
        }
    }
}
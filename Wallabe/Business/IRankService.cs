using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallabe.Models;

namespace Wallabe.Business
{
    public interface IRankService
    {
        /// <summary>
        /// 전체 리스트
        /// </summary>
        /// <returns></returns>
        IEnumerable<RankViewModel> List();

        /// <summary>
        /// 전체 상위 리스트 
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        IEnumerable<RankViewModel> List(int count);

        /// <summary>
        /// 플레이어 아이디 전체 랭크
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>
        RankViewModel GetByPlayerId(string playerId);

        /// <summary>
        /// 플레이어 닉네임 전체 랭크
        /// </summary>
        /// <param name="playerName"></param>
        /// <returns></returns>
        RankViewModel GetByPlayerName(string playerName);

        /// <summary>
        /// 크레인 리스트
        /// </summary>
        /// <returns></returns>
        IEnumerable<RankViewModel> ListByCraneId(string craneId);

        /// <summary>
        /// 크레인 상위 리스트
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        IEnumerable<RankViewModel> ListByCraneId(string craneId, int count);

        /// <summary>
        /// 플레이어 아이디 크레인 랭크
        /// </summary>
        /// <param name="playerId"></param>
        /// <param name="craneId"></param>
        /// <returns></returns>
        RankViewModel GetByCraneIdNPlayerId(string craneId, string playerId);

        /// <summary>
        /// 플레이어 닉네임 크레인 랭크
        /// </summary>
        /// <param name="playerName"></param>
        /// <param name="craneId"></param>
        /// <returns></returns>
        RankViewModel GetByCraneIdNPlayerName(string craneId, string playerName);
                
        //Task<IPagedList<RankViewModel>> ListAsync(RankSearchModel searchModel);
        //Task<bool> CreateAsync(RankCreateModel createModel);
        //Task<bool> UpdateAsync(string id, RankUpdateModel updateModel);
        //Task<bool> DeleteAsync(string id, RankDeleteModel deleteModel);
        //Task<RankViewModel> GetAsync(string id);
    }
}

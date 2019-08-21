using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallabe.Models;

namespace Wallabe.Service
{
    public interface IRankService
    {
        /// <summary>
        /// 플레이어 아이디로 랭크 불러오기
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>
        RankViewModel GetByPlayerId(string playerId);

        /// <summary>
        /// 플레이어 아이디로 크레인 랭크 불러오기
        /// </summary>
        /// <param name="playerId"></param>
        /// <param name="craneId"></param>
        /// <returns></returns>
        RankViewModel GetByPlayerIdNCraneId(string playerId, string craneId);

        /// <summary>
        /// 플레이어 닉네임으로 랭크 불러오기
        /// </summary>
        /// <param name="playerName"></param>
        /// <returns></returns>
        RankViewModel GetByPlayerName(string playerName);

        /// <summary>
        /// 플레이어 닉네임으로 크레인 랭크 불러오기
        /// </summary>
        /// <param name="playerName"></param>
        /// <param name="craneId"></param>
        /// <returns></returns>
        RankViewModel GetByPlayerNameNCraneId(string playerName, string craneId);

        /// <summary>
        /// 주간 상위 리스트 
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        IEnumerable<RankViewModel>List(int count);

        /// <summary>
        /// 주간 전체 리스트
        /// </summary>
        /// <returns></returns>
        IEnumerable<RankViewModel> List();

        /// <summary>
        /// 주간 크레인별 전체 리스트
        /// </summary>
        /// <returns></returns>
        IEnumerable<RankViewModel> ListByCraneId(string craneId);

        /// <summary>
        /// 주간 크레인별 상위 리스트
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        IEnumerable<RankViewModel> ListByCraneId(string craneId, int count);
        
        //Task<IPagedList<RankViewModel>> ListAsync(RankSearchModel searchModel);
        //Task<bool> CreateAsync(RankCreateModel createModel);
        //Task<bool> UpdateAsync(string id, RankUpdateModel updateModel);
        //Task<bool> DeleteAsync(string id, RankDeleteModel deleteModel);
        //Task<RankViewModel> GetAsync(string id);
    }
}

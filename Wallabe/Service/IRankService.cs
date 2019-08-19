using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallabe.Models;

namespace Wallabe.Service
{
    public interface IRankService
    {
        IEnumerable<RankViewModel> MonthlyList(int count);
        IEnumerable<RankViewModel> MonthlyList();
        IEnumerable<RankViewModel> MonthlyListByCrane(int count);
        IEnumerable<RankViewModel> MonthlyListByCrane();
        IEnumerable<RankViewModel> WeeklyList(int count);
        IEnumerable<RankViewModel> WeeklyList();
        IEnumerable<RankViewModel> WeeklyListByCrane(int count);
        IEnumerable<RankViewModel> WeeklyListByCrane();
        //Task<IPagedList<RankViewModel>> ListAsync(RankSearchModel searchModel);
        //Task<bool> CreateAsync(RankCreateModel createModel);
        //Task<bool> UpdateAsync(string id, RankUpdateModel updateModel);
        //Task<bool> DeleteAsync(string id, RankDeleteModel deleteModel);
        //Task<RankViewModel> GetAsync(string id);
    }
}

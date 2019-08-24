using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallabe.Models;

namespace Wallabe.Business
{
    public interface IDollService
    {
        IEnumerable<DollViewModel> List(int count);
        IEnumerable<DollViewModel> List();
        IEnumerable<DollViewModel> ListByCraneId(string craneId);
        IEnumerable<DollViewModel> ListByCraneId(string craneId, int count);
        //Task<IPagedList<DollViewModel>> ListAsync(DollSearchModel searchModel);
        //Task<bool> CreateAsync(DollCreateModel createModel);
        //Task<bool> UpdateAsync(string id, DollUpdateModel updateModel);
        //Task<bool> DeleteAsync(string id, DollDeleteModel deleteModel);
        //Task<DollViewModel> GetAsync(string id);
    }
}

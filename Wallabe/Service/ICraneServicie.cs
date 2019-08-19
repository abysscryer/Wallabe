using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallabe.Models;

namespace Wallabe.Service
{
    public interface ICraneService
    {
        IEnumerable<CraneViewModel> List();
        //Task<IPagedList<CraneViewModel>> ListAsync(CraneSearchModel searchModel);
        //Task<bool> CreateAsync(CraneCreateModel createModel);
        //Task<bool> UpdateAsync(string id, CraneUpdateModel updateModel);
        //Task<bool> DeleteAsync(string id, CraneDeleteModel deleteModel);
        //Task<CraneViewModel> GetAsync(string id);
    }
}

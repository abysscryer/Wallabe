using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallabe.Domains;
using Wallabe.Models;

namespace Wallabe.Business
{
    public interface IPlayService
    {
        IEnumerable<PlayViewModel> ListByGameId(string id);
        Task<PlayViewModel> CreatePlay(PlayCreateModel createModel);

    }

}

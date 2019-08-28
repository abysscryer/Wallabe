using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallabe.Models;

namespace Wallabe.Business
{
    public interface IPlayerService
    {
        IEnumerable<PlayerViewModel> List();

    }
}

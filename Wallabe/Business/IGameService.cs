using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallabe.Models;

namespace Wallabe.Business
{
    public interface IGameService
    {
        IEnumerable<GameViewModel> List();

        IEnumerable<GameViewModel> ListByOrderId(string orderId);

        IEnumerable<GameViewModel> ListByPlayerId(string playerId);

        IEnumerable<GameViewModel> ListByCraneId(string craneId);

        IEnumerable<GameViewModel> ListReadyByCraneId(string craneId);


    }
}

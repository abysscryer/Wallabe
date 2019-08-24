using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallabe.Domains;
using Wallabe.Models;

namespace Wallabe.Business
{
    public interface IOrderService
    {
        Task<OrderViewModel> CreateAsync(OrderCreateModel createModel);
        IEnumerable<OrderViewModel> ListByPlayerId(string playerId);
    }
}

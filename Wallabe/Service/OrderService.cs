using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallabe.Data;
using Wallabe.Models;
using Wallabe.Domains;
using Wallabe.Business;

namespace Wallabe.Service
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<OrderService> _logger;
        private readonly IMapper _mapper;

        public OrderService(ApplicationDbContext context, ILogger<OrderService> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<OrderViewModel> CreateAsync(OrderCreateModel createModel)
        {
            // 캐시 체크

            var player = await _context.Players.Where(x => x.Id == createModel.PlayerId).FirstOrDefaultAsync();
            var product = await _context.Products.Where(x => x.Id == createModel.ProductId).FirstOrDefaultAsync();
            var now = DateTime.Now;

            if (player.Cash >= product.Cash)
            {
                try
                {
                    player.Cash = player.Cash - product.Cash;

                    _context.Players.Update(player);

                    var order = new Order
                    {
                        Id = Guid.NewGuid().ToString(),
                        PlayerId = createModel.PlayerId,
                        ProductId = createModel.ProductId,
                        OnCreated = now
                    };

                    for (int i = 0; i < product.Quantity; i++)
                    {
                        var game = new Game
                        {
                            Id = Guid.NewGuid().ToString(),
                            Status = PlayStatus.Pending,
                            State = PlayState.Ready,
                            OnCreated = now,
                            OnUpdated = DateTime.MinValue,
                            CraneId = product.CraneId,
                            PlayerId = createModel.PlayerId
                        };

                        var play = new Play
                        {
                            Id = Guid.NewGuid().ToString(),
                            OnCreated = now,
                            Status = PlayStatus.Pending,
                            State = PlayState.Ready
                        };

                        game.Plays.Add(play);
                        order.Games.Add(game);
                    }

                    _context.Orders.Add(order);

                    var effected = await _context.SaveChangesAsync();

                    if (effected > 0)
                    {
                        var viewModel = _context.Orders
                        .Where(x => x.Id == order.Id)
                        .Select(x => new OrderViewModel
                        {
                            Id = x.Id,
                            OnCreated = x.OnCreated,
                            ProductId = x.ProductId,
                            PlayerName = x.Player.Name,
                            ProductName = x.Product.Name
                        })
                        .SingleOrDefault();

                        return viewModel;
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"error occured on craete order.", createModel);
                    throw;
                }
            }

            return new OrderViewModel();
        }

        public IEnumerable<OrderViewModel> ListByPlayerId(string playerId)
        {
            var items = _context.Orders
                .Where(x => x.PlayerId == playerId)
                .OrderByDescending(x => x.OnCreated)
                .Select(x => new OrderViewModel
                {
                    Id = x.Id,
                    OnCreated = x.OnCreated,
                    ProductId = x.ProductId,
                    ProductName = x.Product.Name,
                    PlayerName = x.Player.Name
                })
                .ToList();

            return items;
        }
    }
}

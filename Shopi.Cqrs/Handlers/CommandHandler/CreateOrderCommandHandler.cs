using MediatR;
using Shopi.Cqrs.Commands;
using Shopi.Cqrs.Responses;
using Shopi.Repository;
using Shopi.Repository.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shopi.Cqrs.Handlers.CommandHandler
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderListCommand, OrderCreateReponse>
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderCommandHandler(MemoryDBContext context, IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderCreateReponse> Handle(CreateOrderListCommand createOrderListCommand, CancellationToken cancellationToken)
        {
            createOrderListCommand.CreateOrderCommandList = createOrderListCommand.CreateOrderCommandList.Where(x => x.BrandId != 0).ToList();

            var entity = createOrderListCommand.CreateOrderCommandList.Select(m => new OrderEntity
            {
                BrandId = m.BrandId,
                CreatedOn = m.CreatedOn,
                CustomerName = m.CustomerName,
                Price = m.Price,
                StoreName = m.StoreName,
                Status = (int)m.Status
            }).ToList();
            await _orderRepository.Add(entity);
      
            return new OrderCreateReponse
            {
                IsSuccess = true
            };
        }
    }
    }

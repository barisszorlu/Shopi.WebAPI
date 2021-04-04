using MediatR;
using Shopi.Business;
using Shopi.Cqrs.Models;
using Shopi.Cqrs.Queries;
using Shopi.Cqrs.Responses;
using Shopi.Models;
using Shopi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shopi.Cqrs.Handlers.QueryHandler
{
    public class GetOrderByFilterQueryHandler : IRequestHandler<GetOrderByFilterQuery, OrderFilterResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IReflectionSorter _reflectionSorter;

        public GetOrderByFilterQueryHandler(IOrderRepository orderRepository, IReflectionSorter reflectionSorter)
        {
            _orderRepository = orderRepository;
            _reflectionSorter = reflectionSorter;
        }
        public async Task<OrderFilterResponse> Handle(GetOrderByFilterQuery getByFilterOrderQueryRequest, CancellationToken cancellationToken)
        {
            var list = await _orderRepository.Search(
                new OrderFilterModel
                {
                    EndDate = getByFilterOrderQueryRequest.EndDate,
                    PageNumber = getByFilterOrderQueryRequest.PageNumber,
                    PageSize = getByFilterOrderQueryRequest.PageSize,
                    SearchText = getByFilterOrderQueryRequest.SearchText,
                    SortBy = getByFilterOrderQueryRequest.SortBy,
                    StartDate = getByFilterOrderQueryRequest.StartDate,
                    Statuses = getByFilterOrderQueryRequest.Statuses
                });
            list = _reflectionSorter.Sorter(list, getByFilterOrderQueryRequest.SortBy);

            return new OrderFilterResponse
            {
                OrderList = list.Select(m => new OrderModel
                {
                    Id = m.Id,
                    BrandId = m.BrandId,
                    CreatedOn = m.CreatedOn,
                    CustomerName = m.CustomerName,
                    Price = m.Price,
                    StoreName = m.StoreName,
                    Status = m.Status,
                    //StatusNameValue = Enum.GetName(typeof(OrderStatus), m.Status),
                }).ToList()
            };
        }
    }
}

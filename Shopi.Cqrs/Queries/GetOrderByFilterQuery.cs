using MediatR;
using Shopi.Cqrs.Responses;
using Shopi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopi.Cqrs.Queries
{
    public class GetOrderByFilterQuery : IRequest<OrderFilterResponse>
    {
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
        public string SearchText { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<OrderStatus> Statuses { get; set; }
        public string SortBy { get; set; }
    }
}

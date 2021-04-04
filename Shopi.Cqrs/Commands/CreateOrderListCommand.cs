using MediatR;
using Shopi.Cqrs.Models;
using Shopi.Cqrs.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopi.Cqrs.Commands
{
    public class CreateOrderListCommand : IRequest<OrderCreateReponse>
    {
        public List<OrderCommandModel> CreateOrderCommandList { get; set; }
    }
}

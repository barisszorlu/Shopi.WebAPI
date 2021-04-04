using MediatR;
using Shopi.Cqrs.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Shopi.Cqrs.Responses;
using Shopi.Cqrs.Commands;
using System;

namespace Shopi.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopiController : Controller
    {
        private readonly IMediator _mediator;

        public ShopiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add")]
        public async Task<OrderCreateReponse> Add(CreateOrderListCommand createOrderListCommand)
        {
            return await _mediator.Send(createOrderListCommand);
        }

        [HttpPost("search")]
        public async Task<OrderFilterResponse> Search(GetOrderByFilterQuery getOrderByFilterQuery)
        {

            return await _mediator.Send(getOrderByFilterQuery);
        }
    }
}

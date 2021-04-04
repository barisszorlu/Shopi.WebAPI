using Shopi.Cqrs.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopi.Cqrs.Responses
{
    public class OrderFilterResponse
    {
        public List<OrderModel> OrderList { get; set; }
    }
}

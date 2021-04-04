using Shopi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopi.Cqrs.Models
{
    public class OrderCommandModel
    {
        public int BrandId { get; set; }
        public decimal Price { get; set; }
        public string StoreName { get; set; }
        public string CustomerName { get; set; }
        public DateTime CreatedOn { get; set; }
        public OrderStatus Status { get; set; }
    }
}

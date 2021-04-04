using System;
using System.Collections.Generic;
using System.Text;

namespace Shopi.Cqrs.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public decimal Price { get; set; }
        public string StoreName { get; set; }
        public string CustomerName { get; set; }
        public DateTime CreatedOn { get; set; }
        public int Status { get; set; }
    }
}

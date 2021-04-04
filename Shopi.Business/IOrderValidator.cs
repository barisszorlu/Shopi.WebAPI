using Shopi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopi.Business
{
    public interface IOrderValidator
    {
        void OrderListValidation(List<Order> orders);
    }
}

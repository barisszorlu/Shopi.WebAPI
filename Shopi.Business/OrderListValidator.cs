using FluentValidation;
using Shopi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopi.Business
{
    public class OrderList2Validator : AbstractValidator<List<Order>>
    {
        public OrderList2Validator()
        {
            RuleForEach(x => x).SetValidator(new OrderValidator());
        }
    }
}

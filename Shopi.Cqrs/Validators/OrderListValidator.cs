using FluentValidation;
using Shopi.Cqrs.Commands;
using Shopi.Cqrs.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopi.Cqrs.Validators
{
    public class OrderListValidator : AbstractValidator<CreateOrderListCommand>
    {
        public OrderListValidator()
        {
            RuleForEach(x => x.CreateOrderCommandList).SetValidator(new OrderValidator());
        }
    }
}

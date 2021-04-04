using FluentValidation;
using Shopi.Cqrs.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopi.Cqrs.Validators
{
    public class OrderValidator : AbstractValidator<OrderCommandModel>
    {
        public OrderValidator()
        {
            RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
            RuleFor(x => x.StoreName).NotNull().NotEmpty().MinimumLength(1);
            RuleFor(x => x.CustomerName).NotNull().NotEmpty().MinimumLength(1);
            RuleFor(x => x.CreatedOn).Equals(default(DateTime));
            RuleFor(x => x.Status).NotNull().NotEmpty().IsInEnum();
        }
    }
}

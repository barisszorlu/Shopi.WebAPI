using FluentValidation;
using Shopi.Models;
using System;

namespace Shopi.Business
{
    public class OrderValidator : AbstractValidator<Order>
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

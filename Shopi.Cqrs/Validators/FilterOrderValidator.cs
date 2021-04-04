using FluentValidation;
using Shopi.Cqrs.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopi.Cqrs.Validators
{
    public class FilterOrderValidator : AbstractValidator<GetOrderByFilterQuery>
    {
        public FilterOrderValidator()
        {
            RuleFor(x => x.PageNumber).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(x => x.PageSize).NotNull().NotEmpty().GreaterThan(0);
        }
    }
}

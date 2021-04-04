using FluentValidation;
using Shopi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopi.Business
{
    public class FilterValidator : AbstractValidator<OrderFilterModel>
    {
        public FilterValidator()
        {

            RuleFor(x => x.PageNumber).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(x => x.PageSize).NotNull().NotEmpty().GreaterThan(0);
        }
    }
}

using FluentValidation;
using Shopi.Cqrs.Commands;
using Shopi.Cqrs.Models;
using System;
using System.Collections.Generic;

namespace Shopi.Cqrs.Validators
{
    public class CreateOrderValidator : AbstractValidator<List<OrderCommandModel>>
    {
        public CreateOrderValidator()
        {
            RuleForEach(x => x).SetValidator(new OrderValidator());
        }
    }


}

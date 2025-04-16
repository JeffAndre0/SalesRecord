using Domain.Entities;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Domain.Validation;

public class CartValidator : AbstractValidator<SaleRecord>
{
    public CartValidator()
    {
        RuleForEach(s => s.Cart)
        .ChildRules(cart => 
        {
            cart.RuleFor(c => c.Quantity)
            .LessThanOrEqualTo(20)
            .WithMessage("Maximum limit: 20 items per cart.");
        });

        RuleForEach(s => s.Cart)
        .ChildRules(cart => 
        {
            cart.RuleFor(c => c.Quantity)
            .GreaterThan(0)
            .WithMessage("Minimum of 1 item of this cart.");
        });
    }

}

using Domain.Entities;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Domain.Validation;

public class ProductsValidator : AbstractValidator<SaleRecord>
{
    public ProductsValidator()
    {
        RuleForEach(cart => cart.Cart.Products)
        .ChildRules(product => 
        {
            product.RuleFor(p => p.Quantity)
            .LessThanOrEqualTo(20)
            .WithMessage("Maximum limit: 20 items per product.");
        });

        RuleForEach(cart => cart.Cart.Products)
        .ChildRules(product => 
        {
            product.RuleFor(p => p.Quantity)
            .GreaterThan(0)
            .WithMessage("Minimum of 1 item of this product.");
        });
    }

}

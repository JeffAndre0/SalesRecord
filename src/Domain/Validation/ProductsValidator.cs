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

    private bool BeValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        // More strict email validation
        var regex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
        return regex.IsMatch(email);
    }
}

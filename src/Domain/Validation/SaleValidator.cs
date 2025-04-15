using Domain.Entities;
using FluentValidation;

namespace Domain.Validation;

public class SaleValidator : AbstractValidator<SaleRecord>
{
    public SaleValidator()
    {
        RuleFor(sale => sale).SetValidator(new ProductsValidator());
    }
}

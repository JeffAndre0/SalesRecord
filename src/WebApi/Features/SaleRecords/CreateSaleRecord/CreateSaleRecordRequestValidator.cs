using Domain.Enums;
using Domain.Validation;
using FluentValidation;
using WebApi.Features.SaleRecord.CreateSaleRecord;

namespace WebApi.Features.SaleRecords.CreateSaleRecord;

/// <summary>
/// Validator for CreateSaleRecordRequest that defines validation rules for user creation.
/// </summary>
public class CreateSaleRecordRequestValidator : AbstractValidator<CreateSaleRecordRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateSaleRecordRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - CartProducts: Maximum limit: 20 items per product 
    /// - CartProducts: Minumum 1 items for product buyed 
    /// </remarks>
    public CreateSaleRecordRequestValidator()
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
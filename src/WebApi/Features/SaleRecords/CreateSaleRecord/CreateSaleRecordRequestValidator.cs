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
    /// - CartCart: Maximum limit: 20 items per cart 
    /// - CartCart: Minumum 1 items for cart buyed 
    /// </remarks>
    public CreateSaleRecordRequestValidator()
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
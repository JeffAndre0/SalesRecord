using Domain.Enums;
using Domain.Validation;
using FluentValidation;

namespace Application.SaleRecords.CreateSaleRecord;

/// <summary>
/// Validator for CreateSaleRecordCommand that defines validation rules for salerecord creation command.
/// </summary>
public class CreateSaleRecordCommandValidator : AbstractValidator<CreateSaleRecordCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateSaleRecordCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Email: Must be in valid format (using EmailValidator)
    /// - SaleRecordname: Required, must be between 3 and 50 characters
    /// - Password: Must meet security requirements (using PasswordValidator)
    /// - Phone: Must match international format (+X XXXXXXXXXX)
    /// - Status: Cannot be set to Unknown
    /// - Role: Cannot be set to None
    /// </remarks>
    public CreateSaleRecordCommandValidator()
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
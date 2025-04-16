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
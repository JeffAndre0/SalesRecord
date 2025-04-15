using FluentValidation;

namespace Application.SaleRecords.GetSaleRecord;

/// <summary>
/// Validator for GetSaleRecordCommand
/// </summary>
public class GetSaleRecordValidator : AbstractValidator<GetSaleRecordCommand>
{
    /// <summary>
    /// Initializes validation rules for GetSaleRecordCommand
    /// </summary>
    public GetSaleRecordValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("SaleRecord ID is required");
    }
}

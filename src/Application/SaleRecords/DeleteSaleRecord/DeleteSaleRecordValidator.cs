using FluentValidation;

namespace Application.SaleRecords.DeleteSaleRecord;

/// <summary>
/// Validator for DeleteSaleRecordCommand
/// </summary>
public class DeleteSaleRecordValidator : AbstractValidator<DeleteSaleRecordCommand>
{
    /// <summary>
    /// Initializes validation rules for DeleteSaleRecordCommand
    /// </summary>
    public DeleteSaleRecordValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("SaleRecord ID is required");
    }
}

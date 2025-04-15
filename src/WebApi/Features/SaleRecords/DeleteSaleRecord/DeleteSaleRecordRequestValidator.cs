using FluentValidation;

namespace WebApi.Features.SaleRecords.DeleteSaleRecord;

/// <summary>
/// Validator for DeleteSaleRecordRequest
/// </summary>
public class DeleteSaleRecordRequestValidator : AbstractValidator<DeleteSaleRecordRequest>
{
    /// <summary>
    /// Initializes validation rules for DeleteSaleRecordRequest
    /// </summary>
    public DeleteSaleRecordRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("SaleRecord ID is required");
    }
}

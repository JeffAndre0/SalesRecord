using FluentValidation;

namespace WebApi.Features.SaleRecords.GetSaleRecord;

/// <summary>
/// Validator for GetSaleRecordRequest
/// </summary>
public class GetSaleRecordRequestValidator : AbstractValidator<GetSaleRecordRequest>
{
    /// <summary>
    /// Initializes validation rules for GetSaleRecordRequest
    /// </summary>
    public GetSaleRecordRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("SaleRecord ID is required");
    }
}

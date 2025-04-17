using AutoMapper;
using MediatR;
using FluentValidation;
using Domain.Repositories;

namespace Application.SaleRecords.GetSaleRecord;

/// <summary>
/// Handler for processing GetSaleRecordCommand requests
/// </summary>
public class GetSaleRecordHandler : IRequestHandler<GetSaleRecordCommand, GetSaleRecordResult>
{
    private readonly ISaleRecordRepository _salerecordRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of GetSaleRecordHandler
    /// </summary>
    /// <param name="salerecordRepository">The salerecord repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for GetSaleRecordCommand</param>
    public GetSaleRecordHandler(
        ISaleRecordRepository salerecordRepository,
        IMapper mapper)
    {
        _salerecordRepository = salerecordRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the GetSaleRecordCommand request
    /// </summary>
    /// <param name="request">The GetSaleRecord command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The salerecord details if found</returns>
    public async Task<GetSaleRecordResult> Handle(GetSaleRecordCommand request, CancellationToken cancellationToken)
    {
        var validator = new GetSaleRecordValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var salerecord = await _salerecordRepository.GetByIdAsync(request.Id, cancellationToken);
        if (salerecord == null)
            throw new KeyNotFoundException($"SaleRecord with ID {request.Id} not found");

        return _mapper.Map<GetSaleRecordResult>(salerecord);
    }
}

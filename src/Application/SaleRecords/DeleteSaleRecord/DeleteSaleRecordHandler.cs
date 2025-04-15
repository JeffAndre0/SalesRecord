using MediatR;
using FluentValidation;
using Domain.Repositories;

namespace Application.SaleRecords.DeleteSaleRecord;

/// <summary>
/// Handler for processing DeleteSaleRecordCommand requests
/// </summary>
public class DeleteSaleRecordHandler : IRequestHandler<DeleteSaleRecordCommand, DeleteSaleRecordResponse>
{
    private readonly ISaleRecordRepository _userRepository;

    /// <summary>
    /// Initializes a new instance of DeleteSaleRecordHandler
    /// </summary>
    /// <param name="userRepository">The user repository</param>
    /// <param name="validator">The validator for DeleteSaleRecordCommand</param>
    public DeleteSaleRecordHandler(
        ISaleRecordRepository userRepository)
    {
        _userRepository = userRepository;
    }

    /// <summary>
    /// Handles the DeleteSaleRecordCommand request
    /// </summary>
    /// <param name="request">The DeleteSaleRecord command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The result of the delete operation</returns>
    public async Task<DeleteSaleRecordResponse> Handle(DeleteSaleRecordCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteSaleRecordValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var success = await _userRepository.DeleteAsync(request.Id, cancellationToken);
        if (!success)
            throw new KeyNotFoundException($"SaleRecord with ID {request.Id} not found");

        return new DeleteSaleRecordResponse { Success = true };
    }
}

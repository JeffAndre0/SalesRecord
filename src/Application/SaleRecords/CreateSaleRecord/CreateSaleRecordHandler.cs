using AutoMapper;
using MediatR;
using FluentValidation;
using Domain.Repositories;
using Domain.Entities;
using Common.Security;

namespace Application.SaleRecords.CreateSaleRecord;

/// <summary>
/// Handler for processing CreateSaleRecordCommand requests
/// </summary>
public class CreateSaleRecordHandler : IRequestHandler<CreateSaleRecordCommand, CreateSaleRecordResult>
{
    private readonly ISaleRecordRepository _salerecordRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of CreateSaleRecordHandler
    /// </summary>
    /// <param name="salerecordRepository">The salerecord repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for CreateSaleRecordCommand</param>
    public CreateSaleRecordHandler(ISaleRecordRepository salerecordRepository, IMapper mapper)
    {
        _salerecordRepository = salerecordRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the CreateSaleRecordCommand request
    /// </summary>
    /// <param name="command">The CreateSaleRecord command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created salerecord details</returns>
    public async Task<CreateSaleRecordResult> Handle(CreateSaleRecordCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateSaleRecordCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var salerecord = _mapper.Map<SaleRecord>(command);

        decimal total = 0;
        for (int c = 0; c < command.Cart.Count; c++)
        {
            if (command.Cart[c].Quantity >= 4 && command.Cart[c].Quantity < 10)
                command.Cart[c].Discount = (decimal)0.1 * command.Cart[c].UnityPrice * command.Cart[c].Quantity;
            else if (command.Cart[c].Quantity >= 10)
                command.Cart[c].Discount = (decimal)0.2 * command.Cart[c].UnityPrice * command.Cart[c].Quantity;
            else
                command.Cart[c].Discount = 0m;
            command.Cart[c].TotalAmount = (command.Cart[c].UnityPrice * command.Cart[c].Quantity) - command.Cart[c].Discount;
            total += command.Cart[c].TotalAmount;
        }
        command.TotalAmount = total;
        if (command.SaleDate == default)
            command.SaleDate = DateTime.UtcNow;
        var createdSaleRecord = await _salerecordRepository.CreateAsync(salerecord, cancellationToken);
        var result = _mapper.Map<CreateSaleRecordResult>(createdSaleRecord);
        return result;
    }
}

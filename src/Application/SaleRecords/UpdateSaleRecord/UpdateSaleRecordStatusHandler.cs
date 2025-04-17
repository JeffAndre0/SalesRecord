using MediatR;
using Microsoft.EntityFrameworkCore;
using Domain.Repositories;
using AutoMapper;

namespace Application.SaleRecords.UpdateStatus;

public class UpdateSaleRecordStatusCommandHandler : IRequestHandler<UpdateSaleRecordStatusCommand, Unit>
{
    
    private readonly ISaleRecordRepository _salerecordRepository;
    private readonly IMapper _mapper;

    public UpdateSaleRecordStatusCommandHandler(
        ISaleRecordRepository salerecordRepository,
        IMapper mapper)
    {
        _salerecordRepository = salerecordRepository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(UpdateSaleRecordStatusCommand request, CancellationToken cancellationToken)
    {
        Console.WriteLine($"[DEBUG] ID recebido PT 2: {request.SaleRecordId}");

        var salerecord = await _salerecordRepository.GetByIdAsync(request.SaleRecordId, cancellationToken);
        if (salerecord == null){
            Console.WriteLine($"[DEBUG] ID recebido PT 3: {request.SaleRecordId}");
            throw new KeyNotFoundException($"SaleRecord with ID {request.SaleRecordId} not found");
        }
        Console.WriteLine($"[DEBUG] ID recebido PT 4: {request.SaleRecordId}");

        salerecord.Status = request.NewStatus;
        Console.WriteLine($"[DEBUG] ID recebido PT 5: {request.SaleRecordId}");

        await _salerecordRepository.UpdateAsync(salerecord, cancellationToken);

        return Unit.Value;
    }
}

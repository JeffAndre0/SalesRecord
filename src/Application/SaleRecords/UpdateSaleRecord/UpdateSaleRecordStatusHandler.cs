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

        var salerecord = await _salerecordRepository.GetByIdAsync(request.SaleRecordId, cancellationToken);
        if (salerecord == null){
            throw new KeyNotFoundException($"SaleRecord with ID {request.SaleRecordId} not found");
        }

        salerecord.Status = request.NewStatus;

        await _salerecordRepository.UpdateAsync(salerecord, cancellationToken);

        return Unit.Value;
    }
}

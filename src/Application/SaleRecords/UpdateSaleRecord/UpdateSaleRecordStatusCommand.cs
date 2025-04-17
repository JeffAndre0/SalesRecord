using Domain.Enums;
using MediatR;

namespace Application.SaleRecords.UpdateStatus;

public class UpdateSaleRecordStatusCommand : IRequest<Unit>
{
    public UpdateSaleRecordStatusCommand(Guid id, SaleStatus status)
    {
        SaleRecordId = id;
        NewStatus = status;
    }

    public Guid SaleRecordId { get; set; }
    public SaleStatus NewStatus { get; set; }
}

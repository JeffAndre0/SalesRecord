using AutoMapper;

namespace WebApi.Features.SaleRecords.DeleteSaleRecord;

/// <summary>
/// Profile for mapping DeleteSaleRecord feature requests to commands
/// </summary>
public class DeleteSaleRecordProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for DeleteSaleRecord feature
    /// </summary>
    public DeleteSaleRecordProfile()
    {
        CreateMap<Guid, Application.SaleRecords.DeleteSaleRecord.DeleteSaleRecordCommand>()
            .ConstructUsing(id => new Application.SaleRecords.DeleteSaleRecord.DeleteSaleRecordCommand(id));
    }
}

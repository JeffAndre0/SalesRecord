using AutoMapper;

namespace WebApi.Features.SaleRecords.GetSaleRecord;

/// <summary>
/// Profile for mapping GetSaleRecord feature requests to commands
/// </summary>
public class GetSaleRecordProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetSaleRecord feature
    /// </summary>
    public GetSaleRecordProfile()
    {
        CreateMap<Guid, Application.SaleRecords.GetSaleRecord.GetSaleRecordCommand>()
            .ConstructUsing(id => new Application.SaleRecords.GetSaleRecord.GetSaleRecordCommand(id));
    }
}

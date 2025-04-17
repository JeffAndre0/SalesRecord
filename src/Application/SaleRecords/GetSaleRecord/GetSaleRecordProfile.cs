using AutoMapper;
using Domain.Entities;

namespace Application.SaleRecords.GetSaleRecord;

/// <summary>
/// Profile for mapping between SaleRecord entity and GetSaleRecordResponse
/// </summary>
public class GetSaleRecordProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetSaleRecord operation
    /// </summary>
    public GetSaleRecordProfile()
    {
        CreateMap<SaleRecord, GetSaleRecordResult>();
        CreateMap<GetSaleRecordResult, GetSaleRecordResponse>();

    }
}

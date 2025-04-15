using AutoMapper;
using Application.SaleRecords.CreateSaleRecord;
using WebApi.Features.SaleRecords.CreateSaleRecord;

namespace WebApi.Features.SaleRecord.CreateSaleRecord;

/// <summary>
/// Profile for mapping between Application and API CreateSaleRecord responses
/// </summary>
public class CreateSaleRecordProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateSaleRecord feature
    /// </summary>
    public CreateSaleRecordProfile()
    {
        CreateMap<CreateSaleRecordRequest, CreateSaleRecordCommand>();
        CreateMap<CreateSaleRecordResult, CreateSaleRecordResponse>();
    }
}

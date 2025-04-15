using Application.SaleRecords.CreateSaleRecord;
using WebApi.Features.SaleRecord.CreateSaleRecord;
using AutoMapper;

namespace WebApi.Mappings;

public class CreateSaleRecordRequestProfile : Profile
{
    public CreateSaleRecordRequestProfile()
    {
        CreateMap<CreateSaleRecordRequest, CreateSaleRecordCommand>();
    }
}
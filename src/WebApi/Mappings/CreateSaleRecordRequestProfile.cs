using Application.SaleRecords.CreateSaleRecord;
using WebApi.Features.SaleRecord.CreateSaleRecord;
using AutoMapper;
using Domain.Entities;

namespace WebApi.Mappings;

public class CreateSaleRecordRequestProfile : Profile
{
    public CreateSaleRecordRequestProfile()
    {
        CreateMap<CreateSaleRecordRequest, CreateSaleRecordCommand>();
        CreateMap<Features.SaleRecord.CreateSaleRecord.CreateSaleRecordCartRequest, Cart>();

    }
}
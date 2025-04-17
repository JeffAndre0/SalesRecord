using Application.Features.SaleRecords.CreateSaleRecord;
using AutoMapper;
using Domain.Entities;

namespace Application.SaleRecords.CreateSaleRecord;

/// <summary>
/// Profile for mapping between SaleRecord entity and CreateSaleRecordResponse
/// </summary>
public class CreateSaleRecordProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateSaleRecord operation
    /// </summary>
    public CreateSaleRecordProfile()
    {

        CreateMap<SaleRecord, CreateSaleRecordResult>();
        CreateMap<Cart, CreateCartResult>();
        CreateMap<CreateSaleRecordCommand, SaleRecord>();

        CreateMap<CreateCartResult, CreateCartResult>();
        CreateMap<CreateSaleRecordResult, CreateSaleRecordResponse>();
        CreateMap<CreateCartResult, CreateCartResponse>();
        CreateMap<SaleRecord, CreateSaleRecordResponse>()
        .ForMember(dest => dest.Cart, opt => opt.MapFrom(src => src.Cart));

    }
}

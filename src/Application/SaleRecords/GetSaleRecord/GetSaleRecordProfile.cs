using Application.Features.SaleRecords.CreateSaleRecord;
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
        CreateMap<GetSaleRecordResult, GetSaleRecordResponse>();
        CreateMap<SaleRecord, CreateSaleRecordResponse>()
        .ForMember(dest => dest.Cart, opt => opt.MapFrom(src => src.Cart));

        CreateMap<Cart, CartItemResponse>();
        CreateMap<SaleRecord, GetSaleRecordResult>()
            .ForMember(dest => dest.Cart, opt => opt.MapFrom(src => src.Cart));

        CreateMap<GetSaleRecordResult, GetSaleRecordResponse>()
            .ForMember(dest => dest.Cart, opt => opt.MapFrom(src => src.Cart));

            
    }
}

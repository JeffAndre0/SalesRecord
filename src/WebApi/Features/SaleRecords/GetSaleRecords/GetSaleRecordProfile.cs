using Application.SaleRecords.GetSaleRecord;
using AutoMapper;
using Domain.Entities;

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
        CreateMap<Guid, GetSaleRecordCommand>()
            .ConstructUsing(id => new GetSaleRecordCommand(id));
        CreateMap<GetSaleRecordResult, GetSaleRecordResponse>();
        CreateMap<Cart, CartItemResponse>();

        CreateMap<GetSaleRecordResult, GetSaleRecordResponse>()
            .ForMember(dest => dest.Cart, opt => opt.MapFrom(src => src.Cart));
    }
}

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
        // CreateMap<CreateSaleRecordCommand, SaleRecord>();
        // CreateMap<SaleRecord, CreateSaleRecordResult>();

        // CreateMap<Cart, CreateCartResult>();
        

        CreateMap<SaleRecord, CreateSaleRecordResult>();
        CreateMap<Cart, CreateCartResult>();
        CreateMap<CreateSaleRecordCommand, SaleRecord>();

        CreateMap<CreateCartResult, CreateCartResult>();
        CreateMap<CreateSaleRecordResult, CreateSaleRecordResponse>();
        CreateMap<CreateCartResult, CreateCartResponse>();
    }
}

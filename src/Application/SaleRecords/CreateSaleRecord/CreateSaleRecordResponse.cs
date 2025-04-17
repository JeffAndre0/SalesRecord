using Domain.Entities;
using Domain.Enums;

namespace Application.Features.SaleRecords.CreateSaleRecord;

/// <summary>
/// API response model for CreateSaleRecord operation
/// </summary>
public class CreateSaleRecordResponse
{
    public Guid Id { get; set; }

    public int SaleNumber { get; set;} = 0;

    public DateTime SaleDate { get; set; }

    public int CustomerId { get; set; }

    public string Branch { get; set; } = string.Empty;

    public List<CreateCartResponse> Cart { get; set; } = new();

    public SaleStatus Status { get; set; } = SaleStatus.Active;

}

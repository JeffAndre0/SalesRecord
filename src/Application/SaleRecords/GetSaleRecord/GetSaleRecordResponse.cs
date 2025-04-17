using Domain.Entities;
using Domain.Enums;

namespace Application.SaleRecords.GetSaleRecord;

/// <summary>
/// API response model for GetSaleRecord operation
/// </summary>
public class GetSaleRecordResponse
{
    
    public Guid Id { get; set; }

    public int SaleNumber { get; set;} = 0;

    public DateTime SaleDate { get; set; }

    public int CustomerId { get; set; }

    public string Branch { get; set; } = string.Empty;

    public List<Cart> Cart { get; set; } = new();

    public SaleStatus Status { get; set; } = SaleStatus.Active;

}

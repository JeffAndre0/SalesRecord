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

    public Cart Cart { get; set; } = new Cart();

    public SaleStatus Status { get; set; } = SaleStatus.Active;

}

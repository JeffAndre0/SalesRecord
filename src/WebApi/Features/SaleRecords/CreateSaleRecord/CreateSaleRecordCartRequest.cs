namespace WebApi.Features.SaleRecord.CreateSaleRecord;

/// <summary>
/// Represents a request to create a new user in the system.
/// </summary>
public class CreateSaleRecordCartRequest
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnityPrice { get; set; }
}
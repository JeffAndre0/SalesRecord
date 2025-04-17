namespace Application.Features.SaleRecords.CreateSaleRecord;

/// <summary>
/// Represents a single cart item in the CreateSaleRecord response.
/// </summary>
public class CreateCartResponse
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnityPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalAmount { get; set; }
}

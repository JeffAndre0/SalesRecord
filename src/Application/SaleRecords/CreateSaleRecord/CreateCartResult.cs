using Domain.Entities;
using Domain.Enums;

namespace Application.SaleRecords.CreateSaleRecord;

/// <summary>
/// Represents the response returned after successfully creating a new Sale.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the newly created Sale,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class CreateCartResult
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnityPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalAmount { get; set; }

}

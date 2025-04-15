using Domain.Common;

namespace Domain.Entities;


/// <summary>
/// Faker class for CartProduct
/// </summary>
public class CartProduct : BaseEntity
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnityPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalAmount { get; set; }
}
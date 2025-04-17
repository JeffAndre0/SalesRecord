using System.Text.Json.Serialization;
using Domain.Common;

namespace Domain.Entities;


/// <summary>
/// Faker class for Cart
/// </summary>
public class Cart : BaseEntity
{
    public Guid Id { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnityPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalAmount { get; set; }
    public Guid SaleRecordId { get; set; }
    [JsonIgnore]
    public SaleRecord SaleRecord { get; set; }

}
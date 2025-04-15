using Domain.Common;

namespace Domain.Entities;


/// <summary>
/// Faker class for Cart
/// </summary>
public class Cart : BaseEntity
{
    public int Id { get; set; }
    public List<CartProduct> Products { get; set; }
}
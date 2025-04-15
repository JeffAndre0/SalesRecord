using Common.Validation;
using Domain.Common;
using Domain.Enums;
using Domain.Validation;

namespace Domain.Entities;


/// <summary>
/// Faker Classe for Product
/// </summary>
public class Product : BaseEntity
{
    public int Id { get; set; }
    public decimal Price { get; set; }
}
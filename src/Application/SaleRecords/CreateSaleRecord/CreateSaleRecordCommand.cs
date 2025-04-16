using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.SaleRecords.CreateSaleRecord;

/// <summary>
/// Command for creating a new salerecord.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for creating a salerecord, 
/// including salerecordname, password, phone number, email, status, and role. 
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
/// that returns a <see cref="CreateSaleRecordResult"/>.
/// 
/// The data provided in this command is validated using the 
/// <see cref="CreateSaleRecordCommandValidator"/> which extends 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class CreateSaleRecordCommand : IRequest<CreateSaleRecordResult>
{
    
    public int SaleNumber { get; set;} = 0;


    /// <summary>
    /// Gets the date and time when the sale was made.
    /// </summary>
    public DateTime SaleDate { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Gets the salerecord's phone number.
    /// Must be a valid phone number format following the pattern (XX) XXXXX-XXXX.
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// Gets the hashed password for authentication.
    /// Password must meet security requirements: minimum 8 characters, at least one uppercase letter,
    /// one lowercase letter, one number, and one special character.
    /// </summary>
    public string Branch { get; set; } = string.Empty;

    /// <summary>
    /// Gets the salerecord's role in the system.
    /// Determines the salerecord's permissions and access levels.
    /// </summary>
    public List<Cart> Cart { get; set; }

    /// <summary>
    /// Gets the date and time when the salerecord was created.
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Gets the date and time of the last update to the salerecord's information.
    /// </summary>
    public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;

    public SaleStatus Status { get; set; } = SaleStatus.Active;
    public decimal TotalAmount { get; set; }

}
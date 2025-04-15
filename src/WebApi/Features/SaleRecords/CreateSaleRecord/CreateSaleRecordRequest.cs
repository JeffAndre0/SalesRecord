using Domain.Entities;
using Domain.Enums;

namespace WebApi.Features.SaleRecord.CreateSaleRecord;

/// <summary>
/// Represents a request to create a new user in the system.
/// </summary>
public class CreateSaleRecordRequest
{
    /// <summary>
    /// Gets the Sale number.
    /// Must not be null or empty.
    /// </summary>
    public int SaleNumber { get; set;} = 0;


    /// <summary>
    /// Gets the date and time when the sale was made.
    /// </summary>
    public DateTime SaleDate { get; set; }

    /// <summary>
    /// Gets the user's phone number.
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
    /// Gets the user's role in the system.
    /// Determines the user's permissions and access levels.
    /// </summary>
    public Cart Cart { get; set; } = new Cart();

    public SaleStatus Status { get; set; } = SaleStatus.Active;
}
using Common.Security;
using Common.Validation;
using Domain.Common;
using Domain.Enums;
using Domain.Validation;

namespace Domain.Entities;


/// <summary>
/// Represents a user in the system with authentication and profile information.
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class SaleRecord : BaseEntity, ISaleRecord
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

    /// <summary>
    /// Gets the date and time when the user was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets the date and time of the last update to the user's information.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    public SaleStatus Status { get; set; } = SaleStatus.Active;

    /// <summary>
    /// Gets the unique identifier of the user.
    /// </summary>
    /// <returns>The user's ID as a string.</returns>
    string ISaleRecord.Id => Id.ToString();

    /// <summary>
    /// Gets the username.
    /// </summary>
    /// <returns>The username.</returns>
    // string ISaleRecord.Sa => Username;
    int ISaleRecord.SaleNumber => SaleNumber;


    public DateTime Date => throw new NotImplementedException();

    /// <summary>
    /// Initializes a new instance of the User class.
    /// </summary>
    public SaleRecord()
    {
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Performs validation of the user entity using the UserValidator rules.
    /// </summary>
    /// <returns>
    /// A <see cref="ValidationResultDetail"/> containing:
    /// - IsValid: Indicates whether all validation rules passed
    /// - Errors: Collection of validation errors if any rules failed
    /// </returns>
    /// <remarks>
    /// <listheader>The validation includes checking:</listheader>
    /// <list type="bullet">Username format and length</list>
    /// <list type="bullet">Email format</list>
    /// <list type="bullet">Phone number format</list>
    /// <list type="bullet">Password complexity requirements</list>
    /// <list type="bullet">Role validity</list>
    /// 
    /// </remarks>
    public ValidationResultDetail Validate()
    {
        var validator = new SaleValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }

    /// <summary>
    /// Activates the user account.
    /// Changes the user's status to Active.
    /// </summary>
    public void Activate()
    {
        Status = SaleStatus.Active;
        UpdatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Deactivates the user account.
    /// Changes the user's status to Inactive.
    /// </summary>
    public void Deactivate()
    {
        Status = SaleStatus.Canceled;
        UpdatedAt = DateTime.UtcNow;
    }

}
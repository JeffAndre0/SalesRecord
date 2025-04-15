namespace WebApi.Features.SaleRecords.GetSaleRecord;

/// <summary>
/// Request model for getting a user by ID
/// </summary>
public class GetSaleRecordRequest
{
    /// <summary>
    /// The unique identifier of the user to retrieve
    /// </summary>
    public Guid Id { get; set; }
}

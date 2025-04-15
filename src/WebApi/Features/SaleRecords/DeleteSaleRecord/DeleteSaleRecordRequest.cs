namespace WebApi.Features.SaleRecords.DeleteSaleRecord;

/// <summary>
/// Request model for deleting a user
/// </summary>
public class DeleteSaleRecordRequest
{
    /// <summary>
    /// The unique identifier of the user to delete
    /// </summary>
    public Guid Id { get; set; }
}

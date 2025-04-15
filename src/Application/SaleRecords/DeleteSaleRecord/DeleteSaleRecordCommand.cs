using MediatR;

namespace Application.SaleRecords.DeleteSaleRecord;

/// <summary>
/// Command for deleting a user
/// </summary>
public record DeleteSaleRecordCommand : IRequest<DeleteSaleRecordResponse>
{
    /// <summary>
    /// The unique identifier of the user to delete
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of DeleteSaleRecordCommand
    /// </summary>
    /// <param name="id">The ID of the user to delete</param>
    public DeleteSaleRecordCommand(Guid id)
    {
        Id = id;
    }
}

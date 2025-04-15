using MediatR;

namespace Application.SaleRecords.GetSaleRecord;

/// <summary>
/// Command for retrieving a user by their ID
/// </summary>
public record GetSaleRecordCommand : IRequest<GetSaleRecordResult>
{
    /// <summary>
    /// The unique identifier of the user to retrieve
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of GetSaleRecordCommand
    /// </summary>
    /// <param name="id">The ID of the user to retrieve</param>
    public GetSaleRecordCommand(Guid id)
    {
        Id = id;
    }
}

using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ORM.Repositories;

/// <summary>
/// Implementation of ISaleRecordRepository using Entity Framework Core
/// </summary>
public class SaleRecordRepository : ISaleRecordRepository
{
    private readonly DefaultContext _context;

    /// <summary>
    /// Initializes a new instance of SaleRecordRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public SaleRecordRepository(DefaultContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Creates a new salerecord in the database
    /// </summary>
    /// <param name="salerecord">The salerecord to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created salerecord</returns>
    public async Task<SaleRecord> CreateAsync(SaleRecord salerecord, CancellationToken cancellationToken = default)
    {
        await _context.SaleRecords.AddAsync(salerecord, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return salerecord;
    }

    /// <summary>
    /// Retrieves a salerecord by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the salerecord</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The salerecord if found, null otherwise</returns>
    public async Task<SaleRecord?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.SaleRecords.FirstOrDefaultAsync(o=> o.Id == id, cancellationToken);
    }

    /// <summary>
    /// Retrieves a salerecord by their email address
    /// </summary>
    /// <param name="customerId">The customerId to search for</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The salerecord if found, null otherwise</returns>
    public async Task<List<SaleRecord>?> GetByCustomerIdAsync(int customerId, CancellationToken cancellationToken = default)
    {
        return await _context.SaleRecords
            .Where(u => u.CustomerId == customerId)
            .ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Deletes a salerecord from the database
    /// </summary>
    /// <param name="id">The unique identifier of the salerecord to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the salerecord was deleted, false if not found</returns>
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var salerecord = await GetByIdAsync(id, cancellationToken);
        if (salerecord == null)
            return false;

        _context.SaleRecords.Remove(salerecord);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}

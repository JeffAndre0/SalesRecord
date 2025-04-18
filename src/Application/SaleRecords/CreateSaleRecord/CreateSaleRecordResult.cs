﻿using Domain.Entities;
using Domain.Enums;

namespace Application.SaleRecords.CreateSaleRecord;

/// <summary>
/// Represents the response returned after successfully creating a new Sale.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the newly created Sale,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class CreateSaleRecordResult
{
    public Guid Id { get; set; }
    public int CustomerId { get; set; }
    public string Branch { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public List<CreateCartResult> Cart { get; set; } = new();
    public int SaleNumber { get; set; }

}

using Application.SaleRecords.CreateSaleRecord;
using Domain.Enums;
using Bogus;

namespace Unit.Domain;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class CreateSaleRecordHandlerTestData
{
    /// <summary>
    /// Configures the Faker to generate valid SaleRecord entities.
    /// The generated salerecords will have valid:
    /// - SaleRecordname (using internet salerecordnames)
    /// - Password (meeting complexity requirements)
    /// - Email (valid format)
    /// - Phone (Brazilian format)
    /// - Status (Active or Suspended)
    /// - Role (Customer or Admin)
    /// </summary>
    private static readonly Faker<CreateSaleRecordCommand> createSaleRecordHandlerFaker = new Faker<CreateSaleRecordCommand>()
        .RuleFor(u => u.SaleNumber, f => f.Random.Number(1,99999))
        .RuleFor(u => u.CustomerId, f => f.Random.Number(1, 9999))
        .RuleFor(u => u.Branch, f => f.Internet.Email())
        .RuleFor(u => u.Status, f => f.PickRandom(SaleStatus.Active, SaleStatus.Canceled));

    /// <summary>
    /// Generates a valid SaleRecord entity with randomized data.
    /// The generated salerecord will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid SaleRecord entity with randomly generated data.</returns>
    public static CreateSaleRecordCommand GenerateValidCommand()
    {
        return createSaleRecordHandlerFaker.Generate();
    }
}

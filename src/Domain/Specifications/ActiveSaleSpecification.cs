using Domain.Entities;
using Domain.Enums;

namespace Domain.Specifications;

public class ActiveSaleSpecification : ISpecification<SaleRecord>
{
    public bool IsSatisfiedBy(SaleRecord sale)
    {
        return sale.Status == SaleStatus.Active;
    }
}

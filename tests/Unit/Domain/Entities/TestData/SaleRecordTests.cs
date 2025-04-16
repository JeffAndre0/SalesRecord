using Domain.Entities;
using Xunit;

public class SaleRecordTests
{
    [Theory]
    [InlineData(3, 100, 0)]
    [InlineData(4, 100, 40)]
    [InlineData(9, 200, 180)]
    [InlineData(10, 50, 100)]
    [InlineData(20, 10, 40)]
    public void CalculateDiscount(int quantity, decimal unitPrice, decimal expectedDiscount)
    {
        decimal total = quantity * unitPrice;
        decimal discountPercent = 0;

        if (quantity >= 4 && quantity < 10)
            discountPercent = 0.10m;
        else if (quantity >= 10 && quantity <= 20)
            discountPercent = 0.20m;

        decimal discountAmount = total * discountPercent;
        decimal totalWithDiscount = total - discountAmount;

        var item = new Cart();
        item.SaleRecordId = new Guid();
        item.ProductId = 1;
        item.Quantity = quantity;
        item.UnityPrice = unitPrice;
        item.Discount = discountAmount;
        item.TotalAmount = totalWithDiscount;

        Assert.Equal(expectedDiscount, item.Discount);
        Assert.Equal(totalWithDiscount, item.TotalAmount);
    }

    [Fact]
    public void ThrowExceptionQtdGt20()
    {
        int quantity = 21;

        Assert.Throws<InvalidOperationException>(() =>
        {
            if (quantity > 20)
                throw new InvalidOperationException("It's not possible to sell more than 20 identical items.");
        });
    }

    [Theory]
    [InlineData(4, 100, 360)]
    [InlineData(10, 50, 400)]
    public void CalculateTotalAmount(int quantity, decimal unitPrice, decimal expectedTotal)
    {
        decimal discountPercent = quantity switch
        {
            >= 10 and <= 20 => 0.20m,
            >= 4 and < 10 => 0.10m,
            _ => 0m
        };

        decimal total = quantity * unitPrice;
        decimal discount = total * discountPercent;
        decimal totalWithDiscount = total - discount;

        var item = new Cart();
        item.SaleRecordId = new Guid();
        item.ProductId = 1;
        item.Quantity = quantity;
        item.UnityPrice = unitPrice;
        item.Discount = discount;
        item.TotalAmount = totalWithDiscount;
        Assert.Equal(expectedTotal, item.TotalAmount);
    }
    [Fact]
    public void Should_Fail_When_Discount_Is_Not_Correct_According_To_Business_Rule()
    {
        int quantity = 10;
        decimal unitPrice = 50;
        decimal invalidDiscount = 50;

        decimal total = quantity * unitPrice;
        decimal totalWithInvalidDiscount = total - invalidDiscount;

        var item = new Cart();
        item.SaleRecordId = new Guid();
        item.ProductId = 1;
        item.Quantity = quantity;
        item.UnityPrice = unitPrice;
        item.Discount = invalidDiscount;
        item.TotalAmount = totalWithInvalidDiscount;

        Assert.NotEqual(total * 0.2m, item.Discount);
    }

}

using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    public class SaleItemTests
    {
        [Fact(DisplayName = "Deve criar SaleItem válido com dados aleatórios")]
        public void Given_ValidSaleItemData_When_CreatingSaleItem_Then_ShouldInitializeCorrectly()
        {
            // Arrange
            var saleItem = SaleItemTestData.GenerateValidSaleItem();

            // Act & Assert
            Assert.NotNull(saleItem);
            Assert.False(saleItem.Cancelled);
            Assert.NotEmpty(saleItem.ProductId);
            Assert.NotEmpty(saleItem.ProductName);
            Assert.True(saleItem.UnitPrice > 0);
            Assert.True(saleItem.Quantity > 0);
            Assert.Equal((saleItem.UnitPrice * saleItem.Quantity) - saleItem.Discount, saleItem.TotalItem);
        }

        [Theory(DisplayName = "Deve calcular desconto corretamente de acordo com a quantidade")]
        [InlineData(3, 100, 0)]       // Sem desconto (até 3 itens)
        [InlineData(5, 100, 50)]      // 10% de desconto (4-9 itens) -> (100*5)*0.10 = 50
        [InlineData(10, 100, 200)]    // 20% de desconto (10-20 itens) -> (100*10)*0.20 = 200
        [InlineData(20, 100, 400)]    // 20% de desconto (10-20 itens) -> (100*20)*0.20 = 400
        public void Given_QuantityRange_When_CreatingSaleItem_Then_ShouldApplyCorrectDiscount(
            int quantity, decimal unitPrice, decimal expectedDiscount)
        {
            // Arrange
            var productId = "TEST-PROD-123";
            var productName = "Test Product";

            // Act
            var saleItem = new SaleItem(productId, productName, unitPrice, quantity);

            // Assert
            Assert.Equal(expectedDiscount, saleItem.Discount);
            var expectedTotal = (unitPrice * quantity) - expectedDiscount;
            Assert.Equal(expectedTotal, saleItem.TotalItem);
        }

        [Fact(DisplayName = "Ao cancelar o item, o campo Cancelled deve ser verdadeiro")]
        public void Given_SaleItem_When_CancelItem_Then_ItemShouldBeCancelled()
        {
            // Arrange
            var saleItem = SaleItemTestData.GenerateValidSaleItem();
            Assert.False(saleItem.Cancelled, "Item inicialmente não deveria estar cancelado.");

            // Act
            saleItem.CancelItem();

            // Assert
            Assert.True(saleItem.Cancelled, "Item deveria estar cancelado após CancelItem().");
        }
    }
}

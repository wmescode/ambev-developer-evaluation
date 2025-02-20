using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    public class SaleTests
    {
        [Fact(DisplayName = "Deve criar uma venda válida com dados gerados aleatoriamente")]
        public void Given_ValidSaleData_When_CreatingSale_Then_SaleShouldBeValid()
        {
            // Arrange
            var sale = SaleTestData.GenerateValidSale();

            // Act & Assert
            Assert.NotNull(sale);
            Assert.False(sale.Cancelled);
            Assert.NotEmpty(sale.CustomerId);
            Assert.NotEmpty(sale.CustomerName);
            Assert.NotEmpty(sale.BranchId);
            Assert.NotEmpty(sale.BranchName);
            Assert.Empty(sale.Items);       // Não adicionamos itens ainda
            Assert.Equal(0, sale.TotalAmount);
        }

        [Fact(DisplayName = "Ao adicionar item, deve atualizar a lista de itens e o valor total da venda")]
        public void Given_Sale_When_AddItemIsCalled_Then_ItemShouldBeAddedAndTotalShouldUpdate()
        {
            // Arrange
            var sale = SaleTestData.GenerateValidSale();
            var item = SaleItemTestData.GenerateValidSaleItem();
            var initialItemCount = sale.Items.Count;
            var initialTotal = sale.TotalAmount;

            // Act
            sale.AddItem(item.ProductId, item.ProductName, item.UnitPrice, item.Quantity);

            // Assert
            Assert.Equal(initialItemCount + 1, sale.Items.Count);
            Assert.Equal(initialTotal + item.TotalItem, sale.TotalAmount);
        }

        [Fact(DisplayName = "Não deve permitir vender mais de 20 itens idênticos em uma mesma Sale")]
        public void Given_Sale_When_AddingMoreThan20SameItems_Then_ShouldThrowException()
        {
            // Arrange
            var sale = SaleTestData.GenerateValidSale();
            var item = SaleItemTestData.GenerateSaleItemAboveLimit();

            // Primeiro vamos adicionar 20 itens iguais (em várias chamadas ou em uma só, a critério):
            for (int i = 0; i < 20; i++)
            {
                sale.AddItem(item.ProductId, item.ProductName, item.UnitPrice, 1);
            }

            // Act & Assert
            // Tentar adicionar o 21º item idêntico deve lançar exceção
            var ex = Assert.Throws<InvalidOperationException>(() =>
                sale.AddItem(item.ProductId, item.ProductName, item.UnitPrice, 1)
            );
            Assert.Equal("Não é possível vender mais de 20 itens idênticos.", ex.Message);
        }

        [Fact(DisplayName = "Ao cancelar a venda, deve marcar a venda e todos os itens como cancelados")]
        public void Given_SaleWithItems_When_CancelSale_Then_SaleAndItemsShouldBeCancelled()
        {
            // Arrange
            var sale = SaleTestData.GenerateValidSale();
            var item1 = SaleItemTestData.GenerateValidSaleItem();
            var item2 = SaleItemTestData.GenerateValidSaleItem();
            sale.AddItem(item1.ProductId, item1.ProductName, item1.UnitPrice, item1.Quantity);
            sale.AddItem(item2.ProductId, item2.ProductName, item2.UnitPrice, item2.Quantity);

            // Act
            sale.CancelSale();

            // Assert
            Assert.True(sale.Cancelled, "A venda deve estar cancelada.");
            foreach (var i in sale.Items)
            {
                Assert.True(i.Cancelled, "Todos os itens da venda devem estar cancelados.");
            }
        }

        [Fact(DisplayName = "Ao cancelar um item específico, somente aquele item deve ser cancelado")]
        public void Given_SaleWithMultipleItems_When_CancelItem_Then_OnlyThatItemShouldBeCancelled()
        {
            // Arrange
            var sale = SaleTestData.GenerateValidSale();

            // Não vamos mais usar item1 e item2 antes. Chamamos o método que retorna a instância real.
            var item1 = sale.AddItem("PROD-001", "Produto 1", 100m, 2);
            var item2 = sale.AddItem("PROD-002", "Produto 2", 50m, 1);

            // Act
            sale.CancelItem(item1.Id);

            // Assert
            var cancelledItem = sale.Items.FirstOrDefault(i => i.Id == item1.Id);
            var notCancelledItem = sale.Items.FirstOrDefault(i => i.Id == item2.Id);

            Assert.NotNull(cancelledItem);
            Assert.NotNull(notCancelledItem);

            Assert.True(cancelledItem.Cancelled, "O item 1 deve estar cancelado.");
            Assert.False(notCancelledItem.Cancelled, "O item 2 não deve estar cancelado.");
        }
    }
}

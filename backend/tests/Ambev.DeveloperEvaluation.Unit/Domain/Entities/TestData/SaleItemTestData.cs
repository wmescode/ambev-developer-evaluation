using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData
{
    /// <summary>
    /// Classe responsável por gerar dados de teste para a entidade SaleItem.
    /// </summary>
    public static class SaleItemTestData
    {
        private static readonly Faker Faker = new Faker("pt_BR");

        private static readonly Faker<SaleItem> SaleItemFaker = new Faker<SaleItem>()
            .CustomInstantiator(f => new SaleItem(
                productId: f.Commerce.Ean13(),               // ou f.Random.Guid().ToString()
                productName: f.Commerce.ProductName(),
                unitPrice: f.Finance.Amount(1, 500),         // valor entre 1 e 500
                quantity: f.Random.Int(1, 25)                // quantidade de 1 a 25
            ));

        /// <summary>
        /// Gera um SaleItem válido com dados aleatórios.
        /// </summary>
        public static SaleItem GenerateValidSaleItem()
        {
            return SaleItemFaker.Generate();
        }

        /// <summary>
        /// Gera um SaleItem com quantidade acima de 20, para testar validações de limite.
        /// </summary>
        public static SaleItem GenerateSaleItemAboveLimit()
        {
            return new SaleItem(
                productId: Faker.Random.Guid().ToString(),
                productName: Faker.Commerce.ProductName(),
                unitPrice: Faker.Finance.Amount(1, 500),
                quantity: 21 // acima do limite de 20
            );
        }
    }
}

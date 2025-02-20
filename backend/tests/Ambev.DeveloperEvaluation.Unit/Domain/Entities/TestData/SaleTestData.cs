using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData
{
    /// <summary>
    /// Classe responsável por gerar dados de teste para a entidade Sale.
    /// </summary>
    public static class SaleTestData
    {
        private static readonly Faker Faker = new Faker("pt_BR");

        private static readonly Faker<Sale> SaleFaker = new Faker<Sale>()
            .CustomInstantiator(f => new Sale(
                saleDate: f.Date.Recent(30),        // Data recente nos últimos 30 dias
                customerId: f.Random.Guid().ToString(),
                customerName: f.Person.FullName,
                branchId: f.Random.Guid().ToString(),
                branchName: f.Company.CompanyName()
            ));

        /// <summary>
        /// Gera uma instância válida de Sale, com dados aleatórios.
        /// </summary>
        public static Sale GenerateValidSale()
        {
            return SaleFaker.Generate();
        }
    }
}

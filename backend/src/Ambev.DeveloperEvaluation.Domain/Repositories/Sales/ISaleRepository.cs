using Ambev.DeveloperEvaluation.Domain.Entities.Sales;

namespace Ambev.DeveloperEvaluation.Domain.Repositories.Sales
{
    public interface ISaleRepository
    {
        Task<Sale> CreateSaleAsync(Sale sale, CancellationToken cancellationToken = default);        
        Task<Sale?> GetSaleByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<bool> DeleteSaleAsync(Guid id, CancellationToken cancellationToken = default);
        Task<SaleItem> CreateSalesItemAsync(SaleItem saleItem, CancellationToken cancellationToken = default);
        Task<bool> DeleteSalesItemAsync<SaleItem>(Guid id, CancellationToken cancellationToken = default);
        Task<List<SaleItem>?> GetSaleItemsBySaleId(Guid saleId, CancellationToken cancellationToken = default);        
        IQueryable<Sale> Query();
    }
}
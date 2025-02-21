using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using Ambev.DeveloperEvaluation.Domain.Repositories.Sales;
using Ambev.DeveloperEvaluation.ORM.PostgreSQL;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.PostgreSQL.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly DefaultContext _context;
        public SaleRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<Sale> CreateSaleAsync(Sale sale, CancellationToken cancellationToken = default)
        {
            await _context.Sales.AddAsync(sale, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return sale;
        }

        public async Task<SaleItem> CreateSalesItemAsync(SaleItem saleItem, CancellationToken cancellationToken = default)
        {
            await _context.SaleItems.AddAsync(saleItem, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return saleItem;
        }

        public async Task<bool> DeleteSaleAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var sale = await _context.Sales.FindAsync(id);
            if (sale == null)
                return false;

            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> DeleteSalesItemAsync<SaleItem>(Guid id, CancellationToken cancellationToken = default)
        {
            var saleItem = await _context.SaleItems.FindAsync(id, cancellationToken);
            if (saleItem == null)
                return false;

            _context.SaleItems.Remove(saleItem);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<Sale?> GetSaleByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Sales.Include(a => a.Items).FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
        }

        public async Task<List<SaleItem>?> GetSaleItemsBySaleId(Guid saleId, CancellationToken cancellationToken = default)
        {
            return await _context.SaleItems.Where(a => a.SaleId == saleId).ToListAsync(cancellationToken);
        }

        public IQueryable<Sale> Query()
        {
            return _context.Sales
                .Include(a => a.Items)
                .AsNoTracking();
        }
    }
}

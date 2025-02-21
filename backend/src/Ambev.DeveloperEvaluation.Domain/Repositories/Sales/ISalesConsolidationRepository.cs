using Ambev.DeveloperEvaluation.Domain.Entities.Sales;

namespace Ambev.DeveloperEvaluation.Domain.Repositories.Sales
{
    public interface ISalesConsolidationRepository
    {
        Task AddSalesConsolidationAsync(BranchSalesConsolidation branchSalesConsolidation);
    }
}

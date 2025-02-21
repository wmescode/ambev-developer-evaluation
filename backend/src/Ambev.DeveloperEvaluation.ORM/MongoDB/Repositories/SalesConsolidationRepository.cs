using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using Ambev.DeveloperEvaluation.Domain.Repositories.Sales;
using MongoDB.Driver;

namespace Ambev.DeveloperEvaluation.ORM.MongoDB.Repositories
{
    
    public class SalesConsolidationRepository : ISalesConsolidationRepository
    {
        private readonly IMongoCollection<BranchSalesConsolidation> _branchSalesConsolidation;
        public SalesConsolidationRepository(MongoDBService mongoDBService)
        {
            _branchSalesConsolidation = mongoDBService.Database.GetCollection<BranchSalesConsolidation>("BranchSalesConsolidation");
        }

        public async Task AddSalesConsolidationAsync(BranchSalesConsolidation branchSalesConsolidation)
        {
            await _branchSalesConsolidation.InsertOneAsync(branchSalesConsolidation);
        }
    }
}

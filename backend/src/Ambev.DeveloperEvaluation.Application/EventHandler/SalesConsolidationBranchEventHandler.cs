using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using Ambev.DeveloperEvaluation.Domain.Events.SaleEvents;
using Ambev.DeveloperEvaluation.Domain.Repositories.Sales;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.EventHandler
{
    public class SalesConsolidationBranchEventHandler : INotificationHandler<SaleCreatedEvent>
    {
        private readonly ISalesConsolidationRepository _salesConsolidationRepository;
        public SalesConsolidationBranchEventHandler(ISalesConsolidationRepository salesConsolidationRepository)
        {
            _salesConsolidationRepository = salesConsolidationRepository;
        }

        public async Task Handle(SaleCreatedEvent notification, CancellationToken cancellationToken)
        {
            var saleDate = notification.Sale.SaleDate;
            var branchName = notification.Sale.BranchName;
            var totalAmount = notification.Sale.TotalAmount;

            var newConsolidation = new BranchSalesConsolidation
            {
                BranchName = branchName,
                SaleDate = saleDate.Date, 
                TotalAmount = totalAmount                
            };
            await _salesConsolidationRepository.AddSalesConsolidationAsync(newConsolidation);
        }
    }
}

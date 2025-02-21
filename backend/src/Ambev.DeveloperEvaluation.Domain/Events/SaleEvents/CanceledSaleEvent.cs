using MediatR;

namespace Ambev.DeveloperEvaluation.Domain.Events.SaleEvents
{
    public class CanceledSaleEvent : INotification
    {
        public Guid Id { get; }

        public CanceledSaleEvent(Guid id)
        {
            Id = id;
        }
    }
}
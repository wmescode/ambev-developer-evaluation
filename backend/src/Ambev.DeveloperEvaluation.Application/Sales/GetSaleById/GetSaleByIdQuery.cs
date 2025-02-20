using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSaleById
{
    public class GetSaleByIdQuery : IRequest<GetSaleByIdResult>
    {
        public Guid SaleId { get; set; }
    }
}

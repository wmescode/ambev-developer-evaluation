using Ambev.DeveloperEvaluation.Domain.Repositories.Sales;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSaleById
{
    public class GetSaleByIdHandler : IRequestHandler<GetSaleByIdQuery, GetSaleByIdResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        public GetSaleByIdHandler(ISaleRepository saleRepository,
                                  IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        public async Task<GetSaleByIdResult> Handle(GetSaleByIdQuery request, CancellationToken cancellationToken)
        {
            var sale = await _saleRepository.GetSaleByIdAsync(request.SaleId, cancellationToken);

            if (sale == null)
            {
                throw new KeyNotFoundException($"Sale with id {request.SaleId} not found");
            }

            var result = _mapper.Map<GetSaleByIdResult>(sale);

            return result;
        }
    }
}

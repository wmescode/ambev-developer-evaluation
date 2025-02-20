using Ambev.DeveloperEvaluation.Application.Common;
using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using Ambev.DeveloperEvaluation.Domain.Repositories.Sales;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales
{
    public class GetAllSalesQueryHandler : IRequestHandler<GetAllSalesQuery, PaginatedList<GetAllSalesResult>>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        public GetAllSalesQueryHandler(ISaleRepository saleRepository,
                                                 IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedList<GetAllSalesResult>> Handle(GetAllSalesQuery request, CancellationToken cancellationToken)
        {
            var query = _saleRepository.Query();

            switch (request.SortBy?.ToLower())
            {
                case "saledate":
                    query = request.SortDesc
                        ? query.OrderByDescending(sale => sale.SaleDate)
                        : query.OrderBy(sale => sale.SaleDate);
                    break;
                case "totalamount":
                    query = request.SortDesc
                        ? query.OrderByDescending(sale => sale.TotalAmount)
                        : query.OrderBy(sale => sale.TotalAmount);
                    break;
                default:
                    query = request.SortDesc
                        ? query.OrderByDescending(sale => sale.SaleDate)
                        : query.OrderBy(sale => sale.SaleDate);
                    break;
            }

            if (!string.IsNullOrEmpty(request.SearchTerm))
            {
                var term = request.SearchTerm.ToLower();
                query = query.Where(sale =>
                    sale.CustomerName.ToLower().Contains(term) ||
                    sale.BranchName.ToLower().Contains(term) ||
                    sale.Id.ToString().ToLower().Contains(term));
            }

            var paginatedSales = await PaginatedList<Sale>.CreateAsync(
                query,
                request.PageNumber,
                request.PageSize
            );

            var mappedResult = _mapper.Map<List<GetAllSalesResult>>(paginatedSales);
            
            var result = new PaginatedList<GetAllSalesResult>(
                mappedResult,
                paginatedSales.TotalCount,
                paginatedSales.CurrentPage,
                paginatedSales.PageSize
            );

            return result;
        }
    }
}

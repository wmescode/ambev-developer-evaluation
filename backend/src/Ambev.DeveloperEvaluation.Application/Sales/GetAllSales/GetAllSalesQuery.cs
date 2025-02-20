using Ambev.DeveloperEvaluation.Application.Common;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales
{
    public class GetAllSalesQuery : IRequest<PaginatedList<GetAllSalesResult>>
    {
        /// <summary>
        /// Pagination parameters
        /// </summary>
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// Sort parameters
        /// SortBy ex: "date" ou "totalAmount"
        /// </summary>
        public string? SortBy { get; set; } 
        public bool SortDesc { get; set; }  
        
        /// <summary>
        /// Filter parameters
        /// </summary>
        public string? SearchTerm { get; set; } 
        
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}

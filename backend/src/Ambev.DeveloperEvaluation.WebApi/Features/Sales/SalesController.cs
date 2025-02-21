using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.GetAllSales;
using Ambev.DeveloperEvaluation.Application.Sales.GetSaleById;
using Ambev.DeveloperEvaluation.WebApi.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales
{
    public class SalesController : BaseController
    {
        private readonly IMediator _mediator;
        public SalesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST api/sales
        [HttpPost]
        public async Task<IActionResult> CreateSale([FromBody] CreateSaleCommand request, CancellationToken cancellationToken)
        {            
            var result = await _mediator.Send(request, cancellationToken);

            return Created(string.Empty, new ApiResponseWithData<CreateSaleResult>
            {
                Success = true,
                Message = "Sale created successfully",
                Data = result
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetSaleById([FromQuery] GetSaleByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);

            return Ok(new ApiResponseWithData<GetSaleByIdResult>
            {
                Success = true,
                Message = "Sale retrieved successfully",
                Data = result
            });
        }

        [HttpGet("paged")]
        public async Task<IActionResult> GetAllSales([FromQuery] GetAllSalesQuery request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);            

            return OkPaginated(result);
        }
    }
}

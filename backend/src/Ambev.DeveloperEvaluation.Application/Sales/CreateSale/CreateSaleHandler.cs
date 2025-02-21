using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using Ambev.DeveloperEvaluation.Domain.Events.SaleEvents;
using Ambev.DeveloperEvaluation.Domain.Repositories.Sales;
using Ambev.DeveloperEvaluation.Domain.Services.External;
using AutoMapper;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;
        private readonly IBranchExternalService _branchExternalService;
        private readonly ICustomerExternalService _customerExternalService;
        private readonly IProductExternalService _productExternalService;
        private readonly IMediator _mediator;


        public CreateSaleHandler(ISaleRepository saleRepository, 
                                 IMapper mapper,
                                 IBranchExternalService branchExternalService,
                                 ICustomerExternalService customerExternalService,
                                 IProductExternalService productExternalService,
                                 IMediator mediator)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
            _branchExternalService = branchExternalService;
            _customerExternalService = customerExternalService;
            _productExternalService = productExternalService;
            _mediator = mediator;
        }

        public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateSaleValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
            {                
                var errorMessages = validationResult.Errors
                    .Select(e => e.ErrorMessage)
                    .Aggregate((current, next) => current + "; " + next);
                
                throw new ValidationException(errorMessages);
            }
            
            var branch = _branchExternalService.GetBranchById(command.BranchId);                        
            var customer = _customerExternalService.GetCustomerById(command.CustomerId);

            var sale = new Sale(DateTime.UtcNow, customer.Id, customer.Name, branch.Id, branch.Name);

            foreach (var item in command.Items)
            {                                
                var product = _productExternalService.GetProductById(item.ProductId);                
                sale.AddItem(product.Id, product.Description, product.Price, item.Quantity);
            }

            var createdSale = await _saleRepository.CreateSaleAsync(sale, cancellationToken);

            await _mediator.Publish(new SaleCreatedEvent(createdSale), cancellationToken);

            var result = _mapper.Map<CreateSaleResult>(createdSale);
            return result;
        }
    }
}

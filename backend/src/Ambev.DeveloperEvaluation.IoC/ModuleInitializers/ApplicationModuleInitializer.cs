using Ambev.DeveloperEvaluation.Application.EventHandler;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Events.SaleEvents;
using Ambev.DeveloperEvaluation.Domain.Services.External;
using Ambev.DeveloperEvaluation.ExternalServices.Services;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Ambev.DeveloperEvaluation.IoC.ModuleInitializers;

public class ApplicationModuleInitializer : IModuleInitializer
{
    public void Initialize(WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IPasswordHasher, BCryptPasswordHasher>();
        builder.Services.AddSingleton<ICustomerExternalService, MockCustomerExternalService>();
        builder.Services.AddSingleton<IBranchExternalService, MockBranchExternalService>();
        builder.Services.AddSingleton<IProductExternalService, MockProductExternalService>();
        builder.Services.AddTransient<INotificationHandler<CanceledSaleEvent>, SaleCanceledEventHandler>();
        builder.Services.AddTransient<INotificationHandler<SaleCreatedEvent>, SalesConsolidationBranchEventHandler>();

    }
}
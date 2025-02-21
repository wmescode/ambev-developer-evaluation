using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Repositories.Sales;
using Ambev.DeveloperEvaluation.ORM.MongoDB;
using Ambev.DeveloperEvaluation.ORM.MongoDB.Repositories;
using Ambev.DeveloperEvaluation.ORM.PostgreSQL;
using Ambev.DeveloperEvaluation.ORM.PostgreSQL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Ambev.DeveloperEvaluation.IoC.ModuleInitializers;

public class InfrastructureModuleInitializer : IModuleInitializer
{
    public void Initialize(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<DbContext>(provider => provider.GetRequiredService<DefaultContext>());
        builder.Services.AddSingleton<MongoDBService>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<ISaleRepository, SaleRepository>();        
        builder.Services.AddScoped<ISalesConsolidationRepository, SalesConsolidationRepository>();
    }
}
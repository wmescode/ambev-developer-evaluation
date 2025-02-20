using Ambev.DeveloperEvaluation.Domain.Entities.External;

namespace Ambev.DeveloperEvaluation.Domain.Services.External
{
    public interface ICustomerExternalService
    {
        Customer GetCustomerById(string Id);
    }
}

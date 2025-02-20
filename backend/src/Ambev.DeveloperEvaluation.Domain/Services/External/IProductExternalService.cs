using Ambev.DeveloperEvaluation.Domain.Entities.External;

namespace Ambev.DeveloperEvaluation.Domain.Services.External
{
    public interface IProductExternalService
    {
        Product GetProductById(string Id);
    }
}

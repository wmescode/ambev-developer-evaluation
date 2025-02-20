using Ambev.DeveloperEvaluation.Domain.Entities.External;
using Ambev.DeveloperEvaluation.Domain.Services.External;
using Ambev.DeveloperEvaluation.ExternalServices.Mock;

namespace Ambev.DeveloperEvaluation.ExternalServices.Services
{
    public class MockProductExternalService : IProductExternalService
    {
        /// <summary>
        /// /// Simulates a call to an external service to get a Product by its Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public Product GetProductById(string Id)
        {
            try
            {
                var result = InMemoryDataStore.Products.First(x => x.Id == Id);
                return result;
            }
            catch (Exception ex)
            {
                throw new KeyNotFoundException($"Product with ID {Id} not found");
            }
        }
    }
}

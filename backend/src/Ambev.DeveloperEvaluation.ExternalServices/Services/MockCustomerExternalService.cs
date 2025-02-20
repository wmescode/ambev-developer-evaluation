using Ambev.DeveloperEvaluation.Domain.Entities.External;
using Ambev.DeveloperEvaluation.Domain.Services.External;
using Ambev.DeveloperEvaluation.ExternalServices.Mock;

namespace Ambev.DeveloperEvaluation.ExternalServices.Services
{
    public class MockCustomerExternalService : ICustomerExternalService
    {
        /// <summary>
        /// Simulate the call to an external service to get a customer by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public Customer GetCustomerById(string Id)
        {
            try            
            {
                var result = InMemoryDataStore.Customers.First(x => x.Id == Id);
                return result;
            }
            catch (Exception ex)
            {                
                throw new KeyNotFoundException($"Customer with ID {Id} not found");                
            }
        }
    }
}

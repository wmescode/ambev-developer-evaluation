using Ambev.DeveloperEvaluation.Domain.Entities.External;
using Ambev.DeveloperEvaluation.Domain.Services.External;
using Ambev.DeveloperEvaluation.ExternalServices.Mock;

namespace Ambev.DeveloperEvaluation.ExternalServices.Services
{
    public class MockBranchExternalService : IBranchExternalService
    {
        /// <summary>
        /// Simulates a call to an external service to get a branch by its Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public Branch GetBranchById(string Id)
        {
            try
            {
                var result = InMemoryDataStore.Branches.First(x => x.Id == Id);
                return result;
            }
            catch (Exception ex)
            {
                throw new KeyNotFoundException($"Branch with ID {Id} not found");
            }
        }
    }
}

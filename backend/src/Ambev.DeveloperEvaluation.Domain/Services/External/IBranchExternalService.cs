using Ambev.DeveloperEvaluation.Domain.Entities.External;

namespace Ambev.DeveloperEvaluation.Domain.Services.External
{
    public interface IBranchExternalService
    {
        Branch GetBranchById(string Id);
    }
}

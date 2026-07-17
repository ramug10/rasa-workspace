using RequirementsGrooming.Domain.Entities;

namespace RequirementsGrooming.Application.Contracts;

public interface IRequirementRepository
{
    Task<IReadOnlyList<Requirement>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Requirement?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task AddAsync(Requirement requirement, CancellationToken cancellationToken = default);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}

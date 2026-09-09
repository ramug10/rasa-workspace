using Microsoft.EntityFrameworkCore;
using RequirementsGrooming.Application.Contracts;
using RequirementsGrooming.Domain.Entities;
using RequirementsGrooming.Infrastructure.Data;

namespace RequirementsGrooming.Infrastructure.Repositories;

public class RequirementRepository : IRequirementRepository
{
    private readonly AppDbContext _dbContext;

    public RequirementRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<Requirement>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var requirements = await _dbContext.Requirements.ToListAsync(cancellationToken);
        return requirements.OrderByDescending(x => x.UpdatedAtUtc).ToList();
    }

    public Task<Requirement?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return _dbContext.Requirements.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task AddAsync(Requirement requirement, CancellationToken cancellationToken = default)
    {
        await _dbContext.Requirements.AddAsync(requirement, cancellationToken);
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}

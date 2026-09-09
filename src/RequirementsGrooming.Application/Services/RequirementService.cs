using RequirementsGrooming.Application.Contracts;
using RequirementsGrooming.Domain.Entities;
using RequirementsGrooming.Domain.Enums;

namespace RequirementsGrooming.Application.Services;

public class RequirementService
{
    private readonly IRequirementRepository _repository;

    public RequirementService(IRequirementRepository repository)
    {
        _repository = repository;
    }

    public Task<IReadOnlyList<Requirement>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return _repository.GetAllAsync(cancellationToken);
    }

    public Task<Requirement?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return _repository.GetByIdAsync(id, cancellationToken);
    }

    public async Task<Guid> CreateAsync(string projectName, string title, string businessGoal, string acceptanceCriteria, string priority, CancellationToken cancellationToken = default)
    {
        var requirement = new Requirement(projectName, title, businessGoal, acceptanceCriteria, priority);
        await _repository.AddAsync(requirement, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);
        return requirement.Id;
    }

    public async Task UpdateDraftAsync(Guid id, string title, string businessGoal, string acceptanceCriteria, string priority, CancellationToken cancellationToken = default)
    {
        var requirement = await RequireAsync(id, cancellationToken);
        requirement.UpdateDraft(title, businessGoal, acceptanceCriteria, priority);
        await _repository.SaveChangesAsync(cancellationToken);
    }

    public async Task SubmitForReviewAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var requirement = await RequireAsync(id, cancellationToken);
        requirement.SubmitForReview();
        await _repository.SaveChangesAsync(cancellationToken);
    }

    public async Task MarkGroomedAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var requirement = await RequireAsync(id, cancellationToken);
        requirement.MarkGroomed();
        await _repository.SaveChangesAsync(cancellationToken);
    }

    public async Task ApproveAsync(Guid id, string reason, CancellationToken cancellationToken = default)
    {
        var requirement = await RequireAsync(id, cancellationToken);
        requirement.Approve(reason);
        await _repository.SaveChangesAsync(cancellationToken);
    }

    public async Task RejectAsync(Guid id, string reason, CancellationToken cancellationToken = default)
    {
        var requirement = await RequireAsync(id, cancellationToken);
        requirement.Reject(reason);
        await _repository.SaveChangesAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Requirement>> GetApprovedAsync(CancellationToken cancellationToken = default)
    {
        var all = await _repository.GetAllAsync(cancellationToken);
        return all.Where(x => x.Status == RequirementStatus.Approved).ToList();
    }

    private async Task<Requirement> RequireAsync(Guid id, CancellationToken cancellationToken)
    {
        var requirement = await _repository.GetByIdAsync(id, cancellationToken);
        return requirement ?? throw new KeyNotFoundException($"Requirement {id} was not found.");
    }
}

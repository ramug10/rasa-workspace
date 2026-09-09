using RequirementsGrooming.Application.Contracts;
using RequirementsGrooming.Application.Services;
using RequirementsGrooming.Domain.Entities;
using RequirementsGrooming.Domain.Enums;

namespace RequirementsGrooming.Tests;

public class RequirementServiceTests
{
    [Fact]
    public async Task CreateAsync_Should_Add_Requirement()
    {
        var repo = new FakeRequirementRepository();
        var service = new RequirementService(repo);

        var id = await service.CreateAsync("Project A", "New Req", "Business goal", "AC1", "High");

        var item = await repo.GetByIdAsync(id);
        Assert.NotNull(item);
        Assert.Equal("New Req", item!.Title);
        Assert.Equal(RequirementStatus.Draft, item.Status);
    }

    [Fact]
    public async Task ApproveAsync_Should_Change_Status_To_Approved()
    {
        var repo = new FakeRequirementRepository();
        var service = new RequirementService(repo);

        var id = await service.CreateAsync("Project A", "New Req", "Business goal", "AC1", "High");
        await service.SubmitForReviewAsync(id);
        await service.MarkGroomedAsync(id);
        await service.ApproveAsync(id, "Ready for build");

        var item = await repo.GetByIdAsync(id);
        Assert.NotNull(item);
        Assert.Equal(RequirementStatus.Approved, item!.Status);
    }

    [Fact]
    public async Task UpdateDraftAsync_Should_Update_Fields_When_Draft()
    {
        var repo = new FakeRequirementRepository();
        var service = new RequirementService(repo);

        var id = await service.CreateAsync("Project A", "Old", "Old goal", "Old AC", "Low");
        await service.UpdateDraftAsync(id, "New", "New goal", "New AC", "High");

        var item = await repo.GetByIdAsync(id);
        Assert.NotNull(item);
        Assert.Equal("New", item!.Title);
        Assert.Equal("High", item.Priority);
    }

    [Fact]
    public async Task ApproveAsync_Should_Throw_When_Not_Groomed()
    {
        var repo = new FakeRequirementRepository();
        var service = new RequirementService(repo);

        var id = await service.CreateAsync("Project A", "Req", "Goal", "AC", "High");

        await Assert.ThrowsAsync<InvalidOperationException>(() => service.ApproveAsync(id, "Reason"));
    }

    [Fact]
    public async Task RejectAsync_Should_Throw_When_Draft()
    {
        var repo = new FakeRequirementRepository();
        var service = new RequirementService(repo);

        var id = await service.CreateAsync("Project A", "Req", "Goal", "AC", "High");

        await Assert.ThrowsAsync<InvalidOperationException>(() => service.RejectAsync(id, "Reason"));
    }

    private sealed class FakeRequirementRepository : IRequirementRepository
    {
        private readonly List<Requirement> _items = new();

        public Task<IReadOnlyList<Requirement>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult((IReadOnlyList<Requirement>)_items);
        }

        public Task<Requirement?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(_items.FirstOrDefault(x => x.Id == id));
        }

        public Task AddAsync(Requirement requirement, CancellationToken cancellationToken = default)
        {
            _items.Add(requirement);
            return Task.CompletedTask;
        }

        public Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }
}

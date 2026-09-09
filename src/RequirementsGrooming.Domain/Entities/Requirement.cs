using RequirementsGrooming.Domain.Enums;

namespace RequirementsGrooming.Domain.Entities;

public class Requirement
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string ProjectName { get; private set; } = string.Empty;
    public string Title { get; private set; } = string.Empty;
    public string BusinessGoal { get; private set; } = string.Empty;
    public string AcceptanceCriteria { get; private set; } = string.Empty;
    public string Priority { get; private set; } = "Medium";
    public RequirementStatus Status { get; private set; } = RequirementStatus.Draft;
    public string? DecisionReason { get; private set; }
    public DateTimeOffset CreatedAtUtc { get; private set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedAtUtc { get; private set; } = DateTimeOffset.UtcNow;

    private Requirement()
    {
    }

    public Requirement(string projectName, string title, string businessGoal, string acceptanceCriteria, string priority)
    {
        ProjectName = projectName.Trim();
        Title = title.Trim();
        BusinessGoal = businessGoal.Trim();
        AcceptanceCriteria = acceptanceCriteria.Trim();
        Priority = priority.Trim();
    }

    public void UpdateDraft(string title, string businessGoal, string acceptanceCriteria, string priority)
    {
        EnsureStatus(RequirementStatus.Draft);
        Title = title.Trim();
        BusinessGoal = businessGoal.Trim();
        AcceptanceCriteria = acceptanceCriteria.Trim();
        Priority = priority.Trim();
        UpdatedAtUtc = DateTimeOffset.UtcNow;
    }

    public void SubmitForReview()
    {
        EnsureStatus(RequirementStatus.Draft);
        Status = RequirementStatus.InReview;
        UpdatedAtUtc = DateTimeOffset.UtcNow;
    }

    public void MarkGroomed()
    {
        EnsureStatus(RequirementStatus.InReview);
        Status = RequirementStatus.Groomed;
        UpdatedAtUtc = DateTimeOffset.UtcNow;
    }

    public void Approve(string reason)
    {
        EnsureStatus(RequirementStatus.Groomed);
        if (string.IsNullOrWhiteSpace(reason))
        {
            throw new InvalidOperationException("Approval reason is required.");
        }

        Status = RequirementStatus.Approved;
        DecisionReason = reason.Trim();
        UpdatedAtUtc = DateTimeOffset.UtcNow;
    }

    public void Reject(string reason)
    {
        if (Status is not RequirementStatus.InReview and not RequirementStatus.Groomed)
        {
            throw new InvalidOperationException($"Invalid transition. Current status: {Status}. Expected: InReview or Groomed.");
        }

        if (string.IsNullOrWhiteSpace(reason))
        {
            throw new InvalidOperationException("Rejection reason is required.");
        }

        Status = RequirementStatus.Rejected;
        DecisionReason = reason.Trim();
        UpdatedAtUtc = DateTimeOffset.UtcNow;
    }

    private void EnsureStatus(RequirementStatus expected)
    {
        if (Status != expected)
        {
            throw new InvalidOperationException($"Invalid transition. Current status: {Status}. Expected: {expected}.");
        }
    }
}

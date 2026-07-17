using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RequirementsGrooming.Application.Services;
using RequirementsGrooming.Web.ViewModels;

namespace RequirementsGrooming.Web.Controllers;

[Authorize]
public class RequirementsController : Controller
{
    private readonly RequirementService _service;

    public RequirementsController(RequirementService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var requirements = await _service.GetAllAsync(cancellationToken);
        return View(requirements);
    }

    [HttpGet]
    [Authorize(Roles = "Stakeholder,ProductOwner")]
    public IActionResult Create()
    {
        return View(new CreateRequirementInputModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Stakeholder,ProductOwner")]
    public async Task<IActionResult> Create(CreateRequirementInputModel input, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return View(input);
        }

        var id = await _service.CreateAsync(
            input.ProjectName,
            input.Title,
            input.BusinessGoal,
            input.AcceptanceCriteria,
            input.Priority,
            cancellationToken);

        return RedirectToAction(nameof(Details), new { id });
    }

    [HttpGet]
    public async Task<IActionResult> Details(Guid id, CancellationToken cancellationToken)
    {
        var requirement = await _service.GetByIdAsync(id, cancellationToken);
        if (requirement is null)
        {
            return NotFound();
        }

        return View(requirement);
    }

    [HttpGet]
    [Authorize(Roles = "Stakeholder,ProductOwner")]
    public async Task<IActionResult> Edit(Guid id, CancellationToken cancellationToken)
    {
        var requirement = await _service.GetByIdAsync(id, cancellationToken);
        if (requirement is null)
        {
            return NotFound();
        }

        var model = new CreateRequirementInputModel
        {
            ProjectName = requirement.ProjectName,
            Title = requirement.Title,
            BusinessGoal = requirement.BusinessGoal,
            AcceptanceCriteria = requirement.AcceptanceCriteria,
            Priority = requirement.Priority
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Stakeholder,ProductOwner")]
    public async Task<IActionResult> Edit(Guid id, CreateRequirementInputModel input, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return View(input);
        }

        await _service.UpdateDraftAsync(
            id,
            input.Title,
            input.BusinessGoal,
            input.AcceptanceCriteria,
            input.Priority,
            cancellationToken);

        return RedirectToAction(nameof(Details), new { id });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Stakeholder,ProductOwner")]
    public async Task<IActionResult> SubmitForReview(Guid id, CancellationToken cancellationToken)
    {
        await _service.SubmitForReviewAsync(id, cancellationToken);
        return RedirectToAction(nameof(Details), new { id });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "ProductOwner,DevLead")]
    public async Task<IActionResult> MarkGroomed(Guid id, CancellationToken cancellationToken)
    {
        await _service.MarkGroomedAsync(id, cancellationToken);
        return RedirectToAction(nameof(Details), new { id });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Approver")]
    public async Task<IActionResult> Approve(DecisionInputModel input, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction(nameof(Details), new { id = input.RequirementId });
        }

        await _service.ApproveAsync(input.RequirementId, input.Reason, cancellationToken);
        return RedirectToAction(nameof(Details), new { id = input.RequirementId });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Approver")]
    public async Task<IActionResult> Reject(DecisionInputModel input, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction(nameof(Details), new { id = input.RequirementId });
        }

        await _service.RejectAsync(input.RequirementId, input.Reason, cancellationToken);
        return RedirectToAction(nameof(Details), new { id = input.RequirementId });
    }

    [HttpGet]
    [Authorize(Roles = "Producer,ProductOwner,DevLead")]
    public async Task<IActionResult> BacklogExport(CancellationToken cancellationToken)
    {
        var approved = await _service.GetApprovedAsync(cancellationToken);
        var lines = new List<string>
        {
            "# Approved Requirements Backlog",
            string.Empty,
            $"Generated: {DateTimeOffset.UtcNow:u}",
            string.Empty
        };

        foreach (var item in approved)
        {
            lines.Add($"- [{item.Priority}] {item.Title} ({item.ProjectName}) | Id: {item.Id}");
            lines.Add($"  - Goal: {item.BusinessGoal}");
            lines.Add($"  - Acceptance: {item.AcceptanceCriteria}");
        }

        var markdown = string.Join(Environment.NewLine, lines);
        return File(System.Text.Encoding.UTF8.GetBytes(markdown), "text/markdown", "approved-backlog.md");
    }
}

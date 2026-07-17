using System.ComponentModel.DataAnnotations;

namespace RequirementsGrooming.Web.ViewModels;

public class DecisionInputModel
{
    public Guid RequirementId { get; set; }

    [Required]
    [StringLength(1000)]
    public string Reason { get; set; } = string.Empty;
}

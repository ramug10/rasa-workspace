using System.ComponentModel.DataAnnotations;

namespace RequirementsGrooming.Web.ViewModels;

public class CreateRequirementInputModel
{
    [Required]
    [StringLength(150)]
    public string ProjectName { get; set; } = string.Empty;

    [Required]
    [StringLength(250)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [StringLength(2000)]
    public string BusinessGoal { get; set; } = string.Empty;

    [Required]
    [StringLength(4000)]
    public string AcceptanceCriteria { get; set; } = string.Empty;

    [Required]
    [StringLength(30)]
    public string Priority { get; set; } = "Medium";
}

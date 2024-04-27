using System.ComponentModel.DataAnnotations;

namespace RequestPermission_ClientRendering.ViewModels.Department
{
    public record DepartmentModifyVM
    {
        [StringLength(maximumLength: 50,
               MinimumLength = 10,
               ErrorMessage = "Range must be 10-50")]
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}

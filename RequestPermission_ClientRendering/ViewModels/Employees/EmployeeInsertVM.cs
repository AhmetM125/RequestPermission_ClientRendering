using System.ComponentModel.DataAnnotations;

namespace RequestPermission_ClientRendering.ViewModels.Employees;

public record EmployeeInsertVM
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Surname is required")]
    public string Surname { get; set; }
    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; }
    public int Department { get; set; }
    public string Title { get; set; }
}

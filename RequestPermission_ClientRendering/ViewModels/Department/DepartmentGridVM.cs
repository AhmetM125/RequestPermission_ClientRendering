using RequestPermission_ClientRendering.ViewModels.Employees;

namespace RequestPermission_ClientRendering.ViewModels.Department;

public record DepartmentGridVM
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public int TotalEmployee { get; set; }
    public IEnumerable<EmployeesGridVM>? EmployeeVMs { get; set; }
}

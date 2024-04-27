using System.Text.Json.Serialization;

namespace RequestPermission_ClientRendering.ViewModels.Employees;

public record EmployeeInsertVM
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public int Department { get; set; }
    public string Title { get; set; }
}

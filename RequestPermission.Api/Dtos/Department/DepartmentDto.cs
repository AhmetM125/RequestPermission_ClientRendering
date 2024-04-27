using RequestPermission.Api.Dtos.Employee;

namespace RequestPermission.Api.Dtos.Department;

public record DepartmentDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public bool IsActive { get; init; }
    public IEnumerable<EmployeeDto> Employees { get; init; }
}

namespace RequestPermission.Api.Dtos.Department;

public record DepartmentModifyDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public bool IsActive { get; init; }

}

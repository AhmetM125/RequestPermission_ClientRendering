namespace RequestPermission.Api.Dtos.Department;

public record DepartmentInsertDto
{
    public string Name { get; init; }
    public bool IsActive { get; init; }
}

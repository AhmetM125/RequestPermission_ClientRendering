namespace RequestPermission.Api.Dtos.Employee;

public record EmployeeAddDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public int Department { get; set; }
    public string Title { get; set; }
}

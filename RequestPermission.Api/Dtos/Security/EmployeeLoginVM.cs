namespace RequestPermission.Api.Dtos.Security;

public record EmployeeLoginVM
{
    public string Username { get; init; }
    public string Password { get; init; }
}

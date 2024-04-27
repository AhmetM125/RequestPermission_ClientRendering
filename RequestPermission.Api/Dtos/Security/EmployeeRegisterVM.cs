namespace RequestPermission.Api.Dtos.Security;

public record EmployeeRegisterVM
{
    public string Username { get; init; }
    public string Password { get; init; }
    public string Email { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }

}

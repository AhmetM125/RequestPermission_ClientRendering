using System.Text.Json.Serialization;

namespace RequestPermission_ClientRendering.ViewModels.Security;

public record EmployeeLoginVM
{
    public string Username { get; set; }
    public string Password { get; set; }

}


namespace RequestPermission_ClientRendering.ViewModels.Security;

public record LoginResponse
{
    public Guid Id { get; set; }
    public string JwtToken { get; set; }
    public string Username { get; set; }
}

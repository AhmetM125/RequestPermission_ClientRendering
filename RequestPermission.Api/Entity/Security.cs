namespace RequestPermission.Api.Entity;

public class Security
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public Employee Employee { get; set; }

}

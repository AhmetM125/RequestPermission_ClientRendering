namespace RequestPermission.Api.Dtos.Security
{
    public class LoginResponseVM
    {
        public Guid Id { get; set; }
        public string JwtToken { get; set; }
        public string Username { get; set; }
    }
}

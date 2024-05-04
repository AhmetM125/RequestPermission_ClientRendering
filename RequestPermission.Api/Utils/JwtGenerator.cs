using Microsoft.IdentityModel.Tokens;
using RequestPermission.Api.Dtos.Security;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RequestPermission.Api.Utils;

public class JwtGenerator
{
    private readonly IConfiguration _configuration;
    public JwtGenerator(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string GenerateJwtToken(EmployeeLoginVM employeeLogin,Guid employeeId)
    {

        var claims = new[] {
             new Claim("Username", employeeLogin.Username),
             new Claim("EmployeeId",employeeId.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.Now.AddDays(int.Parse(_configuration["Jwt:JwtExpireDays"].ToString()));
        var issuer = _configuration["Jwt:Issuer"];


        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Issuer = issuer,
            Audience = _configuration["Jwt:Audience"],
            Expires = expires,
            SigningCredentials = credentials
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

using Microsoft.AspNetCore.Mvc;
using RequestPermission.Api.Dtos.Security;
using RequestPermission.Api.Services.Contracts;
using System.Net;

namespace RequestPermission.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SecurityController : ControllerBase
{
    private readonly ISecurityService _securityService;
    public SecurityController(ISecurityService securityService)
    {
        _securityService = securityService;
    }

    [HttpPost("login")]
    [ProducesResponseType(typeof(LoginResponseVM), (int)HttpStatusCode.OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login(EmployeeLoginVM employee)
    {
        var result = await _securityService.Login(employee);
        if (result == null)
        {
            return Unauthorized();
        }
        return Ok(result);
    }
    //public IActionResult Register(EmployeeRegisterVM employee)
    //{
    //    _securityService.Register(employee);
    //    return Ok(new { success = true });
    //}
}

using Microsoft.AspNetCore.Authorization;
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
    [AllowAnonymous]
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
    [HttpPost("Register")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(EmployeeRegisterVM), (int)HttpStatusCode.OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register(EmployeeRegisterVM employee)
    {
        await _securityService.Register(employee);
        var result = await _securityService.Login(new EmployeeLoginVM { Username = employee.Username, Password = employee.Password });
        if(result != null)
            return Ok(result);
        else
            return Ok(new { success = false });
    }
}

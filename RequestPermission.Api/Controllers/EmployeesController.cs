using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RequestPermission.Api.Dtos.Employee;
using RequestPermission.Api.Services.Contracts;
using System.Net;

namespace RequestPermission.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _employeeService;
    private readonly IMapper _mapper;

    public EmployeesController(IEmployeeService employeeService, IMapper mapper)
    {
        _employeeService = employeeService;
        _mapper = mapper;
    }
    [HttpPost("InsertNewEmployee")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateNewUser(EmployeeAddDto employee)
    {
        try
        {
            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            await _employeeService.InsertNewEmployee(employeeDto);
            return StatusCode((int)HttpStatusCode.Created);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    [HttpGet("GetAllEmployees")]
    [ProducesResponseType(typeof(List<EmployeeDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllEmployees(CancellationToken cancellationToken)
    {
        try
        {
            await _employeeService.GetEmployees();
            return Ok(await _employeeService.GetEmployees());
        }
        catch (Exception)
        {
            throw;
        }

    }

    [HttpGet("GetEmployeeForModify/{employeeId:Guid}")]
    [ProducesResponseType(typeof(EmployeeDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetEmployeeForModify(Guid employeeId)
    {
        try
        {
            var employee = _employeeService.GetEmployeeForModify(employeeId);
            return Ok(employee);
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    [HttpPost("UpdateUser")]
    [ProducesResponseType(typeof(EmployeeUpdateDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult UpdateUser([FromBody] EmployeeUpdateDto employee, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        _employeeService.UpdateUser(_mapper.Map<EmployeeDto>(employee));
        return Ok();
    }
    [HttpDelete("DeleteEmployee/{employeeId:Guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteEmployee(Guid employeeId)
    {
        await _employeeService.DeleteEmployee(employeeId);
        return Ok();
    }
}

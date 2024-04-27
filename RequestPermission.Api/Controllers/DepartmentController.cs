using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RequestPermission.Api.Dtos.Department;
using RequestPermission.Api.Services.Contracts;

namespace RequestPermission.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class DepartmentController : ControllerBase
{
    private readonly IDepartmentService _departmentService;

    public DepartmentController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    [HttpGet("GetAllActiveDepartments")]
    [ProducesResponseType(typeof(List<DepartmentListDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetDepartments()
    {
        var departments = await _departmentService.GetAllActiveDepartments();
        return Ok(departments);

    }

    [HttpGet("GetAllDepartments")]
    [ProducesResponseType(typeof(List<DepartmentListDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult GetAllDepartments()
    {
        var departments = _departmentService.GetDepartmentsRawQuery();
        return Ok(departments);
    }

    [HttpGet("GetDepartmentById/{id}")]
    [ProducesResponseType(typeof(DepartmentModifyDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetDepartmentById(int id)
    {
        var department = await _departmentService.GetDepartmentForModify(id);
        return Ok(department);
    }

    [HttpPost("AddDepartment")]
    [ProducesResponseType(typeof(DepartmentInsertDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddDepartment(DepartmentInsertDto departmentInsert)
    {
        await _departmentService.InsertNewDepartment(departmentInsert);
        return Ok(new { success = true });
    }

    [HttpPut("UpdateDepartment")]
    [ProducesResponseType(typeof(DepartmentModifyDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult UpdateDepartment(DepartmentModifyDto departmentModifyDto)
    {
        _departmentService.UpdateDepartment(departmentModifyDto);
        return Ok(new { success = true });
    }

    [HttpDelete("DeleteDepartment/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult DeleteDepartment(int id)
    {
        _departmentService.DeleteDepartment(id);
        return Ok(new { success = true });
    }
}

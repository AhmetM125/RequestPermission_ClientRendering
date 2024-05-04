using Microsoft.AspNetCore.Mvc;
using RequestPermission.Api.Dtos.Request;
using RequestPermission.Api.Services.Contracts;
using RequestPermission.Api.Validations;

namespace RequestPermission.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestPermissionController : ControllerBase
    {
        private readonly IRequestPermissionService _requestPermissionService;

        public RequestPermissionController(IRequestPermissionService requestPermissionService)
        {
            _requestPermissionService = requestPermissionService;
        }

        [HttpPost]
        [Route("NewPermission")]
        [ProducesResponseType(typeof(RequestPermissionDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> NewPermission([FromBody] RequestPermissionDto requestVM)
        {
            RequestPermissionValidator validationRules = new RequestPermissionValidator();
            var validationResult = validationRules.Validate(requestVM);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);
            await _requestPermissionService.InsertNewRequest(requestVM);
            return Ok(new { succces = true });
        }
        [HttpGet("GetPermissionsOfEmployee/{employeeId:guid}")]
        [ProducesResponseType(typeof(List<PermissionGridDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPermissionsOfEmployee(Guid employeeId)
        {
            var http = HttpContext;
            var permissions = await _requestPermissionService.GetPermissionsOfEmployee(employeeId);
            return Ok(permissions);
        }
    }
}

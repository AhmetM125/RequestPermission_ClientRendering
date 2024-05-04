using RequestPermission.Api.Dtos.Request;

namespace RequestPermission.Api.Services.Contracts;

public interface IRequestPermissionService
{
    Task<List<PermissionGridDto>> GetPermissionsOfEmployee(Guid employeeId);
    Task InsertNewRequest(RequestPermissionDto requestPermissionDto);
}

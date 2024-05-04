using RequestPermission_ClientRendering.ViewModels.RequestPermission;

namespace RequestPermission_ClientRendering.Services.RequestPermission.Abstract;

public interface IRequestPermissionService
{
    Task<List<PermissionGridVM>?> GetPermissions(Guid employeeId);
    Task RequestPermission(RequestPermissionRequestVM requestVM);
}

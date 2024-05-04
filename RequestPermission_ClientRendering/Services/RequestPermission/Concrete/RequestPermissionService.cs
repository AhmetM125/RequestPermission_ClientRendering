using RequestPermission_ClientRendering.Services.BaseService;
using RequestPermission_ClientRendering.Services.RequestPermission.Abstract;
using RequestPermission_ClientRendering.ViewModels.RequestPermission;

namespace RequestPermission_ClientRendering.Services.RequestPermission.Concrete;

public class RequestPermissionService : BaseApi, IRequestPermissionService
{
    public RequestPermissionService(HttpClient httpClient) : base(httpClient)
    {
        ApiName = "RequestPermission/";
    }

    public async Task<List<PermissionGridVM>?> GetPermissions(Guid employeeId)
     => await HandleReadResponse<PermissionGridVM>("GetPermissionsOfEmployee/" + employeeId);

    public async Task RequestPermission(RequestPermissionRequestVM requestVM)
     => await HandlePostResponse<RequestPermissionRequestVM>(requestVM,"NewPermission");
}

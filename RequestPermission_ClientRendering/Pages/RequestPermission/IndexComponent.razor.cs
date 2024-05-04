using Microsoft.AspNetCore.Components;
using RequestPermission_ClientRendering.Base;
using RequestPermission_ClientRendering.Services.RequestPermission.Abstract;
using RequestPermission_ClientRendering.ViewModels.RequestPermission;

namespace RequestPermission_ClientRendering.Pages.RequestPermission;

public partial class IndexComponent : RazorBaseComponent
{
    RequestPermissionRequestVM requestVM = new RequestPermissionRequestVM();
    List<PermissionGridVM>? permissionGridVMs;
    [Inject] IRequestPermissionService RequestPermissionService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        Clear();
        if (permissionGridVMs is null)
            await LoadGrid();
    }
    async Task Submit()
    {
        requestVM.EmployeeId = await AuthorizationProvider.GetCurrentUserId();
        await RequestPermissionService.RequestPermission(requestVM);
        await LoadGrid();
        Clear();
    }
    void Clear()
    {
        requestVM = new RequestPermissionRequestVM();
        requestVM.StartDate = DateTime.Now;
        requestVM.EndDate = DateTime.Now;
    }
    async Task LoadGrid()
    {
        var employeeId = await AuthorizationProvider.GetCurrentUserId();
        permissionGridVMs = (await RequestPermissionService.GetPermissions(employeeId)).OrderByDescending(x=>x.StartDate).Take(10).ToList();

    }
}

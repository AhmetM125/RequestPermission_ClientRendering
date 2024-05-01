using Microsoft.AspNetCore.Components;
using RequestPermission_ClientRendering.Base;
using RequestPermission_ClientRendering.Services.Department.Abstract;
using RequestPermission_ClientRendering.ViewModels.Department;
namespace RequestPermission_ClientRendering.Pages.Department;

public partial class IndexComponent : RazorBaseComponent
{
    [Inject] private IDepartmentService _departmentService { get; set; }
    List<DepartmentGridVM>? DepartmentGridVMs;
    public bool isLoading { get; set; }
    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        if (DepartmentGridVMs == null)
            await LoadData();
    }
    private async Task LoadData()
    {
        DepartmentGridVMs = await _departmentService.GetDepartmentsAsync();
    }

    async Task Modify(PageStatus pageStatus, DepartmentGridVM departmentGridVM = null)
    {
        PageStatus = pageStatus;

        switch (pageStatus)
        {

            case PageStatus.Insert:
            case PageStatus.Modify:
                await ShowModal("ModifyDepartment");
                break;
            case PageStatus.List:
                break;
            case PageStatus.Delete:
                await _departmentService.DeleteDepartmentAsync(departmentGridVM.Id);
                break;
            default:
                break;
        }
        await LoadData();
    }

}

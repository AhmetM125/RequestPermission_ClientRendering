using Microsoft.AspNetCore.Components;
using RequestPermission_ClientRendering.Base;
using RequestPermission_ClientRendering.Services.Department.Abstract;
using RequestPermission_ClientRendering.ViewModels.Department;
namespace RequestPermission_ClientRendering.Pages.Department;

public partial class IndexComponent : RazorBaseComponent
{
    [Inject] private IDepartmentService _departmentService { get; set; }
    List<DepartmentGridVM>? DepartmentGridVMs;
    protected override async Task OnInitializedAsync()
    {
        if (DepartmentGridVMs == null) await LoadData();
        await base.OnInitializedAsync();
    }
    private async Task LoadData()
     => DepartmentGridVMs = await _departmentService.GetDepartmentsAsync();

}

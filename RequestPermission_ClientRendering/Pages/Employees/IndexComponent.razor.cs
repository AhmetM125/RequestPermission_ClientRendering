using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using RequestPermission_ClientRendering.Base;
using RequestPermission_ClientRendering.Services.Employee.Abstract;
using RequestPermission_ClientRendering.ViewModels.Employees;

namespace RequestPermission_ClientRendering.Pages.Employees;

public partial class IndexComponent : RazorBaseComponent
{
    [Inject] private IEmployeeService _employeeService { get; set; }

    private List<EmployeesGridVM> employees;

    EmployeeModifyVM employeeModifyVM = new EmployeeModifyVM();

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        if (employees is null)
            await LoadEmployees();
    }
    async Task LoadEmployees()
    {
        employees = await _employeeService.GetAllEmployees()
                            ?? Enumerable.Empty<EmployeesGridVM>().ToList();
    }
    async Task openModal(Guid employeeId, PageStatus pageStatus)
    {
        PageStatus = pageStatus;
        employeeModifyVM.Id = employees.FirstOrDefault(x => x.Id == employeeId).Id;
        await InvokeVoidJavascript();
    }
    async Task InsertEmployee(PageStatus pageStatus)
    {
        PageStatus = pageStatus;
        employeeModifyVM = new();
        await InvokeVoidJavascript();
    }
    async Task InvokeVoidJavascript()
      => await JSRuntime.InvokeVoidAsync("OpenModal", "employeeModifyModal");

    async Task DeleteEmployee(Guid employeeId)
    {
        await _employeeService.DeleteSelectedEmployee(employeeId);
        await LoadEmployees();
    }
}

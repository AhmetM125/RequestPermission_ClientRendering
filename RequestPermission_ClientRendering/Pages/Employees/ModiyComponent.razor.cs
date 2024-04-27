using Microsoft.AspNetCore.Components;
using RequestPermission_ClientRendering.Base;
using RequestPermission_ClientRendering.Services.Employee.Abstract;
using RequestPermission_ClientRendering.ViewModels.Employees;

namespace RequestPermission_ClientRendering.Pages.Employees;

public partial class ModiyComponent : RazorBaseComponent
{
    [Parameter] public EmployeeModifyVM EmployeeModifyVM { get; set; }
    [Inject] IEmployeeService _employeeService { get; set; }
    [Parameter] public PageStatus PageMode { get; set; }
    [Parameter] public EventCallback OnClose { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await GetEmployee();
        await base.OnInitializedAsync();
    }
    protected override async Task OnParametersSetAsync()
    {
        await GetEmployee();
        await base.OnParametersSetAsync();
    }
    async Task GetEmployee()
    {
        if (EmployeeModifyVM is not null && EmployeeModifyVM.Id != Guid.Empty)
            EmployeeModifyVM = await _employeeService.GetEmployeeForModify(EmployeeModifyVM.Id);
    }
    async Task CloseModal() => await CloseModal("employeeModifyModal");

    async Task SaveModal()
    {
        switch (PageMode)
        {
            case PageStatus.Modify:
                await _employeeService.UpdateUser(EmployeeModifyVM);
                break;
            case PageStatus.Insert:
                var employeeInsertDto = new EmployeeInsertVM()
                {
                    Title = EmployeeModifyVM.Position,
                    Name = EmployeeModifyVM.Name,
                    Surname = EmployeeModifyVM.Surname,
                    Email = EmployeeModifyVM.Email,
                    Department = 3,
                };
                await _employeeService.InsertUser(employeeInsertDto);
                break;
            case PageStatus.Delete:
                break;
            default:
                break;
        }


        await OnClose.InvokeAsync();
        await CloseModal();
    }
}

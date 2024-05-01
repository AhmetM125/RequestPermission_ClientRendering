using Microsoft.AspNetCore.Components;
using RequestPermission_ClientRendering.Base;
using RequestPermission_ClientRendering.Services.Department.Abstract;
using RequestPermission_ClientRendering.ViewModels.Department;

namespace RequestPermission_ClientRendering.Pages.Department;

public partial class ModifyComponent : RazorBaseComponent
{
    [Parameter] public string ComponentId { get; set; }
    [Parameter] public EventCallback OnClose { get; set; }
    [Inject] public IDepartmentService DepartmentService { get; set; }
    public DepartmentInsertVM Department { get; set; } = new DepartmentInsertVM();
    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
    }
    async Task SaveDepartment()
    {
        try
        {
            if (Department.Name != string.Empty)
                await DepartmentService.AddDepartmentAsync(Department);
            MainLayoutCascadingValue.ShowMessage("Department Added", MessageType.Success);
        }
        catch (Exception ex)
        {
            MainLayoutCascadingValue.ShowMessage("An error occurred while adding the department", MessageType.Error);
            Console.WriteLine(ex.InnerException);
        }
        finally
        {
            await OnClose.InvokeAsync();
            await CloseModal(ComponentId);
        }
    }
}

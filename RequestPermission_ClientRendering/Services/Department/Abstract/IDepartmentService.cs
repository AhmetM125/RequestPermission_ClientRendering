using RequestPermission_ClientRendering.ViewModels.Department;

namespace RequestPermission_ClientRendering.Services.Department.Abstract;

public interface IDepartmentService
{
    Task<List<DepartmentGridVM>?> GetDepartmentsAsync();
    Task<List<DepartmentGridVM>?> GetActiveDepartmentsAsync();
    Task<DepartmentModifyVM?> GetDepartmentByIdAsync(int id);
    Task AddDepartmentAsync(DepartmentInsertVM department);
    Task UpdateDepartmentAsync(DepartmentModifyVM department);
    Task DeleteDepartmentAsync(int id);
}

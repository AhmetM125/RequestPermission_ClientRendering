using RequestPermission_ClientRendering.ViewModels.Employees;

namespace RequestPermission_ClientRendering.Services.Employee.Abstract;

public interface IEmployeeService
{
    Task DeleteSelectedEmployee(Guid employeeId);
    Task<List<EmployeesGridVM>?> GetAllEmployees();
    Task<EmployeeModifyVM?> GetEmployeeForModify(Guid employeeId);
    Task InsertUser(EmployeeInsertVM employeeModifyVM);
    Task UpdateUser(EmployeeModifyVM employeeModifyVM);
}

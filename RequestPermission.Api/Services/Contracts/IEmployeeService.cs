using RequestPermission.Api.Dtos.Employee;

namespace RequestPermission.Api.Services.Contracts;

public interface IEmployeeService
{
    Task DeleteEmployee(Guid employeeId);
    EmployeeDto GetEmployeeForModify(Guid employeeId);
    Task<List<EmployeeDto>> GetEmployees();
    List<EmployeeDto> GetEmployeesRawQuery();
    Task InsertNewEmployee(EmployeeDto employee);
    Task UpdateUser(EmployeeDto employee);
}

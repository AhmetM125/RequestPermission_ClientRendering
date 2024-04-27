using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RequestPermission.Api.DataLayer.Contract;
using RequestPermission.Api.Dtos.Employee;
using RequestPermission.Api.Entity;
using RequestPermission.Api.Services.Contracts;

namespace RequestPermission.Api.Services.Concrete;

public class EmployeeService : IEmployeeService
{
    private readonly IEfEmployeeDal _efEmployeeDal;
    private readonly IMapper _mapper;
    public EmployeeService(IEfEmployeeDal efEmployeeDal, IMapper mapper)
    {
        _efEmployeeDal = efEmployeeDal;
        _mapper = mapper;
    }

    public async Task DeleteEmployee(Guid employeeId)
    {
        var employeeDto = _efEmployeeDal.GetFirstOrDefault(x => x.E_ID == employeeId);
        //_efEmployeeDal.DeleteById(employeeId);
        _efEmployeeDal.Delete(employeeDto);
        await _efEmployeeDal.SaveAsync(CancellationToken.None);
    }

    public EmployeeDto GetEmployeeForModify(Guid employeeId)
    {
        var employeeDto = _efEmployeeDal.GetFirstOrDefault(x => x.E_ID == employeeId);
        return _mapper.Map<EmployeeDto>(employeeDto);
    }

    public async Task<List<EmployeeDto>> GetEmployees()
    {
        return _mapper.Map<List<EmployeeDto>>(await _efEmployeeDal.GetQueryable().ToListAsync());
    }

    public List<EmployeeDto> GetEmployeesRawQuery()
    {
        string query = "SELECT * FROM Employees";
        var employees = _efEmployeeDal.GetWithRawSql(query);
        return _mapper.Map<List<EmployeeDto>>(employees);
    }

    public async Task InsertNewEmployee(EmployeeDto employee)
    {
        _efEmployeeDal.Add(new Employee()
        {
            E_DEPARTMENT = employee.Department,
            E_ID = Guid.NewGuid(),
            E_NAME = employee.Name,
            E_SURNAME = "",
            E_TITLE = employee.Title,
        });
        await _efEmployeeDal.SaveAsync(CancellationToken.None);
    }

    public async Task UpdateUser(EmployeeDto employee)
    {
        var employeeDto = _efEmployeeDal.GetByFilter(x => x.E_ID == employee.Id);

        if (employeeDto is null)
            throw new Exception("Employee not found");

        employeeDto.E_NAME = employee.Name;
        employeeDto.E_TITLE = employee.Title;
        employeeDto.E_SURNAME = employee.Surname;

        _efEmployeeDal.Update(employeeDto);
        await _efEmployeeDal.SaveAsync(CancellationToken.None);
    }
}

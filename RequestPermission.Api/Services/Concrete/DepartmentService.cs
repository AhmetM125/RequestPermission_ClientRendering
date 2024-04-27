using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RequestPermission.Api.DataLayer.Contract;
using RequestPermission.Api.Dtos.Department;
using RequestPermission.Api.Dtos.Employee;
using RequestPermission.Api.Entity;
using RequestPermission.Api.Services.Contracts;

namespace RequestPermission.Api.Services.Concrete;

public class DepartmentService : IDepartmentService
{
    private readonly IEfDepartmentDal _efDepartmentDal;
    private readonly IMapper _mapper;

    public DepartmentService(IEfDepartmentDal efDepartmentDal, IMapper mapper)
    {
        _efDepartmentDal = efDepartmentDal;
        _mapper = mapper;
    }

    public void DeleteDepartment(int departmentId)
    {
        _efDepartmentDal.DeleteById(departmentId);
    }

    public async Task<DepartmentModifyDto> GetDepartmentForModify(int departmentId)
    {
        return _mapper.Map<DepartmentModifyDto>(await _efDepartmentDal.GetByFilterAsync(x => x.D_ID == departmentId));
    }

    public async Task<List<DepartmentListDto>> GetAllActiveDepartments()
    {
        var departmentList = await _efDepartmentDal.GetQueryable(x => x.D_IS_ACTIVE == true)
            .Select(x => new DepartmentListDto
            {
                Id = x.D_ID,
                Name = x.D_NAME,
                IsActive = x.D_IS_ACTIVE,
                //EmployeeDtos = x.EMPLOYEES != null ? x.EMPLOYEES.Select(y => new EmployeeDto
                //{
                //    Id = y.E_ID,
                //    Name = y.E_NAME,
                //    Surname = y.E_SURNAME,
                //    Department = y.E_DEPARTMENT,
                //    Title = y.E_TITLE
                //}).ToList() : null,
                TotalEmployee = x.EMPLOYEES.Count()
            }).ToListAsync();

        return departmentList;
    }

    public List<DepartmentListDto> GetDepartmentsRawQuery()
    {
        return _efDepartmentDal.GetWithRawSql("SELECT * FROM DEPARTMENTS").Select(x => new DepartmentListDto
        {
            Id = x.D_ID,
            Name = x.D_NAME,
            IsActive = x.D_IS_ACTIVE
        }).ToList();
    }

    public async Task InsertNewDepartment(DepartmentInsertDto department)
    {
        await _efDepartmentDal.AddAsync(_mapper.Map<Department>(department));
    }

    public void UpdateDepartment(DepartmentModifyDto department)
    {
        _mapper.Map<Department>(department);
    }
}

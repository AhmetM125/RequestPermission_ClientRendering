using Microsoft.EntityFrameworkCore;
using RequestPermission.Api.DataLayer.Contract;
using RequestPermission.Api.Dtos.Request;
using RequestPermission.Api.Entity;
using RequestPermission.Api.Services.Contracts;

namespace RequestPermission.Api.Services.Concrete;

public class RequestPermissionService : IRequestPermissionService
{
    private readonly IEfRequestPermissionDal _efRequestPermissionDal;

    public RequestPermissionService(IEfRequestPermissionDal efRequestPermissionDal)
    {
        _efRequestPermissionDal = efRequestPermissionDal;
    }

    public async Task<List<PermissionGridDto>> GetPermissionsOfEmployee(Guid employeeId)
    {
        var listOfEmployee = await _efRequestPermissionDal.GetQueryable(x => x.V_EMP_ID == employeeId)
              .Select(x => new PermissionGridDto
              {
                  StartDate = x.V_START_DATE,
                  EndDate = x.V_END_DATE,
                  PermissionType = x.V_TYPE,
                  Reason = x.V_REASON,
                  EmployeeNameSurname = x.V_EMP.E_NAME + " " + x.V_EMP.E_SURNAME
              }).OrderBy(x=>x.StartDate).ThenBy(x=>x.EndDate).ToListAsync();
        return listOfEmployee;
    }

    public async Task InsertNewRequest(RequestPermissionDto requestPermissionDto)
    {
        var vacationEntity = new Vacation
        {
            V_ID = Guid.NewGuid(),
            V_START_DATE = requestPermissionDto.StartDate,
            V_END_DATE = requestPermissionDto.EndDate,
            V_TYPE = requestPermissionDto.Type,
            V_REASON = requestPermissionDto.Reason,
            V_EMP_ID = requestPermissionDto.EmployeeId
        };
        await _efRequestPermissionDal.AddAsync(vacationEntity);
        await _efRequestPermissionDal.SaveAsync(CancellationToken.None);
    }
}

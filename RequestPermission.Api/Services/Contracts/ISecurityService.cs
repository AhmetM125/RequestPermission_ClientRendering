using RequestPermission.Api.Dtos.Security;

namespace RequestPermission.Api.Services.Contracts;

public interface ISecurityService
{
    Task<LoginResponseVM> Login(EmployeeLoginVM employee);
    Task Register(EmployeeRegisterVM employee);
}

using RequestPermission_ClientRendering.ViewModels.Security;

namespace RequestPermission_ClientRendering.Services.Security.Abstract;

public interface ILoginService
{
    Task<LoginResponse> Login(EmployeeLoginVM employeeLogin);
    Task<LoginResponse?> Register(EmployeeRegisterVM employeeRegisterVM);
}

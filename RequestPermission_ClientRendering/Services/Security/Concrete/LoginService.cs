using RequestPermission_ClientRendering.Base;
using RequestPermission_ClientRendering.Services.BaseService;
using RequestPermission_ClientRendering.Services.Security.Abstract;
using RequestPermission_ClientRendering.ViewModels.Security;

namespace RequestPermission_ClientRendering.Services.Security.Concrete;

public class LoginService : BaseApi, ILoginService
{
    private readonly AuthorizationProvider _authorizationProvider;
    public LoginService(HttpClient httpClient, AuthorizationProvider authorizationProvider) : base(httpClient)
    {
        ApiName = "Security/";
        _authorizationProvider = authorizationProvider;
    }

    public async Task<LoginResponse> Login(EmployeeLoginVM employee)
    {
        var response = await HandleLoginPostResponse<LoginResponse, EmployeeLoginVM>(employee, "Login");
        var token = new TokenVM() { Token = response.JwtToken };

        if (response != null)
        {
            await _authorizationProvider.MarkUserAsAuthenticated(token, response, true);
        }
        return response;
    }
}

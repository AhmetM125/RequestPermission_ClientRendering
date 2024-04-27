using Microsoft.AspNetCore.Components;
using RequestPermission_ClientRendering.Base;
using RequestPermission_ClientRendering.Services.Security.Abstract;
using RequestPermission_ClientRendering.ViewModels.Security;

namespace RequestPermission_ClientRendering.Pages
{
    public partial class LoginComponent : RazorBaseComponent
    {
        EmployeeLoginVM employeeLoginVM = new EmployeeLoginVM();
        LoginResponse LoginResponse = new LoginResponse();
        [Inject] ILoginService _loginService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        async Task Login()
        {
            if (!string.IsNullOrEmpty(employeeLoginVM.Username) || !string.IsNullOrEmpty(employeeLoginVM.Password))
            {
                LoginResponse = await _loginService.Login(employeeLoginVM);
                if (!string.IsNullOrEmpty(LoginResponse.JwtToken) && LoginResponse.Id != Guid.Empty)
                {
                    NavigationManager.NavigateTo("/", true);
                }
            }


        }


    }
}

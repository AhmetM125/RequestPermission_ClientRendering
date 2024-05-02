using Microsoft.AspNetCore.Components;
using RequestPermission_ClientRendering.Base;
using RequestPermission_ClientRendering.Services.Security.Abstract;
using RequestPermission_ClientRendering.ViewModels.Security;

namespace RequestPermission_ClientRendering.Pages
{
    public partial class LoginComponent : RazorBaseComponent
    {
        [Inject] private ILoginService _loginService { get; set; }

        EmployeeLoginVM employeeLoginVM = new EmployeeLoginVM();
        LoginResponse LoginResponse = new LoginResponse();
        EmployeeRegisterVM employeeRegisterVM = new EmployeeRegisterVM();
        bool isLoginPage = true;
        DateTime selectedDate = DateTime.Now;
        List<string> errors = new List<string>();


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
        async Task Register()
        {
            DeleteErrors();
            if (string.IsNullOrEmpty(employeeRegisterVM.Username) ||
                string.IsNullOrEmpty(employeeRegisterVM.Password) ||
                string.IsNullOrEmpty(employeeRegisterVM.ConfirmPassword))
                errors.Add("Please fill all fields");

            if (employeeRegisterVM.Password != employeeRegisterVM.ConfirmPassword)
                errors.Add("Password and Confirm Password must be the same");

            if (!errors.Any())
            {
                var response = await _loginService.Register(employeeRegisterVM);
                if (response != null && !string.IsNullOrEmpty(response.JwtToken) && response.Id != Guid.Empty)
                    NavigationManager.NavigateTo("/");
            }
        }

        void DeleteErrors()
            => errors = new List<string>();
    }
}

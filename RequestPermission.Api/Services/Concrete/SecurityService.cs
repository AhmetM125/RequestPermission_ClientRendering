using RequestPermission.Api.DataLayer.Contract;
using RequestPermission.Api.Dtos.Security;
using RequestPermission.Api.Services.Contracts;
using RequestPermission.Api.Utils;

namespace RequestPermission.Api.Services.Concrete;

public class SecurityService : ISecurityService
{
    private readonly IConfiguration _configuration;
    private readonly IEfSecurityDal _efSecurityDal;
    public SecurityService(IConfiguration configuration, IEfSecurityDal efSecurityDal)
    {
        _configuration = configuration;
        _efSecurityDal = efSecurityDal;
    }
    public async Task<LoginResponseVM> Login(EmployeeLoginVM employee)
    {
        var encryptedPassword = PasswordEncryption.Encrypt(employee.Password);

        var employeeLoginResponse = await _efSecurityDal.GetByFilterAsync(x => x.Username == employee.Username
                                                        && x.Password == encryptedPassword);

        if (employeeLoginResponse == null)
            throw new Exception("Invalid username or password");

        JwtGenerator jwtGenerator = new JwtGenerator(_configuration);
        var tokenString = jwtGenerator.GenerateJwtToken(employee);

        return new LoginResponseVM
        {
            JwtToken = tokenString,
            Username = employee.Username,
            Id = employeeLoginResponse.Id
        };
    }

    public async Task Register(EmployeeRegisterVM employeeRegisterVM)
    {

        //     public string Username { get; init; }
        //public string Password { get; init; }
        //public string Email { get; init; }
        //public string FirstName { get; init; }
        //public string LastName { get; init; }

        //var employee = Employee.CreateEmployeeForRegister(employeeRegisterVM.LastName, employeeRegisterVM.FirstName,
        //                                                        employeeRegisterVM.Email);
        //_efSecurityDal.Add(employee);
    }
}

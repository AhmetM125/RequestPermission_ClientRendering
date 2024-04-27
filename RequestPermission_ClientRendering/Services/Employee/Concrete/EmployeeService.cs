using RequestPermission_ClientRendering.Services.BaseService;
using RequestPermission_ClientRendering.Services.Employee.Abstract;
using RequestPermission_ClientRendering.ViewModels.Employees;

namespace RequestPermission_ClientRendering.Services.Employee.Concrete;

public class EmployeeService : BaseApi, IEmployeeService
{
    public EmployeeService(HttpClient httpClient) : base(httpClient)
    {
        ApiName = "Employees/";
    }

    public async Task DeleteSelectedEmployee(Guid employeeId)
        => await HandleDeleteResponse(employeeId, $"DeleteEmployee/{employeeId}");


    public async Task<List<EmployeesGridVM>?> GetAllEmployees()
        => await HandleReadResponse<EmployeesGridVM>("GetAllEmployees");

    public async Task<EmployeeModifyVM?> GetEmployeeForModify(Guid employeeId)
     => await HandleSingleReadResponse<EmployeeModifyVM>($"GetEmployeeForModify/{employeeId}");


    public async Task InsertUser(EmployeeInsertVM employeeModifyVM)
     => await HandlePostResponseAsJson(employeeModifyVM, "InsertNewEmployee");


    public async Task UpdateUser(EmployeeModifyVM employeeModifyVM)
     => await HandlePostResponse(employeeModifyVM, "UpdateUser");
}


//public async Task UpdateUser(EmployeeModifyVM employeeModifyVM)
//{
//    var content = new StringContent(JsonSerializer.Serialize(employeeModifyVM), Encoding.UTF8, "application/json");

//    // Send the POST request
//    var response = await HttpClient.PostAsync(ApiName + "UpdateUser", content); // BU PUT OLABILIRDI.

//    // Check if the request was successful
//    if (response.IsSuccessStatusCode)
//    {
//        // Optionally, you can read the response content
//        var responseContent = await response.Content.ReadAsStringAsync();
//        // Do something with responseContent if needed
//    }
//    else
//    {
//        // If the request was not successful, handle the error
//        // You can extract more information from the response if needed
//        var errorMessage = $"Error: {response.StatusCode} - {response.ReasonPhrase}";
//        throw new Exception(errorMessage);
//    }
//}
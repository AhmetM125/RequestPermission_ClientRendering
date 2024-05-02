using System.Globalization;
using System.Text.Json.Serialization;

namespace RequestPermission_ClientRendering.ViewModels.Security;

public record EmployeeRegisterVM
{
    public string Username { get; set; }
    public string Password { get; set; }
    [JsonIgnore]
    public string ConfirmPassword { get; set; }
    public string FirstName { get; set; } = "Ahmet";
    public string LastName { get; set; } = "Yurdal";
    
    //private static string GetUsername(string username)
    //{
    //    var result = new CultureInfo("en-US");
    //    TextInfo textInfo = result.TextInfo;
    //    return textInfo.ToLower(username.Trim());
    //}
    //public static EmployeeRegisterVM Empty => new EmployeeRegisterVM(string.Empty, string.Empty, string.Empty);

}

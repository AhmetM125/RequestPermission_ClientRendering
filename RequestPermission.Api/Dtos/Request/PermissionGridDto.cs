namespace RequestPermission.Api.Dtos.Request;

public record PermissionGridDto
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string PermissionType { get; set; }
    public string EmployeeNameSurname { get; set; }
    public string Reason { get; set; }
}

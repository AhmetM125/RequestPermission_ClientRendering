namespace RequestPermission_ClientRendering.ViewModels.RequestPermission;

public record PermissionGridVM
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string PermissionType { get; set; }
    public string EmployeeNameSurname { get; set; }
    public string Reason { get; set; }
}

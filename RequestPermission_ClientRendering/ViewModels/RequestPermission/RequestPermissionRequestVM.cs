namespace RequestPermission_ClientRendering.ViewModels.RequestPermission;

public record RequestPermissionRequestVM
{
    public Guid EmployeeId { get; set; }
    public string Type { get; set; } 
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Reason { get; set; } 
}


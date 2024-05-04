namespace RequestPermission.Api.Dtos.Request;

public record RequestPermissionDto
{
    public Guid EmployeeId { get; set; }
    public string Type { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Reason { get; set; }
}

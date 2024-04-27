namespace RequestPermission.Api.Entity;

public class BaseEntity
{
    public DateTime? InsertDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public string UpdateUser { get; set; }
    public string InsertUser { get; set; }
}

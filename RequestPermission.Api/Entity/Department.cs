namespace RequestPermission.Api.Entity;

public class Department : BaseEntity
{
    public int D_ID { get; set; }
    public int D_PARENT_ID { get; set; }
    public string D_NAME { get; set; }
    public bool D_IS_ACTIVE { get; set; }
    public Guid D_MANAGER_ID { get; set; }
    public IEnumerable<Employee>? EMPLOYEES { get; set; }
    public Employee Manager { get; set; }
    public Department DepartmentDto { get; set; }
}

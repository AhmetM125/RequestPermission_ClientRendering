namespace RequestPermission.Api.Entity
{
    public class UserRole
    {
        public Guid UR_ID { get; set; }
        public string UR_NAME { get; set; }
        public Guid UR_EMP_ID { get; set; }
        public Guid UR_ROLE_ID { get; set; }
        public Employee EMPLOYEE { get; set; }
        public Role ROLE { get; set; }
    }
}

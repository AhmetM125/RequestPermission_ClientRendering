namespace RequestPermission.Api.Entity
{
    public class Role
    {
        public Guid R_ID { get; set; }
        public string R_NAME { get; set; }
        public IEnumerable<UserRole> USER_ROLES { get; set; }
        public IEnumerable<RolePermission> ROLE_PERMISSIONS { get; set; }
    }
}

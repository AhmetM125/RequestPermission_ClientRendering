namespace RequestPermission.Api.Entity
{
    public class Permission
    {
        public Guid P_ID { get; set; }
        public string P_NAME { get; set; }
        public string P_DESCRIPTION { get; set; }
        public List<RolePermission> ROLE_PERMISSION { get; set; }

    }
}

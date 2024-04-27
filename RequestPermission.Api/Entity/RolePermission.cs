namespace RequestPermission.Api.Entity
{
    public class RolePermission
    {
        public Guid RP_ID { get; set; }
        public Guid RP_ROLE_ID { get; set; }
        public Guid RP_PERMISSION_ID { get; set; }
        public Role ROLE { get; set; }
        public Permission PERMISSION { get; set; }
    }
}

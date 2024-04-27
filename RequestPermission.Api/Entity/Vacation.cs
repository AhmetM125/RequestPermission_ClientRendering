using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RequestPermission.Api.Entity
{
    public sealed class Vacation : BaseEntity
    {
        public Guid V_ID { get; set; }
        public DateTime V_START_DATE { get; set; }
        public DateTime V_END_DATE { get; set; }
        public string V_REASON { get; set; }
        public string V_TYPE { get; set; } // Paid, Unpaid, Sick, etc.

        public Guid V_EMP_ID { get; set; }
        public Employee V_EMP { get; set; }
    }
}

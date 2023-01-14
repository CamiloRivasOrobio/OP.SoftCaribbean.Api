using OP.SoftCaribbean.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace OP.SoftCaribbean.Domain.Entities
{
    public class Maestras : AuditableBaseEntity
    {
        public Maestras()
        {
            DataMaestra = new HashSet<DataMaestra>();
        }

        [Key]
        public string nmmaestro { get; set; }
        public string cdmaestro { get; set; }
        public string dsmaestro { get; set; }
        public virtual ICollection<DataMaestra> DataMaestra { get; set; }
    }
}

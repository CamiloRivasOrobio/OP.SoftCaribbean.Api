using OP.SoftCaribbean.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.SoftCaribbean.Domain.Entities
{
    public class DataMaestra : AuditableBaseEntity
    {
        [Key]
        public string nmdato { get; set; }
        public string nmmaestro { get; set; }
        public string cddato { get; set; }
        public string? dsddato { get; set; } = null;
        public string? cddato1 { get; set; } = null;
        public string? cddato2 { get; set; } = null;
        public string? cddato3 { get; set; } = null;

        public virtual Maestras nmmaestroNavigation { get; set; } = null!;
    }
}

using OP.SoftCaribbean.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.SoftCaribbean.Domain.Entities
{
    public class Pacientes : AuditableBaseEntity
    {
        public int nmid { get; set; }
        public int nmidPersona { get; set; }
        public int nmidMedicotra { get; set; }
        public string? dseps { get; set; } = null;
        public string? dsarl { get; set; } = null;
        public string? cdusuario { get; set; } = null;
        public string? dscondicion { get; set; } = null;

        public virtual Personas nmidMedicotraNavigation { get; set; } = null!;
        public virtual Personas nmidPersonaNavigation { get; set; } = null!;
    }
}

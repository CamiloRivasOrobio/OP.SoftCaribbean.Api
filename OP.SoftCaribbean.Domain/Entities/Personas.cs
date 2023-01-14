using OP.SoftCaribbean.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.SoftCaribbean.Domain.Entities
{
    public class Personas : AuditableBaseEntity
    {
        public Personas()
        {
            PacienteNmidMedicotraNavigations = new HashSet<Pacientes>();
            PacienteNmidPersonaNavigations = new HashSet<Pacientes>();
        }

        public int nmid { get; set; }
        public string cddocumento { get; set; } = null!;
        public string dsnombres { get; set; } = null!;
        public string dsapellidos { get; set; } = null!;
        public DateTime fenacimiento { get; set; }
        public string? cdtipo { get; set; } = null;
        public string? cdgenero { get; set; } = null;
        public string cdusuario { get; set; } = null!;
        public string? dsdireccion { get; set; }
        public string? dsphoto { get; set; } = null;
        public string? cdtelefonoFijo { get; set; } = null;
        public string? cdtelefonoMovil { get; set; } = null;
        public string? dsemail { get; set; } = null;

        public virtual ICollection<Pacientes> PacienteNmidMedicotraNavigations { get; set; }
        public virtual ICollection<Pacientes> PacienteNmidPersonaNavigations { get; set; }
    }
}

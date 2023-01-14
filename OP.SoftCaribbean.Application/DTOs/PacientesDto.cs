using OP.SoftCaribbean.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.SoftCaribbean.Application.DTOs
{
    public class PacientesDto
    {
        public int nmid { get; set; }
        public int nmidPersona { get; set; }
        public int nmidMedicotra { get; set; }
        public string? dseps { get; set; } = null;
        public string? dsarl { get; set; } = null;
        public string? cdusuario { get; set; } = null;
        public string? dscondicion { get; set; } = null;
        public DateTime? feregistro { get; set; }
        public DateTime? febaja { get; set; }
        public virtual Personas personaNavigation { get; set; } = null!;
        public virtual Personas medicoNavigation { get; set; } = null!;
    }
}

using OP.SoftCaribbean.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.SoftCaribbean.Application.DTOs
{
    public class PersonasDto
    {
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
        public DateTime? feregistro { get; set; }
        public DateTime? febaja { get; set; }
        public virtual DataMaestra documentoNavigation { get; set; } = null!;
        public virtual DataMaestra tipoNavigation { get; set; } = null!;
        public virtual DataMaestra generoNavigation { get; set; } = null!;
    }
}
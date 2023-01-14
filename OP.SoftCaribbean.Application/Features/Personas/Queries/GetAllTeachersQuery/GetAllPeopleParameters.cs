using OP.SoftCaribbean.Application.Parameters;

namespace OP.SoftCaribbean.Application.Features.Personas.Queries.GetAllPeopleQuery
{
    public class GetAllPeopleParameters : RequestParameter
    {
        public int? nmid { get; set; } = null;
        public string? cddocumento { get; set; } = null;
        public string? dsnombres { get; set; } = null;
        public string? dsapellidos { get; set; } = null;
        public DateTime fenacimiento { get; set; }
        public string? cdtipo { get; set; } = null;
        public string? cdgenero { get; set; } = null;
        public string? cdusuario { get; set; } = null;
        public string? dsdireccion { get; set; }
        public string? cdtelefonoFijo { get; set; } = null;
        public string? cdtelefonoMovil { get; set; } = null;
        public string? dsemail { get; set; } = null;
        public DateTime? feregistro { get; set; } = null;
        public DateTime? febaja { get; set; } = null;
    }
}
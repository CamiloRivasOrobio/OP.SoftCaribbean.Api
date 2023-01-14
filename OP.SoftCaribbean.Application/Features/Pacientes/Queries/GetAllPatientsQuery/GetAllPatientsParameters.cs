using OP.SoftCaribbean.Application.Parameters;

namespace OP.SoftCaribbean.Application.Features.Pacientes.Queries.GetAllPatientsQuery
{
    public class GetAllPatientsParameters : RequestParameter
    {
        public int? nmid { get; set; } = null;
        public int? nmidPersona { get; set; } = null;
        public int? nmidMedicotra { get; set; } = null;
        public string? dseps { get; set; } = null;
        public string? dsarl { get; set; } = null;
        public string? cdusuario { get; set; } = null;
        public string? dscondicion { get; set; } = null;
        public DateTime? feregistro { get; set; } = null;
        public DateTime? febaja { get; set; } = null;
    }
}
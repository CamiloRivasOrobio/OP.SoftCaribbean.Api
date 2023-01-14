using OP.SoftCaribbean.Application.Parameters;

namespace OP.SoftCaribbean.Application.Features.Maestras.Queries.GetAllTeachersQuery
{
    public class GetAllTeachersParameters : RequestParameter
    {
        public string? nmmaestro { get; set; } = null;
        public string? cdmaestro { get; set; } = null;
        public string? dsmaestro { get; set; } = null;
        public DateTime? feregistro { get; set; } = null;
        public DateTime? febaja { get; set; } = null;
    }
}
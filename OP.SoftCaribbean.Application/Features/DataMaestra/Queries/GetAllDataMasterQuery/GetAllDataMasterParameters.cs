using OP.SoftCaribbean.Application.Parameters;

namespace OP.SoftCaribbean.Application.Features.DataMaestra.Queries.GetAllDataMasterQuery
{
    public class GetAllDataMasterParameters : RequestParameter
    {
        public string? nmdato { get; set; } = null;
        public string? nmmaestro { get; set; } = null;
        public string? cddato { get; set; } = null;
        public string? dsddato { get; set; } = null;
        public string? cddato1 { get; set; } = null;
        public string? cddato2 { get; set; } = null;
        public string? cddato3 { get; set; } = null;
        public DateTime? feregistro { get; set; } = null;
        public DateTime? febaja { get; set; } = null;
    }
}
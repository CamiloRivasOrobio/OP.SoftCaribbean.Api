using Ardalis.Specification;
using OP.SoftCaribbean.Domain.Entities;

namespace OP.SoftCaribbean.Application.Specifications
{
    public class PagedPacientesSpecification : Specification<Pacientes>
    {
        public PagedPacientesSpecification(int pageSize, int pageNumber, int? nmid, int? nmidPersona, int? nmidMedicotra, string? dseps, string? dsarl,
            string? cdusuario, string? dscondicion, DateTime? feregistro, DateTime? febaja)
        {
            if (nmid != null && nmid != 0)
                Query.Where(x => x.nmid == nmid);

            if (nmidPersona != null && nmidPersona != 0)
                Query.Where(x => x.nmidPersona == nmidPersona);

            if (nmidMedicotra != null && nmidMedicotra != 0)
                Query.Where(x => x.nmidMedicotra == nmidMedicotra);

            if (!string.IsNullOrEmpty(dseps))
                Query.Search(x => x.dseps, "%" + dseps + "%");

            if (!string.IsNullOrEmpty(dsarl))
                Query.Search(x => x.dsarl, "%" + dsarl + "%");

            if (!string.IsNullOrEmpty(cdusuario))
                Query.Where(x => x.cdusuario == cdusuario);

            if (!string.IsNullOrEmpty(dscondicion))
                Query.Search(x => x.dscondicion, "%" + dscondicion + "%");

            Query.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
        }
    }
}

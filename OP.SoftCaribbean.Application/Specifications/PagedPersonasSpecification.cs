using Ardalis.Specification;
using OP.SoftCaribbean.Domain.Entities;

namespace OP.SoftCaribbean.Application.Specifications
{
    public class PagedPersonasSpecification : Specification<Personas>
    {
        public PagedPersonasSpecification(int pageSize, int pageNumber, int? nmid, string? cddocumento, string? dsnombres, string? dsapellidos, DateTime? fenacimiento,
            string? cdtipo, string? cdgenero, string? cdusuario, string? dsdireccion, string? cdtelefonoFijo, string? cdtelefonoMovil, string? dsemail, DateTime? feregistro, DateTime? febaja)
        {
            if (nmid != null && nmid != 0)
                Query.Where(x => x.nmid == nmid);

            if (!string.IsNullOrEmpty(cddocumento))
                Query.Where(x => x.cddocumento == cddocumento);

            if (!string.IsNullOrEmpty(dsnombres))
                Query.Search(x => x.dsnombres, "%" + dsnombres + "%");

            if (!string.IsNullOrEmpty(dsapellidos))
                Query.Search(x => x.dsapellidos, "%" + dsapellidos + "%");

            if (!string.IsNullOrEmpty(cdtipo))
                Query.Where(x => x.cdtipo == cdtipo);

            if (!string.IsNullOrEmpty(cdgenero))
                Query.Where(x => x.cdgenero == cdgenero);

            if (!string.IsNullOrEmpty(cdusuario))
                Query.Where(x => x.cdusuario == cdusuario);

            if (!string.IsNullOrEmpty(dsdireccion))
                Query.Search(x => x.dsdireccion, "%" + dsdireccion + "%");

            if (!string.IsNullOrEmpty(cdtelefonoFijo))
                Query.Search(x => x.cdtelefonoFijo, "%" + cdtelefonoFijo + "%");

            if (!string.IsNullOrEmpty(cdtelefonoMovil))
                Query.Search(x => x.cdtelefonoMovil, "%" + cdtelefonoMovil + "%");

            if (!string.IsNullOrEmpty(dsemail))
                Query.Search(x => x.dsemail, "%" + dsemail + "%");

            Query.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
        }
    }
}

using Ardalis.Specification;
using OP.SoftCaribbean.Domain.Entities;

namespace OP.SoftCaribbean.Application.Specifications
{
    public class PagedMaestrasSpecification : Specification<Maestras>
    {
        public PagedMaestrasSpecification(int pageSize, int pageNumber, string? nmmaestro, string? cdmaestro, string? dsmaestro, DateTime? feregistro, DateTime? febaja)
        {
            if (!string.IsNullOrEmpty(nmmaestro))
                Query.Where(x => x.nmmaestro == nmmaestro);

            if (!string.IsNullOrEmpty(cdmaestro))
                Query.Where(x => x.cdmaestro == cdmaestro);

            if (!string.IsNullOrEmpty(dsmaestro))
                Query.Search(x => x.dsmaestro, "%" + cdmaestro + "%");

            Query.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
        }
    }
}

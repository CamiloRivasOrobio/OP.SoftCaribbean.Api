using Ardalis.Specification;
using OP.SoftCaribbean.Domain.Entities;

namespace OP.SoftCaribbean.Application.Specifications
{
    public class PagedDataMaestraSpecification : Specification<DataMaestra>
    {
        public PagedDataMaestraSpecification(int pageSize, int pageNumber, string? nmdato, string? nmmaestro, string? cddato, string? dsddato, 
            DateTime? feregistro, DateTime? febaja)
        {
            if (!string.IsNullOrEmpty(nmdato))
                Query.Where(x => x.nmdato == nmdato);

            if (!string.IsNullOrEmpty(nmmaestro))
                Query.Where(x => x.nmmaestro == nmmaestro);

            if (!string.IsNullOrEmpty(cddato))
                Query.Where(x => x.cddato == cddato);

            if (!string.IsNullOrEmpty(dsddato))
                Query.Search(x => x.dsddato, "%" + dsddato + "%");

            Query.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
        }
    }
}

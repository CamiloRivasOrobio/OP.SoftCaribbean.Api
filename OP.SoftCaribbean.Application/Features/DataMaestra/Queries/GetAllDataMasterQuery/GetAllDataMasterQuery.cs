using AutoMapper;
using MediatR;
using OP.SoftCaribbean.Application.DTOs;
using OP.SoftCaribbean.Application.Interfaces;
using OP.SoftCaribbean.Application.Specifications;
using OP.SoftCaribbean.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.SoftCaribbean.Application.Features.DataMaestra.Queries.GetAllDataMasterQuery
{
    public class GetAllDataMasterQuery : IRequest<PagedResponse<List<DataMaestraDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? nmdato { get; set; } = null;
        public string? nmmaestro { get; set; } = null;
        public string? cddato { get; set; } = null;
        public string? dsddato { get; set; } = null;
        public string? cddato1 { get; set; } = null;
        public string? cddato2 { get; set; } = null;
        public string? cddato3 { get; set; } = null;
        public DateTime? feregistro { get; set; } = null;
        public DateTime? febaja { get; set; } = null;

        public class GetAllDataMasterQueryHandler : IRequestHandler<GetAllDataMasterQuery, PagedResponse<List<DataMaestraDto>>>
        {
            private readonly IRepositoryAsync<Domain.Entities.DataMaestra> repositoryAsync;
            private readonly IMapper _mapper;

            public GetAllDataMasterQueryHandler(IRepositoryAsync<Domain.Entities.DataMaestra> repositoryAsync, IMapper mapper)
            {
                this.repositoryAsync = repositoryAsync;
                this._mapper = mapper;
            }
            public async Task<PagedResponse<List<DataMaestraDto>>> Handle(GetAllDataMasterQuery request, CancellationToken cancellationToken)
            {
                var DataMaestra = await repositoryAsync.ListAsync(new PagedDataMaestraSpecification(
                    request.PageSize, request.PageNumber, request.nmdato, request.nmmaestro, request.cddato, request.dsddato, request.feregistro, request.febaja
                    ));
                var DataMaestraDto = _mapper.Map<List<DataMaestraDto>>(DataMaestra).OrderBy( d=> d.nmmaestro).ToList();
                var countRegister = await repositoryAsync.CountAsync();

                return new PagedResponse<List<DataMaestraDto>>(DataMaestraDto, request.PageNumber, request.PageSize, countRegister);
            }
        }
    }
}

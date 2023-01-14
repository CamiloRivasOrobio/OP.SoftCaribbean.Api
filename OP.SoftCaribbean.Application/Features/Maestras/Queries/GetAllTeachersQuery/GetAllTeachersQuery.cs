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

namespace OP.SoftCaribbean.Application.Features.Maestras.Queries.GetAllTeachersQuery
{
    public class GetAllTeachersQuery : IRequest<PagedResponse<List<MaestrasDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? nmmaestro { get; set; } = null;
        public string? cdmaestro { get; set; } = null;
        public string? dsmaestro { get; set; } = null;
        public DateTime? feregistro { get; set; } = null;
        public DateTime? febaja { get; set; } = null;

        public class GetAllTeachersQueryHandler : IRequestHandler<GetAllTeachersQuery, PagedResponse<List<MaestrasDto>>>
        {
            private readonly IRepositoryAsync<Domain.Entities.Maestras> repositoryAsync;
            private readonly IMapper _mapper;

            public GetAllTeachersQueryHandler(IRepositoryAsync<Domain.Entities.Maestras> repositoryAsync, IMapper mapper)
            {
                this.repositoryAsync = repositoryAsync;
                this._mapper = mapper;
            }
            public async Task<PagedResponse<List<MaestrasDto>>> Handle(GetAllTeachersQuery request, CancellationToken cancellationToken)
            {
                var maestras = await repositoryAsync.ListAsync(new PagedMaestrasSpecification(
                    request.PageSize, request.PageNumber, request.nmmaestro, request.cdmaestro, request.dsmaestro, request.feregistro, request.febaja
                    ));
                var maestrasDto = _mapper.Map<List<MaestrasDto>>(maestras);
                var countRegister = await repositoryAsync.CountAsync();

                return new PagedResponse<List<MaestrasDto>>(maestrasDto, request.PageNumber, request.PageSize, countRegister);
            }
        }
    }
}

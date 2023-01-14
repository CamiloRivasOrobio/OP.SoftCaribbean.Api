using AutoMapper;
using MediatR;
using OP.SoftCaribbean.Application.DTOs;
using OP.SoftCaribbean.Application.Exceptions;
using OP.SoftCaribbean.Application.Interfaces;
using OP.SoftCaribbean.Application.Wrappers;

namespace OP.SoftCaribbean.Application.Features.DataMaestra.Queries.GetDataMasterByIdQuery
{
    public class GetDataMasterByIdQuery : IRequest<Response<DataMaestraDto>>
    {
        public string nmdato { get; set; }
        public class GetDataMasterByIdQueryHandler : IRequestHandler<GetDataMasterByIdQuery, Response<DataMaestraDto>>
        {
            private readonly IRepositoryAsync<Domain.Entities.DataMaestra> repositoryAsync;
            private readonly IMapper _mapper;

            public GetDataMasterByIdQueryHandler(IRepositoryAsync<Domain.Entities.DataMaestra> repositoryAsync, IMapper mapper)
            {
                this.repositoryAsync = repositoryAsync;
                this._mapper = mapper;
            }

            public async Task<Response<DataMaestraDto>> Handle(GetDataMasterByIdQuery request, CancellationToken cancellationToken)
            {
                var maestra = await repositoryAsync.GetByIdAsync(request.nmdato);
                if (maestra == null)
                    throw new ApiException($"Registro no encontrado con el id {request.nmdato}");

                var dto = _mapper.Map<DataMaestraDto>(maestra);
                var response = new Response<DataMaestraDto>()
                {
                    Message = "El registro se ha encontrado exitosamente!",
                    Data = dto,
                    Succeeded = true
                };
                return response;
            }
        }
    }
}

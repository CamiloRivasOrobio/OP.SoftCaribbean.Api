using AutoMapper;
using MediatR;
using OP.SoftCaribbean.Application.DTOs;
using OP.SoftCaribbean.Application.Exceptions;
using OP.SoftCaribbean.Application.Interfaces;
using OP.SoftCaribbean.Application.Wrappers;

namespace OP.SoftCaribbean.Application.Features.Maestras.Queries.GetTeacherByIdQuery
{
    public class GetTeacherByIdQuery : IRequest<Response<MaestrasDto>>
    {
        public string nmmaestro { get; set; }
        public class GetTeacherByIdQueryHandler : IRequestHandler<GetTeacherByIdQuery, Response<MaestrasDto>>
        {
            private readonly IRepositoryAsync<Domain.Entities.Maestras> repositoryAsync;
            private readonly IMapper _mapper;

            public GetTeacherByIdQueryHandler(IRepositoryAsync<Domain.Entities.Maestras> repositoryAsync, IMapper mapper)
            {
                this.repositoryAsync = repositoryAsync;
                this._mapper = mapper;
            }

            public async Task<Response<MaestrasDto>> Handle(GetTeacherByIdQuery request, CancellationToken cancellationToken)
            {
                var maestra = await repositoryAsync.GetByIdAsync(request.nmmaestro);
                if (maestra == null)
                    throw new ApiException($"Registro no encontrado con el id {request.nmmaestro}");

                var dto = _mapper.Map<MaestrasDto>(maestra);
                var response = new Response<MaestrasDto>()
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

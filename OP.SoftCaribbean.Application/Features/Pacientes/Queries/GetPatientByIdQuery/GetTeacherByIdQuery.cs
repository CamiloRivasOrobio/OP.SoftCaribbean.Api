using AutoMapper;
using MediatR;
using OP.SoftCaribbean.Application.DTOs;
using OP.SoftCaribbean.Application.Exceptions;
using OP.SoftCaribbean.Application.Interfaces;
using OP.SoftCaribbean.Application.Wrappers;

namespace OP.SoftCaribbean.Application.Features.Pacientes.Queries.GetPatientByIdQuery
{
    public class GetPatientByIdQuery : IRequest<Response<PacientesDto>>
    {
        public int nmid { get; set; }
        public class GetPatientByIdQueryHandler : IRequestHandler<GetPatientByIdQuery, Response<PacientesDto>>
        {
            private readonly IRepositoryAsync<Domain.Entities.Pacientes> repositoryAsync;
            private readonly IMapper _mapper;

            public GetPatientByIdQueryHandler(IRepositoryAsync<Domain.Entities.Pacientes> repositoryAsync, IMapper mapper)
            {
                this.repositoryAsync = repositoryAsync;
                this._mapper = mapper;
            }

            public async Task<Response<PacientesDto>> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
            {
                var paciente = await repositoryAsync.GetByIdAsync(request.nmid);
                if (paciente == null)
                    throw new ApiException($"Registro no encontrado con el id {request.nmid}");

                var dto = _mapper.Map<PacientesDto>(paciente);
                var response = new Response<PacientesDto>()
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

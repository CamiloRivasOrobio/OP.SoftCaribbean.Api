using AutoMapper;
using MediatR;
using OP.SoftCaribbean.Application.DTOs;
using OP.SoftCaribbean.Application.Exceptions;
using OP.SoftCaribbean.Application.Interfaces;
using OP.SoftCaribbean.Application.Wrappers;

namespace OP.SoftCaribbean.Application.Features.Personas.Queries.GetPeopleByIdQuery
{
    public class GetPeopleByIdQuery : IRequest<Response<PersonasDto>>
    {
        public int nmid { get; set; }
        public class GetPeopleByIdQueryHandler : IRequestHandler<GetPeopleByIdQuery, Response<PersonasDto>>
        {
            private readonly IRepositoryAsync<Domain.Entities.Personas> repositoryAsync;
            private readonly IMapper _mapper;

            public GetPeopleByIdQueryHandler(IRepositoryAsync<Domain.Entities.Personas> repositoryAsync, IMapper mapper)
            {
                this.repositoryAsync = repositoryAsync;
                this._mapper = mapper;
            }

            public async Task<Response<PersonasDto>> Handle(GetPeopleByIdQuery request, CancellationToken cancellationToken)
            {
                var persona = await repositoryAsync.GetByIdAsync(request.nmid);
                if (persona == null)
                    throw new ApiException($"Registro no encontrado con el id {request.nmid}");

                var dto = _mapper.Map<PersonasDto>(persona);
                var response = new Response<PersonasDto>()
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

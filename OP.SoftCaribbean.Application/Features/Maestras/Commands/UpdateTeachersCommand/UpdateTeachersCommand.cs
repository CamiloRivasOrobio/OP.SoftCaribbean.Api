using AutoMapper;
using MediatR;
using OP.SoftCaribbean.Application.Exceptions;
using OP.SoftCaribbean.Application.Interfaces;
using OP.SoftCaribbean.Application.Wrappers;
using OP.SoftCaribbean.Domain.Entities;

namespace OP.SoftCaribbean.Application.Features.Maestras.Commands.UpdateTeachersCommand
{
    public class UpdateTeachersCommand : IRequest<Response<string>>
    {
        public string nmmaestro { get; set; }
        public string cdmaestro { get; set; }
        public string dsmaestro { get; set; }
    }
    public class UpdateTeachersCommandHandler : IRequestHandler<UpdateTeachersCommand, Response<string>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Maestras> repositoryAsync;
        private readonly IMapper _mapper;

        public UpdateTeachersCommandHandler(IRepositoryAsync<Domain.Entities.Maestras> repositoryAsync, IMapper mapper)
        {
            this.repositoryAsync = repositoryAsync;
            this._mapper = mapper;
        }

        public async Task<Response<string>> Handle(UpdateTeachersCommand request, CancellationToken cancellationToken)
        {
            var maestra = repositoryAsync.GetByIdAsync(request.nmmaestro).Result;
            if (maestra == null)
                throw new ApiException($"Registro no encontrado con el id {request.nmmaestro}");

            maestra.cdmaestro = request.cdmaestro;
            maestra.dsmaestro = request.dsmaestro;
            await repositoryAsync.UpdateAsync(maestra);
            var response = new Response<string>()
            {
                Message = "El registro se ha actualizado exitosamente!",
                Data = maestra.nmmaestro,
                Succeeded = true
            };
            return response;
        }
    }
}

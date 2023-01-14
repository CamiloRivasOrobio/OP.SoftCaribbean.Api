using AutoMapper;
using MediatR;
using OP.SoftCaribbean.Application.Exceptions;
using OP.SoftCaribbean.Application.Interfaces;
using OP.SoftCaribbean.Application.Wrappers;
using OP.SoftCaribbean.Domain.Entities;

namespace OP.SoftCaribbean.Application.Features.Maestras.Commands.DeleteTeachersCommand
{
    public class DeleteTeachersCommand : IRequest<Response<string>>
    {
        public string nmmaestro { get; set; }
    }
    public class DeleteTeachersCommandHandler : IRequestHandler<DeleteTeachersCommand, Response<string>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Maestras> repositoryAsync;
        private readonly IMapper _mapper;

        public DeleteTeachersCommandHandler(IRepositoryAsync<Domain.Entities.Maestras> repositoryAsync, IMapper mapper)
        {
            this.repositoryAsync = repositoryAsync;
            this._mapper = mapper;
        }

        public async Task<Response<string>> Handle(DeleteTeachersCommand request, CancellationToken cancellationToken)
        {
            var maestra = repositoryAsync.GetByIdAsync(request.nmmaestro).Result;
            if (maestra == null)
                throw new ApiException($"Registro no encontrado con el id {request.nmmaestro}");

            await repositoryAsync.DeleteAsync(maestra);
            var response = new Response<string>()
            {
                Message = "El registro se ha eliminado exitosamente!",
                Data = maestra.nmmaestro,
                Succeeded = true
            };
            return response;
        }
    }
}

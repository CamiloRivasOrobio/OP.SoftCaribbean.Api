using AutoMapper;
using MediatR;
using OP.SoftCaribbean.Application.Exceptions;
using OP.SoftCaribbean.Application.Interfaces;
using OP.SoftCaribbean.Application.Wrappers;

namespace OP.SoftCaribbean.Application.Features.Pacientes.Commands.DeletePatientsCommand
{
    public class DeletePatientsCommand : IRequest<Response<int>>
    {
        public int nmid { get; set; }
    }
    public class DeletePatientsCommandHandler : IRequestHandler<DeletePatientsCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Pacientes> repositoryAsync;
        private readonly IMapper _mapper;

        public DeletePatientsCommandHandler(IRepositoryAsync<Domain.Entities.Pacientes> repositoryAsync, IMapper mapper)
        {
            this.repositoryAsync = repositoryAsync;
            this._mapper = mapper;
        }

        public async Task<Response<int>> Handle(DeletePatientsCommand request, CancellationToken cancellationToken)
        {
            var paciente = repositoryAsync.GetByIdAsync(request.nmid).Result;
            if (paciente == null)
                throw new ApiException($"Registro no encontrado con el id {request.nmid}");

            await repositoryAsync.DeleteAsync(paciente);
            var response = new Response<int>()
            {
                Message = "El registro se ha eliminado exitosamente!",
                Data = paciente.nmid,
                Succeeded = true
            };
            return response;
        }
    }
}

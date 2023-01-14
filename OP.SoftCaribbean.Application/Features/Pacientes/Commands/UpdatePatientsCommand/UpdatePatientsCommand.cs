using AutoMapper;
using MediatR;
using OP.SoftCaribbean.Application.Exceptions;
using OP.SoftCaribbean.Application.Interfaces;
using OP.SoftCaribbean.Application.Wrappers;

namespace OP.SoftCaribbean.Application.Features.Pacientes.Commands.UpdatePatientsCommand
{
    public class UpdatePatientsCommand : IRequest<Response<int>>
    {
        public int nmid { get; set; }
        public int nmidPersona { get; set; }
        public int nmidMedicotra { get; set; }
        public string? dseps { get; set; } = null;
        public string? dsarl { get; set; } = null;
        public string? cdusuario { get; set; } = null;
        public string? dscondicion { get; set; } = null;
    }
    public class UpdatePatientsCommandHandler : IRequestHandler<UpdatePatientsCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Pacientes> repositoryAsync;
        private readonly IMapper _mapper;

        public UpdatePatientsCommandHandler(IRepositoryAsync<Domain.Entities.Pacientes> repositoryAsync, IMapper mapper)
        {
            this.repositoryAsync = repositoryAsync;
            this._mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdatePatientsCommand request, CancellationToken cancellationToken)
        {
            var maestra = repositoryAsync.GetByIdAsync(request.nmid).Result;
            if (maestra == null)
                throw new ApiException($"Registro no encontrado con el id {request.nmid}");

            maestra.nmidPersona = request.nmidPersona;
            maestra.nmidMedicotra = request.nmidMedicotra;
            maestra.dseps = request.dseps;
            maestra.dsarl = request.dsarl;
            maestra.cdusuario = request.cdusuario;
            maestra.dscondicion = request.dscondicion;
            await repositoryAsync.UpdateAsync(maestra);
            var response = new Response<int>()
            {
                Message = "El registro se ha actualizado exitosamente!",
                Data = maestra.nmid,
                Succeeded = true
            };
            return response;
        }
    }
}

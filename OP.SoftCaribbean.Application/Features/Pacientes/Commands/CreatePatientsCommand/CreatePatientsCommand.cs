using AutoMapper;
using MediatR;
using OP.SoftCaribbean.Application.Interfaces;
using OP.SoftCaribbean.Application.Wrappers;

namespace OP.SoftCaribbean.Application.Features.Pacientes.Commands.CreatePatientsCommand
{
    public class CreatePatientsCommand : IRequest<Response<int>>
    {
        public int nmid { get; set; }
        public int nmidPersona { get; set; }
        public int nmidMedicotra { get; set; }
        public string? dseps { get; set; } = null;
        public string? dsarl { get; set; } = null;
        public string? cdusuario { get; set; } = null;
        public string? dscondicion { get; set; } = null;
    }
    public class CreatePatientsCommandHandler : IRequestHandler<CreatePatientsCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Pacientes> repositoryAsync;
        private readonly IMapper _mapper;

        public CreatePatientsCommandHandler(IRepositoryAsync<Domain.Entities.Pacientes> repositoryAsync, IMapper mapper)
        {
            this.repositoryAsync = repositoryAsync;
            this._mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreatePatientsCommand request, CancellationToken cancellationToken)
        {
            var newRegister = new Domain.Entities.Pacientes()
            {
                nmid = 0,
                nmidPersona = request.nmidPersona,
                nmidMedicotra = request.nmidMedicotra,
                dsarl = request.dsarl,
                dseps = request.dseps,
                dscondicion = request.dscondicion,
                cdusuario = request.cdusuario
            };
            var data = await repositoryAsync.AddAsync(newRegister);
            var response = new Response<int>()
            {
                Message = "El registro se ha realizado exitosamente!",
                Data = data.nmid,
                Succeeded = true
            };
            return response;
        }
    }
}

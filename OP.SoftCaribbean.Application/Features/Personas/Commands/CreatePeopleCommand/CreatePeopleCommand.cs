using AutoMapper;
using MediatR;
using OP.SoftCaribbean.Application.Interfaces;
using OP.SoftCaribbean.Application.Wrappers;
using OP.SoftCaribbean.Domain.Entities;

namespace OP.SoftCaribbean.Application.Features.Personas.Commands.CreatePeopleCommand
{
    public class CreatePeopleCommand : IRequest<Response<int>>
    {
        public int nmid { get; set; }
        public string cddocumento { get; set; } = null!;
        public string dsnombres { get; set; } = null!;
        public string dsapellidos { get; set; } = null!;
        public DateTime fenacimiento { get; set; }
        public string? cdtipo { get; set; } = null;
        public string? cdgenero { get; set; } = null;
        public string cdusuario { get; set; } = null!;
        public string? dsdireccion { get; set; }
        public string? dsphoto { get; set; } = null;
        public string? cdtelefonoFijo { get; set; } = null;
        public string? cdtelefonoMovil { get; set; } = null;
        public string? dsemail { get; set; } = null;
    }
    public class CreatePeopleCommandHandler : IRequestHandler<CreatePeopleCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Personas> repositoryAsync;
        private readonly IMapper _mapper;

        public CreatePeopleCommandHandler(IRepositoryAsync<Domain.Entities.Personas> repositoryAsync, IMapper mapper)
        {
            this.repositoryAsync = repositoryAsync;
            this._mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreatePeopleCommand request, CancellationToken cancellationToken)
        {
            var newRegister = _mapper.Map<Domain.Entities.Personas>(request);
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

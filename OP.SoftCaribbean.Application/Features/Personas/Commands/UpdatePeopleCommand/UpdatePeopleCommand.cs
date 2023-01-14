using AutoMapper;
using MediatR;
using OP.SoftCaribbean.Application.Exceptions;
using OP.SoftCaribbean.Application.Interfaces;
using OP.SoftCaribbean.Application.Wrappers;

namespace OP.SoftCaribbean.Application.Features.Personas.Commands.UpdatePeopleCommand
{
    public class UpdatePeopleCommand : IRequest<Response<int>>
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
    public class UpdatePeopleCommandHandler : IRequestHandler<UpdatePeopleCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Personas> repositoryAsync;
        private readonly IMapper _mapper;

        public UpdatePeopleCommandHandler(IRepositoryAsync<Domain.Entities.Personas> repositoryAsync, IMapper mapper)
        {
            this.repositoryAsync = repositoryAsync;
            this._mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdatePeopleCommand request, CancellationToken cancellationToken)
        {
            var maestra = repositoryAsync.GetByIdAsync(request.nmid).Result;
            if (maestra == null)
                throw new ApiException($"Registro no encontrado con el id {request.nmid}");

            maestra.cddocumento = request.cddocumento;
            maestra.dsnombres = request.dsnombres;
            maestra.dsapellidos = request.dsapellidos;
            maestra.fenacimiento = request.fenacimiento;
            maestra.cdtipo = request.cdtipo;
            maestra.cdgenero = request.cdgenero;
            maestra.cdusuario = request.cdusuario;
            maestra.dsdireccion = request.dsdireccion;
            maestra.dsphoto = request.dsphoto;
            maestra.cdtelefonoFijo = request.cdtelefonoFijo;
            maestra.dsemail = request.dsemail;
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

using AutoMapper;
using MediatR;
using OP.SoftCaribbean.Application.Exceptions;
using OP.SoftCaribbean.Application.Interfaces;
using OP.SoftCaribbean.Application.Wrappers;
using OP.SoftCaribbean.Domain.Entities;

namespace OP.SoftCaribbean.Application.Features.DataMaestra.Commands.UpdateDataMasterCommand
{
    public class UpdateDataMasterCommand : IRequest<Response<string>>
    {
        public string nmdato { get; set; }
        public string nmmaestro { get; set; }
        public string cddato { get; set; }
        public string? dsddato { get; set; } = null;
        public string? cddato1 { get; set; } = null;
        public string? cddato2 { get; set; } = null;
        public string? cddato3 { get; set; } = null;
    }
    public class UpdateDataMasterCommandHandler : IRequestHandler<UpdateDataMasterCommand, Response<string>>
    {
        private readonly IRepositoryAsync<Domain.Entities.DataMaestra> repositoryAsync;
        private readonly IMapper _mapper;

        public UpdateDataMasterCommandHandler(IRepositoryAsync<Domain.Entities.DataMaestra> repositoryAsync, IMapper mapper)
        {
            this.repositoryAsync = repositoryAsync;
            this._mapper = mapper;
        }

        public async Task<Response<string>> Handle(UpdateDataMasterCommand request, CancellationToken cancellationToken)
        {
            var maestra = repositoryAsync.GetByIdAsync(request.nmdato).Result;
            if (maestra == null)
                throw new ApiException($"Registro no encontrado con el id {request.nmdato}");

            maestra.nmmaestro = request.nmmaestro;
            maestra.cddato = request.cddato;
            maestra.dsddato = request.dsddato;
            maestra.cddato1 = request.cddato1;
            maestra.cddato2 = request.cddato2;
            maestra.cddato3 = request.cddato3;
            await repositoryAsync.UpdateAsync(maestra);
            var response = new Response<string>()
            {
                Message = "El registro se ha actualizado exitosamente!",
                Data = maestra.nmdato,
                Succeeded = true
            };
            return response;
        }
    }
}

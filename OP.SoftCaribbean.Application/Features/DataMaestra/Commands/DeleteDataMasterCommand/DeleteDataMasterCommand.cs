using AutoMapper;
using MediatR;
using OP.SoftCaribbean.Application.Exceptions;
using OP.SoftCaribbean.Application.Interfaces;
using OP.SoftCaribbean.Application.Wrappers;
using OP.SoftCaribbean.Domain.Entities;

namespace OP.SoftCaribbean.Application.Features.DataMaestra.Commands.DeleteDataMasterCommand
{
    public class DeleteDataMasterCommand : IRequest<Response<string>>
    {
        public string nmdato { get; set; }
    }
    public class DeleteDataMasterCommandHandler : IRequestHandler<DeleteDataMasterCommand, Response<string>>
    {
        private readonly IRepositoryAsync<Domain.Entities.DataMaestra> repositoryAsync;
        private readonly IMapper _mapper;

        public DeleteDataMasterCommandHandler(IRepositoryAsync<Domain.Entities.DataMaestra> repositoryAsync, IMapper mapper)
        {
            this.repositoryAsync = repositoryAsync;
            this._mapper = mapper;
        }

        public async Task<Response<string>> Handle(DeleteDataMasterCommand request, CancellationToken cancellationToken)
        {
            var maestra = repositoryAsync.GetByIdAsync(request.nmdato).Result;
            if (maestra == null)
                throw new ApiException($"Registro no encontrado con el id {request.nmdato}");

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

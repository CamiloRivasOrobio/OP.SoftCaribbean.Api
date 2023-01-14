using AutoMapper;
using MediatR;
using OP.SoftCaribbean.Application.Exceptions;
using OP.SoftCaribbean.Application.Interfaces;
using OP.SoftCaribbean.Application.Wrappers;

namespace OP.SoftCaribbean.Application.Features.Personas.Commands.DeletePeopleCommand
{
    public class DeletePeopleCommand : IRequest<Response<int>>
    {
        public int nmid { get; set; }
    }
    public class DeletePeopleCommandHandler : IRequestHandler<DeletePeopleCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Personas> repositoryAsync;
        private readonly IMapper _mapper;

        public DeletePeopleCommandHandler(IRepositoryAsync<Domain.Entities.Personas> repositoryAsync, IMapper mapper)
        {
            this.repositoryAsync = repositoryAsync;
            this._mapper = mapper;
        }

        public async Task<Response<int>> Handle(DeletePeopleCommand request, CancellationToken cancellationToken)
        {
            var maestra = repositoryAsync.GetByIdAsync(request.nmid).Result;
            if (maestra == null)
                throw new ApiException($"Registro no encontrado con el id {request.nmid}");

            await repositoryAsync.DeleteAsync(maestra);
            var response = new Response<int>()
            {
                Message = "El registro se ha eliminado exitosamente!",
                Data = maestra.nmid,
                Succeeded = true
            };
            return response;
        }
    }
}

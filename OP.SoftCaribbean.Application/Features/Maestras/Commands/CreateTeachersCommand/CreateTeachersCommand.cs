using AutoMapper;
using MediatR;
using OP.SoftCaribbean.Application.Interfaces;
using OP.SoftCaribbean.Application.Wrappers;
using OP.SoftCaribbean.Domain.Entities;

namespace OP.SoftCaribbean.Application.Features.Maestras.Commands.CreateTeachersCommand
{
    public class CreateTeachersCommand : IRequest<Response<string>>
    {
        public string nmmaestro { get; set; }
        public string cdmaestro { get; set; }
        public string dsmaestro { get; set; }
    }
    public class CreateTeachersCommandHandler : IRequestHandler<CreateTeachersCommand, Response<string>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Maestras> repositoryAsync;
        private readonly IMapper _mapper;

        public CreateTeachersCommandHandler(IRepositoryAsync<Domain.Entities.Maestras> repositoryAsync, IMapper mapper)
        {
            this.repositoryAsync = repositoryAsync;
            this._mapper = mapper;
        }

        public async Task<Response<string>> Handle(CreateTeachersCommand request, CancellationToken cancellationToken)
        {
            var newRegister = _mapper.Map<Domain.Entities.Maestras>(request);
            var data = await repositoryAsync.AddAsync(newRegister);
            var response = new Response<string>()
            {
                Message = "El registro se ha realizado exitosamente!",
                Data = data.nmmaestro,
                Succeeded = true 
            };
            return response;
        }
    }
}

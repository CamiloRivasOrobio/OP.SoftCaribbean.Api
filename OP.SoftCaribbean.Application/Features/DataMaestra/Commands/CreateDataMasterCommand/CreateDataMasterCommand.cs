using AutoMapper;
using MediatR;
using OP.SoftCaribbean.Application.Interfaces;
using OP.SoftCaribbean.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.SoftCaribbean.Application.Features.DataMaestra.Commands.CreateDataMasterCommand
{
    public class CreateDataMasterCommand : IRequest<Response<string>>
    {
        public string nmdato { get; set; }
        public string nmmaestro { get; set; }
        public string cddato { get; set; }
        public string? dsddato { get; set; } = null;
        public string? cddato1 { get; set; } = null;
        public string? cddato2 { get; set; } = null;
        public string? cddato3 { get; set; } = null;
    }
    public class CreateDataMasterCommandHandler : IRequestHandler<CreateDataMasterCommand, Response<string>>
    {
        private readonly IRepositoryAsync<Domain.Entities.DataMaestra> repositoryAsync;
        private readonly IMapper _mapper;

        public CreateDataMasterCommandHandler(IRepositoryAsync<Domain.Entities.DataMaestra> repositoryAsync, IMapper mapper)
        {
            this.repositoryAsync = repositoryAsync;
            this._mapper = mapper;
        }

        public async Task<Response<string>> Handle(CreateDataMasterCommand request, CancellationToken cancellationToken)
        {
            var newRegister = _mapper.Map<Domain.Entities.DataMaestra>(request);
            var data = await repositoryAsync.AddAsync(newRegister);
            var response = new Response<string>()
            {
                Message = "El registro se ha realizado exitosamente!",
                Data = data.nmdato,
                Succeeded = true
            };
            return response;
        }
    }
}
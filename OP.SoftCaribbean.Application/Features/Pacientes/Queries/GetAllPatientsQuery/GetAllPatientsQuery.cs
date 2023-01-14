using AutoMapper;
using MediatR;
using OP.SoftCaribbean.Application.DTOs;
using OP.SoftCaribbean.Application.Interfaces;
using OP.SoftCaribbean.Application.Specifications;
using OP.SoftCaribbean.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.SoftCaribbean.Application.Features.Pacientes.Queries.GetAllPatientsQuery
{
    public class GetAllPatientsQuery : IRequest<PagedResponse<List<PacientesDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? nmid { get; set; } = null;
        public int? nmidPersona { get; set; } = null;
        public int? nmidMedicotra { get; set; } = null;
        public string? dseps { get; set; } = null;
        public string? dsarl { get; set; } = null;
        public string? cdusuario { get; set; } = null;
        public string? dscondicion { get; set; } = null;
        public DateTime? feregistro { get; set; } = null;
        public DateTime? febaja { get; set; } = null;

        public class GetAllPatientsQueryHandler : IRequestHandler<GetAllPatientsQuery, PagedResponse<List<PacientesDto>>>
        {
            private readonly IRepositoryAsync<Domain.Entities.Pacientes> repositoryAsync;
            private readonly IRepositoryAsync<Domain.Entities.Personas> repositoryPeopleAsync;
            private readonly IMapper _mapper;

            public GetAllPatientsQueryHandler(IRepositoryAsync<Domain.Entities.Pacientes> repositoryAsync, IMapper mapper, IRepositoryAsync<Domain.Entities.Personas> repositoryPeopleAsync)
            {
                this.repositoryAsync = repositoryAsync;
                this._mapper = mapper;
                this.repositoryPeopleAsync = repositoryPeopleAsync;
            }
            public async Task<PagedResponse<List<PacientesDto>>> Handle(GetAllPatientsQuery request, CancellationToken cancellationToken)
            {
                var Pacientes = await repositoryAsync.ListAsync(new PagedPacientesSpecification(
                    request.PageSize, request.PageNumber, request.nmid, request.nmidPersona, request.nmidMedicotra, request.dseps, request.dsarl,
                    request.cdusuario, request.dscondicion, request.feregistro, request.febaja
                    ));
                //var PacientesDto = _mapper.Map<List<PacientesDto>>(Pacientes);
                var PacientesDto = (from data in Pacientes
                                    select new PacientesDto
                                    {
                                        nmid = data.nmid,
                                        nmidPersona = data.nmidPersona,
                                        nmidMedicotra = data.nmidMedicotra,
                                        dsarl = data.dsarl,
                                        dseps = data.dseps,
                                        dscondicion = data.dscondicion,
                                        cdusuario = data.cdusuario,
                                        personaNavigation = repositoryPeopleAsync.GetByIdAsync(data.nmidPersona).Result,
                                        medicoNavigation = repositoryPeopleAsync.GetByIdAsync(data.nmidMedicotra).Result
                                    }).ToList();
                var countRegister = await repositoryAsync.CountAsync();

                return new PagedResponse<List<PacientesDto>>(PacientesDto, request.PageNumber, request.PageSize, countRegister);
            }
        }
    }
}

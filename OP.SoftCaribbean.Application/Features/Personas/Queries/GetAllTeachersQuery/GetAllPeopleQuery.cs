using AutoMapper;
using MediatR;
using OP.SoftCaribbean.Application.DTOs;
using OP.SoftCaribbean.Application.Interfaces;
using OP.SoftCaribbean.Application.Specifications;
using OP.SoftCaribbean.Application.Wrappers;

namespace OP.SoftCaribbean.Application.Features.Personas.Queries.GetAllPeopleQuery
{
    public class GetAllPeopleQuery : IRequest<PagedResponse<List<PersonasDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? nmid { get; set; } = null;
        public string? cddocumento { get; set; } = null;
        public string? dsnombres { get; set; } = null;
        public string? dsapellidos { get; set; } = null;
        public DateTime fenacimiento { get; set; }
        public string? cdtipo { get; set; } = null;
        public string? cdgenero { get; set; } = null;
        public string? cdusuario { get; set; } = null;
        public string? dsdireccion { get; set; }
        public string? cdtelefonoFijo { get; set; } = null;
        public string? cdtelefonoMovil { get; set; } = null;
        public string? dsemail { get; set; } = null;
        public DateTime? feregistro { get; set; } = null;
        public DateTime? febaja { get; set; } = null;

        public class GetAllPeopleQueryHandler : IRequestHandler<GetAllPeopleQuery, PagedResponse<List<PersonasDto>>>
        {
            private readonly IRepositoryAsync<Domain.Entities.Personas> repositoryAsync;
            private readonly IRepositoryAsync<Domain.Entities.DataMaestra> repositoryDataMaestraAsync;
            private readonly IMapper _mapper;

            public GetAllPeopleQueryHandler(IRepositoryAsync<Domain.Entities.Personas> repositoryAsync, IMapper mapper, IRepositoryAsync<Domain.Entities.DataMaestra> repositoryDataMaestraAsync)
            {
                this.repositoryAsync = repositoryAsync;
                this._mapper = mapper;
                this.repositoryDataMaestraAsync = repositoryDataMaestraAsync;
            }
            public async Task<PagedResponse<List<PersonasDto>>> Handle(GetAllPeopleQuery request, CancellationToken cancellationToken)
            {
                var personas = await repositoryAsync.ListAsync(new PagedPersonasSpecification(
                    request.PageSize, request.PageNumber, request.nmid, request.cddocumento, request.dsnombres, request.dsapellidos, request.fenacimiento, request.cdtipo, request.cdgenero,
                    request.cdusuario, request.dsdireccion, request.cdtelefonoFijo, request.cdtelefonoMovil, request.dsemail, request.feregistro, request.febaja
                    ));
                //var personasDto = _mapper.Map<List<PersonasDto>>(personas);
                //var documentos = repositoryDataMaestraAsync.GetByIdAsync()
                var personasDto = (from data in personas
                                   select new PersonasDto
                                   {
                                       nmid = data.nmid,
                                       cddocumento = data.cddocumento,
                                       dsnombres = data.dsnombres,
                                       dsapellidos = data.dsapellidos,
                                       fenacimiento = data.fenacimiento,
                                       cdtipo = data.cdtipo,
                                       cdgenero = data.cdgenero,
                                       cdusuario = data.cdusuario,
                                       dsdireccion = data.dsdireccion,
                                       dsphoto = data.dsphoto,
                                       cdtelefonoFijo = data.cdtelefonoFijo,
                                       cdtelefonoMovil = data.cdtelefonoMovil,
                                       dsemail = data.dsemail,
                                       feregistro = data.feregistro,
                                       febaja = data.febaja,
                                       documentoNavigation = repositoryDataMaestraAsync.GetByIdAsync(data.cddocumento).Result,
                                       tipoNavigation = repositoryDataMaestraAsync.GetByIdAsync(data.cdtipo).Result,
                                       generoNavigation = repositoryDataMaestraAsync.GetByIdAsync(data.cdgenero).Result
                                   }).ToList();
                var countRegister = await repositoryAsync.CountAsync();

                return new PagedResponse<List<PersonasDto>>(personasDto, request.PageNumber, request.PageSize, countRegister);
            }
        }
    }
}

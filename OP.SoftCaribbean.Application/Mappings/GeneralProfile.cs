using AutoMapper;
using OP.SoftCaribbean.Application.DTOs;
using OP.SoftCaribbean.Application.Features.DataMaestra.Commands.CreateDataMasterCommand;
using OP.SoftCaribbean.Application.Features.Maestras.Commands.CreateTeachersCommand;
using OP.SoftCaribbean.Application.Features.Personas.Commands.CreatePeopleCommand;
using OP.SoftCaribbean.Domain.Entities;

namespace OP.SoftCaribbean.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region DTOs
            CreateMap<Maestras, MaestrasDto>();
            CreateMap<DataMaestra, DataMaestraDto>();
            CreateMap<Personas, PersonasDto>();
            CreateMap<Pacientes, PacientesDto>();
            #endregion

            #region Commands
            CreateMap<CreateTeachersCommand, Maestras>();
            CreateMap<CreateDataMasterCommand, DataMaestra>();
            CreateMap<CreatePeopleCommand, Personas>();
            #endregion
        }
    }
}

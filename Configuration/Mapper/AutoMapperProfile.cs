using AutoMapper;
using consulta_viva_API2.Models;
using consulta_viva_API2.Models.Dto;
using consulta_viva_API2.Models.Enums;

namespace consulta_viva_API2.Configuration.Mapper {
    public class AutoMapperProfile : Profile {
        public AutoMapperProfile() {
            CreateMap<MedicoDto, Medico>();
            CreateMap<PacienteDto, Paciente>();

            CreateMap<ConsultaDto, Consulta>()
                .ForMember(consulta => consulta.Status, opt => 
                    opt.MapFrom(dto => dto.Status.ToString()));

            CreateMap<Consulta, ConsultaDto>()
                .ForMember(dto => dto.Status, opt => 
                    opt.MapFrom(consulta => Enum.Parse<StatusConsulta>(consulta.Status)));
        }
    }
}

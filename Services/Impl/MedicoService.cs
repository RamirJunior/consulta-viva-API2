using AutoMapper;
using consulta_viva_API2.Configuration.Util;
using consulta_viva_API2.Models;
using consulta_viva_API2.Models.Dto;
using consulta_viva_API2.Repositories;

namespace consulta_viva_API2.Services.Impl {
    public class MedicoService : IMedicoService {

        private readonly IMedicoRepository _repository;
        private readonly IMapper _mapper;

        public MedicoService(IMedicoRepository iUserRepository) => _repository = iUserRepository;
        public MedicoService(IMapper mapper) => _mapper = mapper;

        public ConsultaDto? AtenderConsulta(int consultaId) {
            var consulta = _repository.Atender(consultaId);
            if (consulta == null)
                return null;

            var consultaAtualizada = AtualizarStatusConsulta(consulta);
            consulta = _repository.AtualizarConsulta(consultaAtualizada);
            return _mapper.Map<ConsultaDto>(consulta);
        }

        public List<ConsultaDto> ListarConsultas() {
            List<ConsultaDto> consultasDto = new List<ConsultaDto>();
            var consultas = _repository.ListarConsultas();

            consultas.ForEach(consulta =>
                consultasDto.Add(_mapper.Map<ConsultaDto>(consulta)));

            return consultasDto;
        }

        public List<MedicoDto> ListarMedicos() {
            List<MedicoDto> medicosDto = new List<MedicoDto>();
            var medicos = _repository.ListarMedicos();

            medicos.ForEach(medico =>
                medicosDto.Add(_mapper.Map<MedicoDto>(medico)));

            return medicosDto;
        }

        public MedicoDto SalvarMedico(MedicoDto medicoDto) {
            var medico = _mapper.Map<Medico>(medicoDto); 
            _repository.SalvarMedico(medico);
            return medicoDto;
        }

        private Consulta AtualizarStatusConsulta(Consulta consulta) {
            consulta.Status =
                consulta.Status switch {
                    Constants.Finalizado => consulta.Status,
                    Constants.EmAtendimento => Constants.Finalizado,
                    _ => Constants.EmAtendimento
                };
            return consulta;
        }
    }
}

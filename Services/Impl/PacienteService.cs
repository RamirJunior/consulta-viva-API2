using AutoMapper;
using consulta_viva_API2.Configuration.Util;
using consulta_viva_API2.Models;
using consulta_viva_API2.Models.Dto;
using consulta_viva_API2.Repositories;

namespace consulta_viva_API2.Services.Impl {
    public class PacienteService : IPacienteService {

        private readonly IPacienteRepository _repository;
        private readonly IMapper _mapper;

        public PacienteService(IPacienteRepository pacienteRepository) => _repository = pacienteRepository;
        public PacienteService(IMapper mapper) => _mapper = mapper;
        
        public PacienteDto AdicionarPaciente(PacienteDto pacienteDto) {
            var paciente = _mapper.Map<Paciente>(pacienteDto);
            _repository.AdicionarPaciente(paciente);
            return pacienteDto;
        }

        public List<ConsultaDto> BuscarConsultaPorPaciente(int pacienteId) {

            List<ConsultaDto> consultasDto = new List<ConsultaDto>();
            var consultas = _repository.BuscarConsultaPorPaciente(pacienteId);

            consultas.ForEach(consulta =>
                consultasDto.Add(_mapper.Map<ConsultaDto>(consulta)));

            return consultasDto;
        }

        public List<PacienteDto> ListarPacientes() {
            List<PacienteDto> pacientesDto = new List<PacienteDto>();
            var pacientes = _repository.ListarPacientes();
            
            pacientes.ForEach(paciente =>
                pacientesDto.Add(_mapper.Map<PacienteDto>(paciente)));

            return pacientesDto;
        }

        public Consulta? MarcarConsulta(int pacienteId, Consulta consulta) {
            Paciente paciente = _repository.BuscarPacientePorId(pacienteId);
            if (paciente == null) 
                return null;
             
            consulta.PacienteId = (int)paciente.PacienteId;
            var consultaVinculada = VincularPacienteConsulta(paciente, consulta);
            return _repository.SalvarConsulta(consultaVinculada);
        }

        private Consulta VincularPacienteConsulta(Paciente paciente, Consulta consulta) {
            consulta.Paciente = paciente;
            consulta.Status = Constants.Aguardando;
            return consulta;
        }
    }
}

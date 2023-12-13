using consulta_viva_API2.Models;
using consulta_viva_API2.Repositories;

namespace consulta_viva_API2.Services.Impl {
    public class PacienteService : IPacienteService {

        private readonly IPacienteRepository _repository;

        public PacienteService(IPacienteRepository pacienteRepository) {
            _repository = pacienteRepository;
        }

        public Paciente AdicionarPaciente(Paciente paciente) {
            return _repository.AdicionarPaciente(paciente);
        }

        public List<Consulta> BuscarConsultaPorPaciente(int pacienteId) {
            throw new NotImplementedException();
        }

        public List<Paciente> ListarPacientes() {
            return _repository.ListarPacientes();
        }

        public Paciente MarcarConsulta(int pacienteId) {
            throw new NotImplementedException();
        }
    }
}

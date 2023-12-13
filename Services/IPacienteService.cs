using consulta_viva_API2.Models;

namespace consulta_viva_API2.Services {
    public interface IPacienteService {
        public Paciente AdicionarPaciente(Paciente paciente);
        public Consulta MarcarConsulta(int pacienteId, Consulta consulta);
        public List<Consulta> BuscarConsultaPorPaciente(int pacienteId);
        public List<Paciente> ListarPacientes();
    }
}

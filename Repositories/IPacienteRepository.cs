using consulta_viva_API2.Models;

namespace consulta_viva_API2.Repositories {
    public interface IPacienteRepository {

        public Paciente AdicionarPaciente(Paciente paciente);
        public Consulta MarcarConsulta(Consulta consulta);
        public List<Consulta> BuscarConsultaPorPaciente(int pacienteId);
        public List<Paciente> ListarPacientes();
    }
}

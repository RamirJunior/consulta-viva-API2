using consulta_viva_API2.Models;

namespace consulta_viva_API2.Repositories {
    public interface IPacienteRepository {

        public Paciente AdicionarPaciente(Paciente paciente);
        public List<Consulta> BuscarConsultaPorPaciente(int pacienteId);
        public Paciente? BuscarPacientePorId(int pacienteId);
        public List<Paciente> ListarPacientes();
        public Consulta SalvarConsulta(Consulta consulta);
    }
}

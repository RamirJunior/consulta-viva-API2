using consulta_viva_API2.Models;
using consulta_viva_API2.Models.Dto;

namespace consulta_viva_API2.Services {
    public interface IPacienteService {
        public PacienteDto AdicionarPaciente(Paciente paciente);
        public ConsultaDto MarcarConsulta(int pacienteId, ConsultaDto consultaDto);
        public List<ConsultaDto> BuscarConsultaPorPaciente(int pacienteId);
        public List<PacienteDto> ListarPacientes();
    }
}

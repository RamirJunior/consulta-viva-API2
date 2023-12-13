using consulta_viva_API2.Models.Enums;

namespace consulta_viva_API2.Models {
    public class Consulta {
        public int? ConsultaId { get; set; }
        public int? MedicoId { get; set; }
        public Medico? Medico { get; set; }
        public int PacienteId { get; set; }
        public DateTime DataConsulta { get; set; }
        public Paciente Paciente { get; set; }
        public string Status { get; set; }
    }
}

using consulta_viva_API2.Models.Enums;

namespace consulta_viva_API2.Models.Dto {
    public class ConsultaDto {
        public int? ConsultaId { get; set; }
        public int MedicoId { get; set; }
        public int PacienteId { get; set; }
        public DateTime DataConsulta { get; set; }
        public StatusConsulta Status { get; set; } = StatusConsulta.Aguardando;
    }
}

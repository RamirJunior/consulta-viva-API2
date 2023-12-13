namespace consulta_viva_API2.Models {
    public class Paciente {
        public int PacienteId { get; set; }
        public string Nome { get; set; }
        public ICollection<Consulta> Consultas { get; set; }
    }
}

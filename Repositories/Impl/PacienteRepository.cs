using consulta_viva_API2.Data;
using consulta_viva_API2.Models;

namespace consulta_viva_API2.Repositories.Impl {
    public class PacienteRepository : IPacienteRepository {

        private readonly ApplicationDbContext _context;

        public PacienteRepository(ApplicationDbContext applicationDbContext) => _context = applicationDbContext;

        public Paciente AdicionarPaciente(Paciente paciente) {
            _context.Pacientes.Add(paciente);
            _context.SaveChanges();
            return paciente;
        }

        public Consulta SalvarConsulta(Consulta consulta) {
            _context.Consultas.Add(consulta);
            _context.SaveChanges();
            return consulta;
        }

        public List<Consulta> BuscarConsultaPorPaciente(int pacienteId) {
            return _context.Consultas.Where(c => c.PacienteId == pacienteId).ToList();
        }

        public List<Paciente> ListarPacientes() {
            return _context.Pacientes.ToList();
        }

        public Paciente? BuscarPacientePorId(int pacienteId) {
            return _context.Pacientes.Find(pacienteId);
        }
    }
}

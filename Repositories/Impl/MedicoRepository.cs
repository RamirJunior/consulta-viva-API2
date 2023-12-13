using consulta_viva_API2.Data;
using consulta_viva_API2.Models;

namespace consulta_viva_API2.Repositories.Impl {
    public class MedicoRepository : IMedicoRepository {

        private readonly ApplicationDbContext _context;

        public MedicoRepository(ApplicationDbContext applicationDbContext) {
            _context = applicationDbContext;
        }

        public Consulta? Atender(int consultaId) {
            return _context.Consultas.Find(consultaId);
        }

        public Consulta AtualizarConsulta(Consulta consulta) {
            _context.Consultas.Update(consulta);
            _context.SaveChanges();
            return consulta;
        }

        public List<Consulta> ListarConsultas() {
            return _context.Consultas.ToList();
        }

        public List<Medico> ListarMedicos() {
            return _context.Medicos.ToList();
        }

        public Medico SalvarMedico(Medico medico) {
            _context.Medicos.Add(medico);
            _context.SaveChanges();
            return medico;
        }

        internal void SalvarRegistro() {
            _context.SaveChanges(true);
        }
    }
}

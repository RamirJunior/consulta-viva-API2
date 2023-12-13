using consulta_viva_API2.Models;
using Microsoft.EntityFrameworkCore;

namespace consulta_viva_API2.Repositories {
    public interface IMedicoRepository {

        public Medico SalvarMedico(Medico medico);
        public List<Medico> ListarMedicos();
        Consulta? Atender(int consultaId);
    }
}

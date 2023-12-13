using consulta_viva_API2.Models;
using consulta_viva_API2.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace consulta_viva_API2.Repositories {
    public interface IMedicoRepository {

        public Medico SalvarMedico(Medico medico);
        public List<Medico> ListarMedicos();
        public Consulta? Atender(int consultaId);
        public List<Consulta> ListarConsultas();
        public Consulta AtualizarConsulta(Consulta consulta);
    }
}

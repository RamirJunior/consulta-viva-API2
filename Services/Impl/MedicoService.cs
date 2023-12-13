using consulta_viva_API2.Models;
using consulta_viva_API2.Repositories;
using consulta_viva_API2.Repositories.Impl;

namespace consulta_viva_API2.Services.Impl
{
    public class MedicoService : IMedicoService {

        private readonly IMedicoRepository _repository;

        public MedicoService(IMedicoRepository iUserRepository) {
            _repository = iUserRepository;
        }

        public Consulta? Atender(int consultaId) {
            var consulta = _repository.Atender(consultaId);
            if(consulta != null)
                AtualizarStatus(consulta);
            
            // TODO: salvar consulta atualizada no banco
            return consulta;
        }

        public List<Medico> ListarMedicos() {
            return _repository.ListarMedicos();
        }

        public Medico SalvarMedico(Medico medico) {
            return _repository.SalvarMedico(medico);
        }

        private Consulta AtualizarStatus(Consulta consulta) {
            if(consulta.Status == Models.Enums.StatusConsulta.Finalizada)
                return consulta;
            
            consulta.Status = Models.Enums.StatusConsulta.EmAtendimento;
            return consulta;
        }
    }
}

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

        public Consulta? AtenderConsulta(int consultaId) {
            var consulta = _repository.Atender(consultaId);
            if(consulta != null) {
                var consultaAtualizada = AtualizarStatus(consulta);
                consulta = _repository.AtualizarConsulta(consultaAtualizada);
            }            
            return consulta;
        }

        public List<Consulta> ListarConsultas() {
            throw new NotImplementedException();
        }

        public List<Medico> ListarMedicos() {
            return _repository.ListarMedicos();
        }

        public Medico SalvarMedico(Medico medico) {
            return _repository.SalvarMedico(medico);
        }

        internal Consulta AtualizarStatus(Consulta consulta) {
            if(consulta.Status == Models.Enums.StatusConsulta.Finalizada)
                return consulta;
            
            consulta.Status = Models.Enums.StatusConsulta.EmAtendimento;
            return consulta;
        }
    }
}

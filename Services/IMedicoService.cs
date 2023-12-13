using consulta_viva_API2.Models.Dto;

namespace consulta_viva_API2.Services {
    public interface IMedicoService {
        ConsultaDto AtenderConsulta(int consultaId);
        List<MedicoDto> ListarMedicos();
        MedicoDto SalvarMedico(MedicoDto medicoRequest);
        List<ConsultaDto> ListarConsultas();
    }
}

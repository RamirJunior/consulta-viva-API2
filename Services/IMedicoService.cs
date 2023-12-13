﻿using consulta_viva_API2.Models;
using consulta_viva_API2.Repositories;

namespace consulta_viva_API2.Services {
    public interface IMedicoService {
        Consulta AtenderConsulta(int consultaId);
        List<Medico> ListarMedicos();
        Medico SalvarMedico(Medico medico);
        List<Consulta> ListarConsultas();
    }
}

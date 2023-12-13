using consulta_viva_API2.Data;
using consulta_viva_API2.Models;
using consulta_viva_API2.Services;
using consulta_viva_API2.Services.Impl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace consulta_viva_API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase {

        private readonly IMedicoService _service;

        public MedicoController(IMedicoService userService) {
            _service = userService;
        }
        
        [HttpPost]
        public ActionResult<Medico> AdicionarMedico([FromBody] Medico medico) {
            Medico medicoAdicionado = _service.SalvarMedico(medico);
            return Ok(medicoAdicionado);
        }

        [HttpGet]
        public ActionResult<List<Medico>> ListarMedicos() {
            List<Medico> medicos = _service.ListarMedicos();
            return Ok(medicos);
        }

        [HttpPatch]
        public ActionResult<Consulta> AtenderConsulta(int consultaId) {
            Consulta consultaAtualizada = _service.AtenderConsulta(consultaId);
            return Ok(consultaAtualizada);
        }
    }
}

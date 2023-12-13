using consulta_viva_API2.Models.Dto;
using consulta_viva_API2.Services;
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
        public ActionResult<MedicoDto> AdicionarMedico([FromBody] MedicoDto medicoRequest) {
            MedicoDto medicoDto = _service.SalvarMedico(medicoRequest);
            return Ok(medicoDto);
        }

        [HttpGet]
        public ActionResult<List<MedicoDto>> ListarMedicos() {
            List<MedicoDto> medicosDto = _service.ListarMedicos();
            return Ok(medicosDto);
        }

        [HttpPut]
        public ActionResult<ConsultaDto> AtenderConsulta(int consultaId) {
            ConsultaDto consultaDto = _service.AtenderConsulta(consultaId);
            return Ok(consultaDto);
        }
    }
}

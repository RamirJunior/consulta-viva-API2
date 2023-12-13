using consulta_viva_API2.Models;
using consulta_viva_API2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace consulta_viva_API2.Controllers {
    [Route("api/paciente")]
    [ApiController]
    public class PacienteController : ControllerBase {

        private readonly IPacienteService _service;

        public PacienteController(IPacienteService pacienteService) {
            _service = pacienteService;
        }

        [HttpPost]
        public ActionResult<Paciente> SalvarPaciente(Paciente paciente) {
            var pacienteSalvo = _service.AdicionarPaciente(paciente);
            return Ok(pacienteSalvo);
        }

        [HttpGet]
        public ActionResult<List<Paciente>> ListarPacientes() {
            var pacientes = _service.ListarPacientes();
            return Ok(pacientes);
        }

        [HttpPost("/{pacienteId}")]
        public ActionResult<Paciente> MarcarConsulta(int pacienteId, [FromBody] Consulta consulta) {
            var pacienteConsultaMarcada = _service.MarcarConsulta(pacienteId, consulta);
            return Ok(pacienteConsultaMarcada);
        }
    }
}

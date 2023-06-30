using Hospital.Data.Repositories;
using Hospital.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPaciente _pacienteRepository;


        public PacienteController(IPaciente pacienteRepository)
        {
            _pacienteRepository = pacienteRepository; 
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPacientes()
        {
            return Ok(await _pacienteRepository.GetAllPacientes());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            return Ok(await _pacienteRepository.GetDetails(id)); 
        }

        [HttpPost]
        public async Task<IActionResult> CreatePaciente([FromBody] Paciente paciente)
        {
            if (paciente == null)
                return BadRequest();
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _pacienteRepository.InsertPaciente(paciente);
            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePaciente([FromBody] Paciente paciente)
        {
            if (paciente == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _pacienteRepository.UpdatePaciente(paciente);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePaciente(int id)
        {
            await _pacienteRepository.DeletePaciente(new Paciente { Id = id });
            return NoContent();
        }

    }
}

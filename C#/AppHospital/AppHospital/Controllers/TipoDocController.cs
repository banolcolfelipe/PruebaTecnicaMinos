using Hospital.Data.Repositories;
using Hospital.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AppHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDocController : ControllerBase
    {
        private readonly ITipo_Doc _tipoDocRepository;

        public TipoDocController(ITipo_Doc tipoDocRepository)
        {
            _tipoDocRepository = tipoDocRepository;
        }

        

        [HttpGet]
        public async Task<IActionResult> GetAllTipoDocs()
        {
            return Ok(await _tipoDocRepository.GetAllTipoDocs());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            return Ok(await _tipoDocRepository.GetDetails(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTipoDoc([FromBody] Tipo_Documento tipoDoc)
        {
            if (tipoDoc == null)
                return BadRequest();

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _tipoDocRepository.InsertTipoDoc(tipoDoc);
            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTipoDoc([FromBody] Tipo_Documento tipoDoc)
        {
            if (tipoDoc == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _tipoDocRepository.UpdateTipoDoc(tipoDoc);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTipoDoc(int id)
        {
            await _tipoDocRepository.DeleteTipoDoc(new Tipo_Documento { Id = id });
            return NoContent();
        }
    }
}

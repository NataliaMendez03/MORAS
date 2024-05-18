using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Gestion_Moras.Models;
using Sistema_de_Gestion_Moras.Services;

namespace Sistema_de_Gestion_Moras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvidersController : ControllerBase
    {
        public readonly IProvidersService _ProvidersService;
        public ProvidersController(IProvidersService ProvidersService)
        {
            _ProvidersService = ProvidersService;
        }

        // GET: api/<ProvidersController>
        [HttpGet]
        public async Task<ActionResult<List<Providers>>> GetAllCity()
        {
            return Ok(await _ProvidersService.GetAll());
        }
        // GET api/<ProvidersController>/5
        [HttpGet("{idProviders}")]
        public async Task<ActionResult<Providers>> GetProviders(int idProviders)
        {
            var Providers = await _ProvidersService.GetProviders(idProviders);
            if (Providers == null)
            {
                return BadRequest("Providers not found");
            }
            return Ok(Providers);
        }
        // POST: api/City
        [HttpPost]
        public async Task<ActionResult<Providers>> PostProviders(int idPerson)
        {
            var ProvidersToPut = await _ProvidersService.CreateProviders(idPerson);

            if (ProvidersToPut != null)
            {
                //return CreatedAtAction(nameof(GetEps), new { id = idEps }, epsToPut);
                return Ok(ProvidersToPut);
            }
            else
            {
                return BadRequest("Error when inserting into the database");
            }
        }
        // PUT: api/Providers/5
        [HttpPut("Update/{idProviders}")]
        public async Task<ActionResult<Providers>> PutProviders(int idProviders, int idPerson)
        {
            var ProvidersToPut = await _ProvidersService.UpdateProviders(idProviders, idPerson);

            if (ProvidersToPut != null)
            {
                return Ok(ProvidersToPut);
            }
            else
            {
                return BadRequest("Error updating the database");
            }
        }
        // Delete: api/Providers/5
        [HttpDelete("Delete/{idProviders}")]
        public async Task<ActionResult<Providers>> DeleteProviders(int idProviders)
        {
            var ProvidersToDelete = await _ProvidersService.DeleteProviders(idProviders);

            if (ProvidersToDelete != null)
            {
                return Ok(ProvidersToDelete);
            }
            else
            {
                return BadRequest("Error updating the database");
            }
        }
    }
}

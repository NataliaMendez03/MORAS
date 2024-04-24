using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Gestion_Moras.Models;
using Sistema_de_Gestion_Moras.Services;

namespace Sistema_de_Gestion_Moras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvidervsInputsController : ControllerBase
    {
        public readonly IProvidervsInputsService _ProvidervsInputsService;
        public ProvidervsInputsController(IProvidervsInputsService ProvidervsInputsService)
        {
            _ProvidervsInputsService = ProvidervsInputsService;
        }

        // GET: api/<ProvidervsInputsController>
        [HttpGet]
        public async Task<ActionResult<List<ProvidervsInputs>>> GetAllProvidervsInputs()
        {
            return Ok(await _ProvidervsInputsService.GetAll());
        }
        // GET api/<ProvidervsInputsController>/5
        [HttpGet("{IdProvsInp}")]
        public async Task<ActionResult<ProvidervsInputs>> GetProvidervsInputs(int idProvsInp)
        {
            var ProvidervsInputs = await _ProvidervsInputsService.GetProvidervsInputs(idProvsInp);
            if (ProvidervsInputs == null)
            {
                return BadRequest("City not found");
            }
            return Ok(ProvidervsInputs);
        }
        // POST: api/ProvidervsInputs
        [HttpPost("{idProviders, idSupplies}")]
        public async Task<ActionResult<ProvidervsInputs>> PostProvidervsInputs(int idProviders, int idSupplies)
        {
            var ProvidervsInputsToPut = _ProvidervsInputsService.CreateProvidervsInputs(idProviders, idSupplies);

            if (ProvidervsInputsToPut != null)
            {
                //return CreatedAtAction(nameof(GetEps), new { id = idEps }, epsToPut);
                return Ok(ProvidervsInputsToPut);
            }
            else
            {
                return BadRequest("Error when inserting into the database");
            }
        }
        // PUT: api/ProvidervsInputs/5
        [HttpPut("Update/{idProvidervsInputs}")]
        public async Task<ActionResult<ProvidervsInputs>> PutProvidervsInputs(int idProvsInp, int idProviders, int idSupplies)
        {
            var ProvidervsInputsToPut = _ProvidervsInputsService.UpdateProvidervsInputs(idProvsInp, idProviders, idSupplies);

            if (ProvidervsInputsToPut != null)
            {
                return Ok(ProvidervsInputsToPut);
            }
            else
            {
                return BadRequest("Error updating the database");
            }
        }
        // Delete: api/ProvidervsInputs/5
        [HttpPut("Delete/{idProvsInp}")]
        public async Task<ActionResult<ProvidervsInputs>> DeleteProvidervsInputs(int idProvsInp)
        {
            var ProvidervsInputsToDelete = _ProvidervsInputsService.DeleteProvidervsInputs(idProvsInp);

            if (ProvidervsInputsToDelete != null)
            {
                return Ok(ProvidervsInputsToDelete);
            }
            else
            {
                return BadRequest("Error updating the database");
            }
        }
    }
}
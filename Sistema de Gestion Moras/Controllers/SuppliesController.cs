using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Gestion_Moras.Models;
using Sistema_de_Gestion_Moras.Services;

namespace Sistema_de_Gestion_Moras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliesController : ControllerBase
    {
        public readonly ISuppliesService _suppliesService;
        public SuppliesController(ISuppliesService suppliesService)
        {
            _suppliesService = suppliesService;
        }
        // GET: api/<SuppliesController>
        [HttpGet]
        public async Task<ActionResult<List<Supplies>>> GetAllSupplies()
        {
            return Ok(await _suppliesService.GetAll());
        }
        // GET api/<SuppliesController>/5
        [HttpGet("{idSupplies}")]
        public async Task<ActionResult<Supplies>> GetSupplies(int idSupplies)
        {
            var supplies = await _suppliesService.GetSupplies(idSupplies);
            if (supplies == null)
            {
                return BadRequest("Supplies not found");
            }
            return Ok(supplies);
        }
        // POST: api/Supplies
        [HttpPost]
        public async Task<ActionResult<Supplies>> PostSupplies(string nameSupplies)
        {
            var SuppliesToPut = await _suppliesService.CreateSupplies(nameSupplies);

            if (SuppliesToPut != null)
            {
                //return CreatedAtAction(nameof(GetEps), new { id = idEps }, epsToPut);
                return Ok(SuppliesToPut);
            }
            else
            {
                return BadRequest("Error when inserting into the database");
            }


        }
        // PUT: api/Supplies/5
        [HttpPut("Update/{idSupplies}")]
        public async Task<ActionResult<Supplies>> PutSupplies(int idSupplies, string nameSupplies)
        {
            var SuppliesToPut = await _suppliesService.UpdateSupplies(idSupplies, nameSupplies);

            if (SuppliesToPut != null)
            {
                return Ok(SuppliesToPut);
            }
            else
            {
                return BadRequest("Error updating the database");
            }
        }
        // Delete: api/Supplies/5
        [HttpPut("Delete/{idSupplies}")]
        public async Task<ActionResult<Supplies>> DeleteSupplies(int idSupplies)
        {
            var SuppliesToDelete = await _suppliesService.DeleteSupplies(idSupplies);

            if (SuppliesToDelete != null)
            {
                return Ok(SuppliesToDelete);
            }
            else
            {
                return BadRequest("Error updating the database");
            }
        }
    }
}

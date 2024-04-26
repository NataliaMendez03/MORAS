using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Gestion_Moras.Models;
using Sistema_de_Gestion_Moras.Repositories;
using Sistema_de_Gestion_Moras.Services;

namespace Sistema_de_Gestion_Moras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HarvestsController : ControllerBase
    {
        public readonly IHarvestsService _harvestsService;
        public HarvestsController(IHarvestsService harvestsService)
        {
            _harvestsService = harvestsService;
        }
        // GET: api/<HarvestsController>
        [HttpGet]
        public async Task<ActionResult<List<Harvests>>> GetAllHarvests()
        {
            return Ok(await _harvestsService.GetAll());
        }
        // GET api/<HarvestsController>/5
        [HttpGet("{idHarvests}")]
        public async Task<ActionResult<Harvests>> GetHarvests(int idHarvests)
        {
            var Harvests = await _harvestsService.GetHarvests(idHarvests);
            if (Harvests == null)
            {
                return BadRequest("Harvests not found");
            }
            return Ok(Harvests);
        }
        // POST: api/Harvests
        [HttpPost]
        public async Task<ActionResult<Harvests>> PostHarvests(DateTime harvestDate, string harvestAmount, int idemployees, int idQuality)
        {
            var HarvestsToPut = await _harvestsService.CreateHarvests(harvestDate, harvestAmount, idemployees, idQuality);

            if (HarvestsToPut != null)
            {
                //return CreatedAtAction(nameof(GetEps), new { id = idEps }, epsToPut);
                return Ok(HarvestsToPut);
            }
            else
            {
                return BadRequest("Error when inserting into the database");
            }


        }
        // PUT: api/Harvests/5
        [HttpPut("Update/{idHarvests}")]
        public async Task<ActionResult<Harvests>> PutHarvests(int idHarvests, DateTime harvestDate, string harvestAmount, int idemployees, int idQuality)
        {
            var HarvestsToPut = await _harvestsService.UpdateHarvests(idHarvests,harvestDate, harvestAmount, idemployees, idQuality);

            if (HarvestsToPut != null)
            {
                return Ok(HarvestsToPut);
            }
            else
            {
                return BadRequest("Error updating the database");
            }
        }
        // Delete: api/Harvests/5
        [HttpPut("Delete/{idHarvests}")]
        public async Task<ActionResult<Harvests>> DeleteHarvests(int idHarvests)
        {
            var HarvestsToDelete = await _harvestsService.DeleteHarvests(idHarvests);

            if (HarvestsToDelete != null)
            {
                return Ok(HarvestsToDelete);
            }
            else
            {
                return BadRequest("Error updating the database");
            }
        }
    }
}

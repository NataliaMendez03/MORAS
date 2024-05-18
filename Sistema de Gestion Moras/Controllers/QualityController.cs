using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Gestion_Moras.Models;
using Sistema_de_Gestion_Moras.Services;

namespace Sistema_de_Gestion_Moras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QualityController : ControllerBase
    {
        public readonly IQualityService _QualityService;
        public QualityController(IQualityService QualityService)
        {
            _QualityService = QualityService;
        }

        // GET: api/<QualityController>
        [HttpGet]
        public async Task<ActionResult<List<Quality>>> GetAllQuality()
        {
            return Ok(await _QualityService.GetAll());
        }
        // GET api/<QualityController>/5
        [HttpGet("{idQuality}")]
        public async Task<ActionResult<Quality>> GetQuality(int idQuality)
        {
            var Quality = await _QualityService.GetQuality(idQuality);
            if (Quality == null)
            {
                return BadRequest("Quality not found");
            }
            return Ok(Quality);
        }
        // POST: api/Contact
        [HttpPost]
        public async Task<ActionResult<Quality>> PostQuality(string nQuality, string quantity)
        {
            var QualityToPut = await _QualityService.CreateQuality(nQuality, quantity);

            if (QualityToPut != null)
            {
                //return CreatedAtAction(nameof(GetEps), new { id = idEps }, epsToPut);
                return Ok(QualityToPut);
            }
            else
            {
                return BadRequest("Error when inserting into the database");
            }
        }
        // PUT: api/Quality/5
        [HttpPut("Update/{idQuality}")]
        public async Task<ActionResult<Quality>> PutQuality(int idQuality, string nQuality, string quantity)
        {
            var QualityToPut = await _QualityService.UpdateQuality(idQuality, nQuality, quantity);

            if (QualityToPut != null)
            {
                return Ok(QualityToPut);
            }
            else
            {
                return BadRequest("Error updating the database");
            }
        }
        // Delete: api/Quality/5
        [HttpDelete("Delete/{idQuality}")]
        public async Task<ActionResult<Quality>> DeleteQuality(int idQuality)
        {
            var QualityToDelete = await _QualityService.DeleteQuality(idQuality);

            if (QualityToDelete != null)
            {
                return Ok(QualityToDelete);
            }
            else
            {
                return BadRequest("Error updating the database");
            }
        }
    }
}

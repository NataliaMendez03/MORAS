using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Gestion_Moras.Models;
using Sistema_de_Gestion_Moras.Services;

namespace Sistema_de_Gestion_Moras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelsController : ControllerBase
    {
        public readonly ILevelsService _levelsService;
        public LevelsController(ILevelsService levelsService)
        {
            _levelsService = levelsService;
        }

        // GET: api/<LevelsController>
        [HttpGet]
        public async Task<ActionResult<List<Levels>>> GetAllLevels()
        {
            return Ok(await _levelsService.GetAll());
        }
        // GET api/<LevelsController>/5
        [HttpGet("{idLevels}")]
        public async Task<ActionResult<Levels>> GetLevels(int idLevels)
        {
            var Levels = await _levelsService.GetLevels(idLevels);
            if (Levels == null)
            {
                return BadRequest("Level not found");
            }
            return Ok(Levels);
        }
        // POST: api/Levels
        [HttpPost]
        public async Task<ActionResult<Levels>> PostLevels(string nameLevel)
        {
            var LevelsToPut = await _levelsService.CreateLevels(nameLevel);

            if (LevelsToPut != null)
            {
                //return CreatedAtAction(nameof(GetEps), new { id = idEps }, epsToPut);
                return Ok(LevelsToPut);
            }
            else
            {
                return BadRequest("Error when inserting into the database");
            }
        }
        // PUT: api/Levels/5
        [HttpPut("Update/{idLevels}")]
        public async Task<ActionResult<Levels>> PutLevels(int idLevels, string nameLevel)
        {
            var LevelsToPut = await _levelsService.UpdateLevels(idLevels, nameLevel);

            if (LevelsToPut != null)
            {
                return Ok(LevelsToPut);
            }
            else
            {
                return BadRequest("Error updating the database");
            }
        }
        // Delete: api/Levels/5
        [HttpPut("Delete/{idLevels}")]
        public async Task<ActionResult<Levels>> DeleteLevels(int idLevels)
        {
            var LevelsToDelete = await _levelsService.DeleteLevels(idLevels);

            if (LevelsToDelete != null)
            {
                return Ok(LevelsToDelete);
            }
            else
            {
                return BadRequest("Error updating the database");
            }
        }
    }
}
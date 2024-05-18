using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Gestion_Moras.Models;
using Sistema_de_Gestion_Moras.Services;

namespace Sistema_de_Gestion_Moras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AchievementsController : ControllerBase
    {
        public readonly IAchievementsService _AchievementsService;
        public AchievementsController(IAchievementsService AchievementsService)
        {
            _AchievementsService = AchievementsService;
        }

        // GET: api/<AchievementsController>
        [HttpGet]
        public async Task<ActionResult<List<Achievements>>> GetAllAchievements()
        {
            return Ok(await _AchievementsService.GetAll());
        }
        // GET api/<AchievementsController>/5
        [HttpGet("{idAchievements}")]
        public async Task<ActionResult<Achievements>> GetAchievements(int idAchievements)
        {
            var Achievements = await _AchievementsService.GetAchievements(idAchievements);
            if (Achievements == null)
            {
                return BadRequest("Achievements not found");
            }
            return Ok(Achievements);
        }
        // POST: api/Achievements
        [HttpPost("Create")]
        public async Task<ActionResult<Achievements>> PostAchievements(int idLogin, int IdMission)
        {
            var AchievementsToPut = await _AchievementsService.CreateAchievements(idLogin, IdMission);

            if (AchievementsToPut != null)
            {
                //return CreatedAtAction(nameof(GetEps), new { id = idEps }, epsToPut);
                return Ok(AchievementsToPut);
            }
            else
            {
                return BadRequest("Error when inserting into the database");
            }
        }
        // PUT: api/Achievements/5
        [HttpPut("Update/{idAchievements}")]
        public async Task<ActionResult<Achievements>> PutAchievements(int idAchievements, int IdLogin, int IdMission)
        {
            var AchievementsToPut = await _AchievementsService.UpdateAchievements(idAchievements, IdLogin, IdMission);

            if (AchievementsToPut != null)
            {
                return Ok(AchievementsToPut);
            }
            else
            {
                return BadRequest("Error updating the database");
            }
        }
        // Delete: api/Achievements/5
        [HttpDelete("Delete/{idAchievements}")]
        public async Task<ActionResult<Achievements>> DeleteAchievements(int idAchievements)
        {
            var AchievementsToDelete = await _AchievementsService.DeleteAchievements(idAchievements);

            if (AchievementsToDelete != null)
            {
                return Ok(AchievementsToDelete);
            }
            else
            {
                return BadRequest("Error updating the database");
            }
        }
    }
}
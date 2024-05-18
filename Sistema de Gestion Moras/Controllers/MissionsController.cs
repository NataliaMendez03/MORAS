using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Gestion_Moras.Models;
using Sistema_de_Gestion_Moras.Services;

namespace Sistema_de_Gestion_Moras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionsController : ControllerBase
    {
        public readonly IMissionsService _MissionsService;
        public MissionsController(IMissionsService MissionsService)
        {
            _MissionsService = MissionsService;
        }

        // GET: api/<MissionsController>
        [HttpGet]
        public async Task<ActionResult<List<Missions>>> GetAllMissions()
        {
            return Ok(await _MissionsService.GetAll());
        }
        // GET api/<MissionsController>/5
        [HttpGet("{idMissions}")]
        public async Task<ActionResult<Missions>> GetMissions(int idMissions)
        {
            var Missions = await _MissionsService.GetMissions(idMissions);
            if (Missions == null)
            {
                return BadRequest("City not found");
            }
            return Ok(Missions);
        }
        // POST: api/Missions
        [HttpPost]
        public async Task<ActionResult<Missions>> PostMissions(string nameMission, string description, int idLevel)
        {
            var MissionsToPut = await _MissionsService.CreateMissions(nameMission, description, idLevel);

            if (MissionsToPut != null)
            {
                return Ok(MissionsToPut);
            }
            else
            {
                return BadRequest("Error when inserting into the database");
            }
        }
        // PUT: api/Missions/5
        [HttpPut("Update/{idMissions}")]
        public async Task<ActionResult<Missions>> PutMissions(int idMissions, string nameMission, string description, int idLevel)
        {
            var MissionsToPut = await _MissionsService.UpdateMissions(idMissions, nameMission, description, idLevel);

            if (MissionsToPut != null)
            {
                return Ok(MissionsToPut);
            }
            else
            {
                return BadRequest("Error updating the database");
            }
        }
        // Delete: api/Missions/5
        [HttpDelete("Delete/{idMissions}")]
        public async Task<ActionResult<Missions>> DeleteMissions(int idMissions)
        {
            var MissionsToDelete = await _MissionsService.DeleteMissions(idMissions);

            if (MissionsToDelete != null)
            {
                return Ok(MissionsToDelete);
            }
            else
            {
                return BadRequest("Error updating the database");
            }
        }
    }
}
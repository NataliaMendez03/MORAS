using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Gestion_Moras.Models;
using Sistema_de_Gestion_Moras.Services;

namespace Sistema_de_Gestion_Moras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LandmarksController : ControllerBase
    {
        public readonly ILandmarksService _landmarksService;
        public LandmarksController(ILandmarksService landmarksService)
        {
            _landmarksService = landmarksService;
        }
        // GET: api/<LandmarksController>
        [HttpGet]
        public async Task<ActionResult<List<Landmarks>>> GetAllLandmarks()
        {
            return Ok(await _landmarksService.GetAll());
        }
        // GET api/<LandmarksController>/5
        [HttpGet("{idLandmarks}")]
        public async Task<ActionResult<Landmarks>> GetLandmarks(int idLandmarks)
        {
            var Landmarks = await _landmarksService.GetLandmarks(idLandmarks);
            if (Landmarks == null)
            {
                return BadRequest("Landmarks not found");
            }
            return Ok(Landmarks);
        }
        // POST: api/Landmarks
        [HttpPost]
        public async Task<ActionResult<Landmarks>> PostLandmarks(int idLevel, int idHarvest)
        {
            var LandmarksToPut = await _landmarksService.CreateLandmarks(idLevel, idHarvest);

            if (LandmarksToPut != null)
            {
                return Ok(LandmarksToPut);
            }
            else
            {
                return BadRequest("Error when inserting into the database");
            }
        }
        // PUT: api/Landmarks/5
        [HttpPut("Update/{idLandmarks}")]
        public async Task<ActionResult<Landmarks>> PutLandmarks(int idLandmarks, int idLevel, int idHarvest)
        {
            var LandmarksToPut = await _landmarksService.UpdateLandmarks(idLandmarks,idLevel, idHarvest);

            if (LandmarksToPut != null)
            {
                return Ok(LandmarksToPut); 
            }
            else
            {
                return BadRequest("Error updating the database");
            }
        }
        // Delete: api/Landmarks/5
        [HttpPut("Delete/{idLandmarks}")]
        public async Task<ActionResult<Landmarks>> DeleteLandmarks(int idLandmarks)
        {
            var LandmarksToDelete = await _landmarksService.DeleteLandmarks(idLandmarks);

            if (LandmarksToDelete != null)
            {
                return Ok(LandmarksToDelete);
            }
            else
            {
                return BadRequest("Error updating the database");
            }
        }
    }
}

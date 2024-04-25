using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Gestion_Moras.Models;
using Sistema_de_Gestion_Moras.Repositories;
using Sistema_de_Gestion_Moras.Services;

namespace Sistema_de_Gestion_Moras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackingController : ControllerBase
    {
        public readonly ITrackingService _trackingService;
        public TrackingController(ITrackingService trackingService)
        {
            _trackingService = trackingService;
        }
        // GET: api/<TrackingController>
        [HttpGet]
        public async Task<ActionResult<List<Tracking>>> GetAllTracking()
        {
            return Ok(await _trackingService.GetAll());
        }
        // GET api/<TrackingController>/5
        [HttpGet("{idTracking}")]
        public async Task<ActionResult<Tracking>> GetTracking(int idTracking)
        {
            var tracking = await _trackingService.GetTracking(idTracking);
            if (tracking == null)
            {
                return BadRequest("tracking not found");
            }
            return Ok(tracking);
        }
        // POST: api/Tracking
        [HttpPost("{datetracking, idstate}")]
        public async Task<ActionResult<Tracking>> PostTracking(DateTime datetracking, int idState)
        {
            var TrackingToPut = _trackingService.CreateTracking(datetracking, idState);

            if (TrackingToPut != null)
            {
                //return CreatedAtAction(nameof(GetEps), new { id = idEps }, epsToPut);
                return Ok(TrackingToPut);
            }
            else
            {
                return BadRequest("Error when inserting into the database");
            }


        }
        // PUT: api/Tracking/5
        [HttpPut("Update/{idTracking}")]
        public async Task<ActionResult<Address>> PutTracking(int idTracking, DateTime datetracking, int idState)
        {
            var TrackingToPut = _trackingService.UpdateTracking(idTracking, datetracking,idState);

            if (TrackingToPut != null)
            {
                return Ok(TrackingToPut);
            }
            else
            {
                return BadRequest("Error updating the database");
            }
        }
        // Delete: api/Tracking/5
        [HttpPut("Delete/{idTracking}")]
        public async Task<ActionResult<Tracking>> DeleteTracking(int idTracking)
        {
            var TrackingToDelete = _trackingService.DeleteTracking(idTracking);

            if (TrackingToDelete != null)
            {
                return Ok(TrackingToDelete);
            }
            else
            {
                return BadRequest("Error updating the database");
            }
        }
    }

}

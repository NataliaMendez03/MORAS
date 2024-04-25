using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Gestion_Moras.Models;
using Sistema_de_Gestion_Moras.Services;

namespace Sistema_de_Gestion_Moras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DispatchValuesController : ControllerBase
    {
        public readonly IDispatchService _dispatchService;
        public DispatchValuesController(IDispatchService dispatchService)
        {
            _dispatchService = dispatchService;
        }
        // GET: api/<DispatchController>
        [HttpGet]
        public async Task<ActionResult<List<Dispatch>>> GetAllDispatch()
        {
            return Ok(await _dispatchService.GetAll());
        }
        // GET api/<DispatchController>/5
        [HttpGet("{idDispatch}")]
        public async Task<ActionResult<Dispatch>> GetDispatch(int idDispatch)
        {
            var dispatch = await _dispatchService.GetDispatch(idDispatch);
            if (dispatch == null)
            {
                return BadRequest("Dispatch not found");
            }
            return Ok(dispatch);
        }
        // POST: api/Dispatch
        [HttpPost]
        public async Task<ActionResult<Dispatch>> PostDispatch(int idEmployees, int idSalesDetails, DateTime date, int idTracking)
        {
            var DispatchToPut = _dispatchService.CreateDispatch(idEmployees,idSalesDetails,date,idTracking);

            if (DispatchToPut != null)
            {
                //return CreatedAtAction(nameof(GetEps), new { id = idEps }, epsToPut);
                return Ok(DispatchToPut);
            }
            else
            {
                return BadRequest("Error when inserting into the database");
            }


        }
        // PUT: api/Dispatch/5
        [HttpPut("Update/{idDispatch}")]
        public async Task<ActionResult<Dispatch>> PutDispatch(int idDispatch, int idEmployees, int idSalesDetails, DateTime date, int idTracking)
        {
            var DispatchToPut = _dispatchService.UpdateDispatch(idDispatch,idEmployees,idSalesDetails,date,idTracking);

            if (DispatchToPut != null)
            {
                return Ok(DispatchToPut);
            }
            else
            {
                return BadRequest("Error updating the database");
            }
        }
        // Delete: api/Dispatch/5
        [HttpPut("Delete/{idDispatch}")]
        public async Task<ActionResult<Dispatch>> DeleteDispatch(int idDispatch)
        {
            var DispatchToDelete = _dispatchService.DeleteDispatch(idDispatch);
            if (DispatchToDelete != null)
            {
                return Ok(DispatchToDelete);
            }
            else
            {
                return BadRequest("Error updating the database");
            }
        }
    }
}

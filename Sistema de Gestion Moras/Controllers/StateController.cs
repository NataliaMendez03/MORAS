using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestion_Moras.Models;
using Sistema_de_Gestion_Moras.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HClinicalV2._0.Controllers
{
    [Route("HClinical/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateService _StateService;
        public StateController(IStateService StateService)
        {
            _StateService = StateService;
        }


        // GET: api/<StateController>
        [HttpGet]
        public async Task<ActionResult<List<State>>> GetAllState()
        {
            return Ok(await _StateService.GetAll());
        }

        // GET api/<StateController>/5
        [HttpGet("{idState}")]
        public async Task<ActionResult<State>> GetState(int idState)
        {
            var State = await _StateService.GetState(idState);
            if (State == null)
            {
                return BadRequest("State not found :(");
            }
            return Ok(State);
        }

        // State: api/State
        [HttpPost]
        public async Task<ActionResult<State>> StateState(string nameState)
        {
            var StateToPut = _StateService.CreateState(nameState);

            if (StateToPut != null)
            {
                return Ok(StateToPut);
            }
            else
            {
                return BadRequest("Error when inserting into the database :(");
            }


        }

        // PUT: api/State/5
        [HttpPut("Update/{idState}")]
        public async Task<ActionResult<State>> PutState(int idState, string nameState)
        {
            var StateToPut = await _StateService.UpdateState(idState, nameState);

            if (StateToPut != null)
            {
                return Ok(StateToPut);
            }
            else
            {
                return BadRequest("Error updating the database :(");
            }

        }

        // Delete: api/State/5
        [HttpPut("Delete/{idState}")]
        public async Task<ActionResult<State>> DeleteState(int idState)
        {

            var StateToDelete = await _StateService.DeleteState(idState);

            if (StateToDelete != null)
            {
                return Ok(StateToDelete);
            }
            else
            {
                return BadRequest("Error updating the database :(");
            }
        }
    }

}
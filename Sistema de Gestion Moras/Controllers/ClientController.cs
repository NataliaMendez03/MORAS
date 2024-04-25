using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Gestion_Moras.Models;
using Sistema_de_Gestion_Moras.Repositories;
using Sistema_de_Gestion_Moras.Services;

namespace Sistema_de_Gestion_Moras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        public readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }
        // GET: api/<ClientController>
        [HttpGet]
        public async Task<ActionResult<List<Client>>> GetAllClient()
        {
            return Ok(await _clientService.GetAll());
        }
        // GET api/<ClientController>/5
        [HttpGet("{idClient}")]
        public async Task<ActionResult<Client>> GetClient(int idClient)
        {
            var Client = await _clientService.GetClient(idClient);
            if (Client == null)
            {
                return BadRequest("Client not found");
            }
            return Ok(Client);
        }
        // POST: api/Client
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(int idClient)
        {
            var ClientToPut = _clientService.CreateClient(idClient);

            if (ClientToPut != null)
            {
                //return CreatedAtAction(nameof(GetEps), new { id = idEps }, epsToPut);
                return Ok(ClientToPut);
            }
            else
            {
                return BadRequest("Error when inserting into the database");
            }


        }
        // PUT: api/Client/5
        [HttpPut("Update/{idClient}")]
        public async Task<ActionResult<Client>> PutClient(int idClient, int idPerson)
        {
            var ClientToPut = _clientService.UpdateClient(idClient,idPerson);

            if (ClientToPut != null)
            {
                return Ok(ClientToPut);
            }
            else
            {
                return BadRequest("Error updating the database");
            }
        }
        // Delete: api/Client/5
        [HttpPut("Delete/{idClient}")]
        public async Task<ActionResult<Client>> DeleteClient(int idClient)
        {
            var ClientToDelete = _clientService.DeleteClient(idClient);

            if (ClientToDelete != null)
            {
                return Ok(ClientToDelete);
            }
            else
            {
                return BadRequest("Error updating the database");
            }
        }
    }
}

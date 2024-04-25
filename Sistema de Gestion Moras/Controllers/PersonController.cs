using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Gestion_Moras.Models;
using Sistema_de_Gestion_Moras.Repositories;
using Sistema_de_Gestion_Moras.Services;

namespace Sistema_de_Gestion_Moras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        public readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        // GET: api/<PersonController>
        [HttpGet]
        public async Task<ActionResult<List<Person>>> GetAllPerson()
        {
            return Ok(await _personService.GetAll());
        }
        // GET api/<PersonController>/5
        [HttpGet("{idPerson}")]
        public async Task<ActionResult<Person>> GetPerson(int idPerson)
        {
            var Person = await _personService.GetPerson(idPerson);
            if (Person == null)
            {
                return BadRequest("Person not found");
            }
            return Ok(Person);
        }
        // POST: api/Person
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(string name, string lastName, int idContact, int idTypeIdentification, int numberIdentification, int idAddress)
        {
            var PersonToPut = _personService.CreatePerson(name, lastName,idContact, idTypeIdentification, numberIdentification, idAddress);

            if (PersonToPut != null)
            {
                //return CreatedAtAction(nameof(GetEps), new { id = idEps }, epsToPut);
                return Ok(PersonToPut);
            }
            else
            {
                return BadRequest("Error when inserting into the database");
            }


        }
        // PUT: api/Person/5
        [HttpPut("Update/{idPerson}")]
        public async Task<ActionResult<Person>> PutPerson(int idPerson, string name, string lastName, int idContact, int idTypeIdentification, int numberIdentification, int idAddress)
        {
            var PersonToPut = _personService.UpdatePerson(idPerson, name, lastName, idContact, idTypeIdentification, numberIdentification, idAddress);

            if (PersonToPut != null)
            {
                return Ok(PersonToPut);
            }
            else
            {
                return BadRequest("Error updating the database");
            }
        }
        // Delete: api/Person/5
        [HttpPut("Delete/{idPerson}")]
        public async Task<ActionResult<Person>> DeletePerson(int idPerson)
        {
            var PersonToDelete = _personService.DeletePerson(idPerson);

            if (PersonToDelete != null)
            {
                return Ok(PersonToDelete);
            }
            else
            {
                return BadRequest("Error updating the database");
            }
        }
    }
}

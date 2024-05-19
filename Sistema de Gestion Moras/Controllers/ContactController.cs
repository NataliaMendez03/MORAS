using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestion_Moras.Models;
using Sistema_de_Gestion_Moras.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HClinicalV2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _ContactService;
        public ContactController(IContactService ContactService)
        {
            _ContactService = ContactService;
        }


        // GET: api/<ContactController>
        [HttpGet]
        public async Task<ActionResult<List<Contact>>> GetAllContact()
        {
            return Ok(await _ContactService.GetAll());
        }

        // GET api/<ContactController>/5
        [HttpGet("{idContact}")]
        public async Task<ActionResult<Contact>> GetContact(int idContact)
        {
            var Contact = await _ContactService.GetContact(idContact);
            if (Contact == null)
            {
                return BadRequest("Contact not found :(");
            }
            return Ok(Contact);
        }

        // Contact: api/Contact
        [HttpPost]
        public async Task<ActionResult<Contact>> ContactContact(string phone, string email)
        {
            var ContactToPut = await _ContactService.CreateContact(phone, email);

            if (ContactToPut != null)
            {
                return Ok(ContactToPut);
            }
            else
            {
                return BadRequest("Error when inserting into the database :(");
            }


        }

        // PUT: api/Contact/5
        [HttpPut("Update/{idContact}")]
        public async Task<ActionResult<Contact>> PutContact(int idContact, string phone, string email)
        {
            var ContactToPut = await _ContactService.UpdateContact(idContact, phone, email);

            if (ContactToPut != null)
            {
                return Ok(ContactToPut);
            }
            else
            {
                return BadRequest("Error updating the database :(");
            }

        }

        // Delete: api/Contact/5
        [HttpDelete("Delete/{idContact}")]
        public async Task<ActionResult<Contact>> DeleteContact(int idContact)
        {

            var ContactToDelete = await _ContactService.DeleteContact(idContact);

            if (ContactToDelete != null)
            {
                return Ok(ContactToDelete);
            }
            else
            {
                return BadRequest("Error updating the database :(");
            }
        }
    }

}
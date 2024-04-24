using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Gestion_Moras.Models;
using Sistema_de_Gestion_Moras.Services;

namespace Sistema_de_Gestion_Moras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        public readonly IAddressService _AddressService;
        public AddressController(IAddressService AddressService)
        {
            _AddressService = AddressService;
        }

        // GET: api/<AddressController>
        [HttpGet]
        public async Task<ActionResult<List<Address>>> GetAllAddress()
        {
            return Ok(await _AddressService.GetAll());
        }
        // GET api/<AddressController>/5
        [HttpGet("{idAddress}")]
        public async Task<ActionResult<Address>> GetAddress(int idAddress)
        {
            var Address = await _AddressService.GetAddress(idAddress);
            if (Address == null)
            {
                return BadRequest("City not found");
            }
            return Ok(Address);
        }
        // POST: api/Address
        [HttpPost("{addres, idCity}")]
        public async Task<ActionResult<Address>> PostAddress(string addres, int idCity)
        {
            var AddressToPut = _AddressService.CreateAddress(addres, idCity);

            if (AddressToPut != null)
            {
                //return CreatedAtAction(nameof(GetEps), new { id = idEps }, epsToPut);
                return Ok(AddressToPut);
            }
            else
            {
                return BadRequest("Error when inserting into the database");
            }
        }
        // PUT: api/Address/5
        [HttpPut("Update/{idAddress}")]
        public async Task<ActionResult<Address>> PutAddress(int idAddress, string addres, int idCity)
        {
            var AddressToPut = _AddressService.UpdateAddress(idCity, addres, idCity);

            if (AddressToPut != null)
            {
                return Ok(AddressToPut);
            }
            else
            {
                return BadRequest("Error updating the database");
            }
        }
        // Delete: api/Address/5
        [HttpPut("Delete/{idAddress}")]
        public async Task<ActionResult<Address>> DeleteAddress(int idAddress)
        {
            var AddressToDelete = _AddressService.DeleteAddress(idAddress);

            if (AddressToDelete != null)
            {
                return Ok(AddressToDelete);
            }
            else
            {
                return BadRequest("Error updating the database");
            }
        }
    }
}
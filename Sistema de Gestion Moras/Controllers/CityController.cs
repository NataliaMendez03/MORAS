using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Gestion_Moras.Models;
using Sistema_de_Gestion_Moras.Services;

namespace Sistema_de_Gestion_Moras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        public readonly ICityService _CityService;
        public CityController(ICityService CityService)
        {
            _CityService = CityService;
        }

        // GET: api/<CityController>
        [HttpGet]
        public async Task<ActionResult<List<City>>> GetAllCity()
        {
            return Ok(await _CityService.GetAll());
        }
        // GET api/<contactController>/5
        [HttpGet("{idCity}")]
        public async Task<ActionResult<City>> GetCity(int idCity)
        {
            var city = await _CityService.GetCity(idCity);
            if (city == null)
            {
                return BadRequest("City not found");
            }
            return Ok(city);
        }
        // POST: api/City
        [HttpPost]
        public async Task<ActionResult<City>> PostCity(string nameCity)
        {
            var CityToPut = _CityService.CreateCity(nameCity);

            if (CityToPut != null)
            {
                return Ok(CityToPut);
            }
            else
            {
                return BadRequest("Error when inserting into the database");
            }
        }
        // PUT: api/Contact/5
        [HttpPut("Update/{idCity}")]
        public async Task<ActionResult<City>> PutCity(int idCity, string nameCity)
        {
            var CityToPut = _CityService.UpdateCity(idCity, nameCity);

            if (CityToPut != null)
            {
                return Ok(CityToPut);
            }
            else
            {
                return BadRequest("Error updating the database");
            }
        }
        // Delete: api/City/5
        [HttpPut("Delete/{idCity}")]
        public async Task<ActionResult<City>> DeleteCity(int idCity)
        {
            var CityToDelete = _CityService.DeleteCity(idCity);

            if (CityToDelete != null)
            {
                return Ok(CityToDelete);
            }
            else
            {
                return BadRequest("Error updating the database");
            }
        }
    }
}

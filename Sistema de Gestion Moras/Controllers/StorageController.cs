using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestion_Moras.Models;
using Sistema_de_Gestion_Moras.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sistema_de_Gestion_Moras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        private readonly IStorageService _StorageService;
        public StorageController(IStorageService StorageService)
        {
            _StorageService = StorageService;
        }


        // GET: api/<StorageController>
        [HttpGet]
        public async Task<ActionResult<List<Storage>>> GetAllStorage()
        {
            return Ok(await _StorageService.GetAll());
        }

        // GET api/<StorageController>/5
        [HttpGet("{idStorage}")]
        public async Task<ActionResult<Storage>> GetStorage(int idStorage)
        {
            var Storage = await _StorageService.GetStorage(idStorage);
            if (Storage == null)
            {
                return BadRequest("Storage not found :(");
            }
            return Ok(Storage);
        }

        // Storage: api/Storage
        [HttpPost]
        public async Task<ActionResult<Storage>> StorageStorage(string nameStorage, int idHarvests, DateTime entryDate, string temperature)
        {
            var StorageToPut = await _StorageService.CreateStorage(nameStorage, idHarvests, entryDate, temperature);

            if (StorageToPut != null)
            {
                return Ok(StorageToPut);
            }
            else
            {
                return BadRequest("Error when inserting into the database :(");
            }


        }

        // PUT: api/Storage/5
        [HttpPut("Update/{idStorage}")]
        public async Task<ActionResult<Storage>> PutStorage(int idStorage, string nameStorage, int idHarvests, DateTime entryDate, string temperature)
        {
            var StorageToPut = await _StorageService.UpdateStorage(idStorage, nameStorage, idHarvests, entryDate, temperature);

            if (StorageToPut != null)
            {
                return Ok(StorageToPut);
            }
            else
            {
                return BadRequest("Error updating the database :(");
            }

        }

        // Delete: api/Storage/5
        [HttpDelete("Delete/{idStorage}")]
        public async Task<ActionResult<Storage>> DeleteStorage(int idStorage)
        {

            var StorageToDelete = await _StorageService.DeleteStorage(idStorage);

            if (StorageToDelete != null)
            {
                return Ok(StorageToDelete);
            }
            else
            {
                return BadRequest("Error updating the database :(");
            }
        }
    }

}
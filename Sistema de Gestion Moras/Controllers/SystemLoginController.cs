using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Gestion_Moras.Models;
using Sistema_de_Gestion_Moras.Services;

namespace Sistema_de_Gestion_Moras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemLoginController : ControllerBase
    {
        public readonly ISystemLoginService _SystemLoginService;
        public SystemLoginController(ISystemLoginService SystemLoginService)
        {
            _SystemLoginService = SystemLoginService;
        }

        // AUTENTICACION PRUEBA 
        [HttpPost("SystemLogin")]
        public async Task<ActionResult<bool>> SystemLogin(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                return BadRequest("El nombre de usuario y la contraseña son obligatorios.");
            }

            var user = await _SystemLoginService.SystemLogin(userName, password);
            if (user != null)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }


        // GET: api/<SystemLoginController>
        [HttpGet]
        public async Task<ActionResult<List<SystemLogin>>> GetAllSystemLogin()
        {
            return Ok(await _SystemLoginService.GetAll());
        }
        // GET api/<SystemLoginController>/5
        [HttpGet("{idSystemLogin}")]
        public async Task<ActionResult<SystemLogin>> GetSystemLogin(int idSystemLogin)
        {
            var SystemLogin = await _SystemLoginService.GetSystemLogin(idSystemLogin);
            if (SystemLogin == null)
            {
                return BadRequest("City not found");
            }
            return Ok(SystemLogin);
        }
        // POST: api/SystemLogin
        [HttpPost("Create/")]
        public async Task<ActionResult<SystemLogin>> PostSystemLogin(string userName, string password, int idPerson)
        {
            var SystemLoginToPut = await _SystemLoginService.CreateSystemLogin(userName, password, idPerson);

            if (SystemLoginToPut != null)
            {
                return Ok(SystemLoginToPut);
            }
            else
            {
                return BadRequest("Error when inserting into the database");
            }
        }
        // PUT: api/SystemLogin/5
        [HttpPut("Update/{idSystemLogin}")]
        public async Task<ActionResult<SystemLogin>> PutSystemLogin(int idSystemLogin, string userName, string password, int idPerson)
        {
            var SystemLoginToPut = await _SystemLoginService.UpdateSystemLogin(idSystemLogin, userName, password, idPerson);

            if (SystemLoginToPut != null)
            {
                return Ok(SystemLoginToPut);
            }
            else
            {
                return BadRequest("Error updating the database");
            }
        }
        // Delete: api/SystemLogin/5
        [HttpDelete("Delete/{idSystemLogin}")]
        public async Task<ActionResult<SystemLogin>> DeleteSystemLogin(int idSystemLogin)
        {
            var SystemLoginToDelete = await _SystemLoginService.DeleteSystemLogin(idSystemLogin);

            if (SystemLoginToDelete != null)
            {
                return Ok(SystemLoginToDelete);
            }
            else
            {
                return BadRequest("Error updating the database");
            }
        }
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Gestion_Moras.Models;
using Sistema_de_Gestion_Moras.Services;

namespace Sistema_de_Gestion_Moras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public readonly ILoginService _loginService;
        public LoginController(ILoginService LoginService)
        {
            _loginService = LoginService;
        }

        // AUTENTICACION PRUEBA 
        [HttpPost("Login")]
        public async Task<ActionResult<bool>> Login(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                return BadRequest("El nombre de usuario y la contraseña son obligatorios.");
            }

            var user = await _loginService.Login(userName, password);
            if (user != null)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }


        // GET: api/<LoginController>
        [HttpGet]
        public async Task<ActionResult<List<Login>>> GetAllLogin()
        {
            return Ok(await _loginService.GetAll());
        }
        // GET api/<LoginController>/5
        [HttpGet("{idLogin}")]
        public async Task<ActionResult<Login>> GetLogin(int idLogin)
        {
            var Login = await _loginService.GetLogin(idLogin);
            if (Login == null)
            {
                return BadRequest("City not found");
            }
            return Ok(Login);
        }
        // POST: api/Login
        [HttpPost("Create/")]
        public async Task<ActionResult<Login>> PostLogin(string userName, string password, string email)
        {
            var LoginToPut = await _loginService.CreateLogin(userName, password, email);

            if (LoginToPut != null)
            {
                return Ok(LoginToPut);
            }
            else
            {
                return BadRequest("Error when inserting into the database");
            }
        }
        // PUT: api/Login/5
        [HttpPut("Update/{idLogin}")]
        public async Task<ActionResult<Login>> PutLogin(int idLogin, string userName, string password, string email)
        {
            var LoginToPut = await _loginService.UpdateLogin(idLogin, userName, password, email);

            if (LoginToPut != null)
            {
                return Ok(LoginToPut);
            }
            else
            {
                return BadRequest("Error updating the database");
            }
        }
        // Delete: api/Login/5
        [HttpPut("Delete/{idLogin}")]
        public async Task<ActionResult<Login>> DeleteLogin(int idLogin)
        {
            var LoginToDelete = await _loginService.DeleteLogin(idLogin);

            if (LoginToDelete != null)
            {
                return Ok(LoginToDelete);
            }
            else
            {
                return BadRequest("Error updating the database");
            }
        }
    }
}
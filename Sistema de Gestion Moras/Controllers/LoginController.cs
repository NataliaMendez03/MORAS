using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
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
                return BadRequest("User not found");
            }
            return Ok(Login);
        }
        // GET api/BYUSERNAME
        [HttpGet("IdByUsername/{username}")]
        public async Task<IActionResult> GetIdByUsername(string username)
        {
            var id = await _loginService.GetIdByUsername(username);
            if (id == null)
            {
                return NotFound();
            }
            return Ok(id);
        }
        // POST: api/Login
        [HttpPost("Create")]
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

        // AUTENTICACION BIENN 
        [HttpPost("Authentication")]
        public async Task<ActionResult<bool>> Login(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                return BadRequest("Username and password are required.");
            }

            bool user = await _loginService.Authentication(userName, password);
            if (user)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
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
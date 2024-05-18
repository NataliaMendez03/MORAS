using Microsoft.AspNetCore.Authorization;
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
        //[Authorize(Roles = "User")]
        public async Task<ActionResult<List<Login>>> GetAllLogin()
        {
            return Ok(await _loginService.GetAll());
        }

        [HttpGet("{idLogin}")]
        //[Authorize(Roles = "User")]
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

        [HttpPost("Create")]
        //[Authorize(Roles = "User")]
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

        // AUTENTICACION 
        [HttpPost("Authentication")]
        public async Task<ActionResult<string>> Login(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                return BadRequest("Username and password are required.");
            }

            bool user = await _loginService.Authentication(userName, password);
            if (user)
            {
                string token = _loginService.GenerateToken(userName);
                return Ok(token);
            }
            else
            {
                return Ok("false");
            }
        }

        [HttpPut("Update/{idLogin}")]
        //[Authorize(Roles = "User")]
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

        [HttpDelete("Delete/{idLogin}")]
        //[Authorize(Roles = "User")]
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
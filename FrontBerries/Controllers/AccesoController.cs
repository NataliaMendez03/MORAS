using Microsoft.AspNetCore.Mvc;
using Sistema_de_Gestion_Moras.Context;
using Sistema_de_Gestion_Moras.Models;
using Microsoft.EntityFrameworkCore;
using FrontBerries.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace FrontBerries.Controllers
{
    public class AccesoController : Controller
    {
        private readonly berriesdbContext _berriesdbContext;
        public AccesoController(berriesdbContext berriesdbContext)
        {
            _berriesdbContext = berriesdbContext;
        }

        [HttpGet]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registro(UsuarioVM modelo)
        {
            if (modelo.Password != modelo.ConfirmPassword)
            {
                ViewData["Mensaje"] = "Las contraseñas no coinciden";
                return View();
            }

            Login login = new Login()
            {
                UserName = modelo.UserName,
                Email = modelo.Email,
                Password = modelo.Password
            };

            await _berriesdbContext.Login.AddAsync(login);
            await _berriesdbContext.SaveChangesAsync();

            if (login.IdLogin != 0) return RedirectToAction("Login", "Acceso");

            ViewData["Mensaje"] = "No se pudo crear el usuario, Error Fatal";
            return View();
        }


        [HttpGet]
        public IActionResult Login()
        {
            if(User.Identity!.IsAuthenticated)return RedirectToAction("Index", "Home");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM modelo)
        {
            Login? usuario_encontrado = await _berriesdbContext.Login
                .Where(u => u.UserName == modelo.UserName &&
                u.Password == modelo.Password
                ).FirstOrDefaultAsync();
            if (usuario_encontrado == null)
            {
                ViewData["Mensaje"] = "No se encontro considencias";
                return View();
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, usuario_encontrado.UserName),
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true,
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties
                );
            return RedirectToAction("Index", "Home");
        }
    }
}
    

using Microsoft.AspNetCore.Mvc;
using Sistema_de_Gestion_Moras.Context;
using Sistema_de_Gestion_Moras.Models;
using Microsoft.EntityFrameworkCore;
using FrontBerries.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace FrontBerries.Controllers
{
    public class AccesoController : Controller
    {
        private readonly berriesdbContext _berriesdbContext;
        Uri baseAddress = new Uri("http://berriessystemmanagement.somee.com/api");
        private readonly HttpClient _client;
        public AccesoController(berriesdbContext berriesdbContext)
        {
            _berriesdbContext = berriesdbContext;
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registro(UsuarioVM model)
        {
            if (model.Password != model.ConfirmPassword)
            {
                ViewData["Mensaje"] = "Las contraseñas no coinciden";
                return View();
            }
            else
            {
                try
                {
                    String data = JsonConvert.SerializeObject(model);
                    StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + $"/Login/Create?userName={model.UserName}&password={model.Password}&email={model.Email}", content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        TempData["successMessage"] = "User Created";
                        return RedirectToAction("Login", "Acceso");
                    }
                }
                catch (Exception ex)
                {
                    TempData["errorMessage"] = ex.Message;
                    return View();
                }
                return View();
            }
        }


        [HttpGet]
        public IActionResult Login()
        {
            //if (User.Identity!.IsAuthenticated) return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            try
            {
                String data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _client.PostAsync(
                    _client.BaseAddress + $"/Login/Authentication?userName={model.UserName}&password={model.Password}", content);

                string token = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    if (token == "false")
                    {
                        ViewData["Mensaje"] = "No se encontraron coincidencias";
                        return View();
                    }
                    else
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, model.UserName),
                            //new Claim(ClaimTypes., model.UserName),
                            new Claim("Token", token)
                        };

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var authProperties = new AuthenticationProperties
                        {
                            AllowRefresh = true,
                        };

                        await HttpContext.SignInAsync(
                            CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(claimsIdentity),
                            authProperties
                        );

                        TempData["successMessage"] = "Login successful";
                        TempData["responseBody"] = token;

                        return RedirectToAction("IndexGame", "Home");
                    }
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    ViewData["Mensaje"] = "Invalid username or password.";
                    return View();
                }
                else
                {
                    ViewData["Mensaje"] = "Error: " + response.ReasonPhrase;
                    TempData["responseBody"] = token;
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }
    }
}

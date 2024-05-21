using FrontBerries.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sistema_de_Gestion_Moras.Context;
using System.Net;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace FrontBerries.Controllers
{
    public class AccesoSystemController : Controller
    {
        private readonly berriesdbContext _berriesdbContext;
        Uri baseAddress = new Uri("http://berriessystemmanagement.somee.com/api");
        private readonly HttpClient _client;
        public AccesoSystemController(berriesdbContext berriesdbContext)
        {
            _berriesdbContext = berriesdbContext;
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        /* [HttpGet]
        public IActionResult RegistroS()
         {
             return View();
         }

         [HttpPost]
         public async Task<IActionResult> RegistroS(SystemLoginVM model)
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
                         TempData["successMessage"] = "User Create";
                         return RedirectToAction("LoginS", "AccesoSystem");
                     }
                 }
                 catch (Exception ex)
                 {
                     TempData["errorMessage"] = ex.Message;
                     return View();
                 }
                 return View();
             }
         }*/
        [HttpGet]
        public IActionResult LoginS()
        {
            //if (User.Identity!.IsAuthenticated) return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginS(LogSystemVM model)
        {
            try
            {
                String data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _client.PostAsync(
                    _client.BaseAddress + $"/SystemLogin/Authentication?userName={model.Username}&password={model.Password}", content);

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
                            new Claim(ClaimTypes.Name, model.Username),
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
                        return RedirectToAction("Index", "Home");
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


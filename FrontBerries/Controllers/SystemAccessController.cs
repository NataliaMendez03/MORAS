using Microsoft.AspNetCore.Mvc;
using Sistema_de_Gestion_Moras.Context;
using Sistema_de_Gestion_Moras.Models;
using Microsoft.EntityFrameworkCore;
using FrontBerries.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using FrontBerries.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FrontBerries.Controllers
{
    public class SystemAccessController : Controller
    {
        Uri baseAddress = new Uri("http://berriessystemmanagement.somee.com/api");
        private readonly HttpClient _client;
        public SystemAccessController(berriesdbContext berriesdbContext)
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult SystemRegister()
        {
            return View();
        }

        /*[HttpPost]
        public async Task<IActionResult> SystemRegister(SystemLoginVM model)
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
                    HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + $"/SystemLogin/CreateuserName={model.UserName}&password={model.Password}&email={model.Email}", content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        TempData["successMessage"] = "User Created";
                        return RedirectToAction("LoginS", "SystemAccess");
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


        /// REGISTER -----------------------------------------------------------------------------------------------------------------

        private List<Person> GetPersons()
        {
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Person").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<Person>>(data);
            }
            return new List<Person>();
        }
        private List<Contact> GetContacts()
        {
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Contact").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<Contact>>(data);
            }
            return new List<Contact>();
        }

        private List<IdentificationType> GetTypeIdentifications()
        {
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/IdentificationType").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<IdentificationType>>(data);
            }
            return new List<IdentificationType>();
        }

        private List<Address> GetAddresses()
        {
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Address").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<Address>>(data);
            }
            return new List<Address>();
        }

    // GET SELECT LIST
        private List<SelectListItem> GetPersonSelectList()
        {
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Person").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                var persons = JsonConvert.DeserializeObject<List<Person>>(data);
                return persons.Select(c => new SelectListItem
                {
                    Value = c.IdPerson.ToString(),
                    Text = $"{c.Name} - {c.LastName} - {c.IdContact} - {c.IdAddress} - {c.IdTypeIdentification} - {c.NumberIdentification}"
                }).ToList();
            }
            return new List<SelectListItem>();
        }
        private List<SelectListItem> GetContactsSelectList()
        {
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Contact").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                var contacts = JsonConvert.DeserializeObject<List<Contact>>(data);
                return contacts.Select(c => new SelectListItem
                {
                    Value = c.IdContact.ToString(),
                    Text = $"{c.Phone} - {c.Email}"
                }).ToList();
            }
            return new List<SelectListItem>();
        }

        private List<SelectListItem> GetTypeIdentificationsSelectList()
        {
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/IdentificationType").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                var typeIdentifications = JsonConvert.DeserializeObject<List<IdentificationType>>(data);
                return typeIdentifications.Select(ti => new SelectListItem
                {
                    Value = ti.IdIdentificationType.ToString(),
                    Text = ti.IdentifiType
                }).ToList();
            }
            return new List<SelectListItem>();
        }

        private List<SelectListItem> GetAddressesSelectList()
        {
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Address").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                var addresses = JsonConvert.DeserializeObject<List<Address>>(data);
                return addresses.Select(a => new SelectListItem
                {
                    Value = a.IdAddress.ToString(),
                    Text = a.Addres
                }).ToList();
            }
            return new List<SelectListItem>();
        }

    // METODOS SYSTEM LOGIN 

        [HttpGet]
        public IActionResult Create()
        {
            var model = new SystemLoginViewModel
            {
                Person = GetPersonSelectList(),
                Contacts = GetContactsSelectList(),
                TypeIdentifications = GetTypeIdentificationsSelectList(),
                Addresses = GetAddressesSelectList()
            };
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SystemRegister(SystemLoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // Repopulate the lists in case of validation error
                model.Person = GetContactsSelectList();
                model.Contacts = GetContactsSelectList();
                model.TypeIdentifications = GetTypeIdentificationsSelectList();
                model.Addresses = GetAddressesSelectList();
                return View(model);
            }
            try
            {
                String data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _client.PostAsync(_client.BaseAddress + $"/SystemLogin/Create?userName={model.Username}&password={model.Password}", content);
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Person Created";
                    return RedirectToAction("PersonGet");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;

            }
            model.Contacts = GetContactsSelectList();
            model.TypeIdentifications = GetTypeIdentificationsSelectList();
            model.Addresses = GetAddressesSelectList();

            return View();
        }
















        [HttpGet]
        public IActionResult SystemLogin()
        {
            //if (User.Identity!.IsAuthenticated) return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SystemLogin(LogSystemVM model)
        {
            try
            {
                String data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _client.PostAsync(
                    _client.BaseAddress + $"/SystemLogin/Authentication?userName={model.UserName}&password={model.Password}", content);

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
    

using FrontBerries.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sistema_de_Gestion_Moras.Models;
using System;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;


namespace FrontBerries.Controllers
{
    public class SystemSystemLoginController : Controller
    {
        Uri baseAddress = new Uri("http://berriessystemmanagement.somee.com/api");
        private readonly HttpClient _client;

        public SystemSystemLoginController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

    #region GetClient
        [HttpGet]
        public IActionResult SystemLoginGet()
        {
            List<SystemLoginViewModel> Loginlist = new List<SystemLoginViewModel>();
            HttpResponseMessage respone = _client.GetAsync(_client.BaseAddress + "/SystemLogin").Result;
            if (respone.IsSuccessStatusCode)
            {
                string data = respone.Content.ReadAsStringAsync().Result;
                Loginlist = JsonConvert.DeserializeObject<List<SystemLoginViewModel>>(data);

                List<Person> person = GetPerson();
                List<Contact> contacts = GetContacts();
                List<IdentificationType> typeIdentifications = GetTypeIdentifications();
                List<Address> addresses = GetAddresses();

                foreach (var systemLogin in Loginlist)
                {
                    systemLogin.Name = person.FirstOrDefault(p => p.IdPerson == systemLogin.IdPerson)?.Name;
                    systemLogin.LastName = person.FirstOrDefault(p => p.IdPerson == systemLogin.IdPerson)?.LastName;
                    systemLogin.NumberIdentification = person.FirstOrDefault(ni => ni.IdPerson == systemLogin.IdPerson).NumberIdentification;

                    var personInfo = person.FirstOrDefault(p => p.IdPerson == systemLogin.IdPerson);
                    if (personInfo != null)
                    {
                        var identificationType = typeIdentifications.FirstOrDefault(ti => ti.IdIdentificationType == personInfo.IdTypeIdentification);
                        var email = contacts.FirstOrDefault(ti => ti.IdContact == personInfo.IdContact);
                        var phone = contacts.FirstOrDefault(ti => ti.IdContact == personInfo.IdContact);
                        var address = addresses.FirstOrDefault(ti => ti.IdAddress == personInfo.IdAddress);
                       
                        if (identificationType != null || email != null || phone != null || address != null)
                        {
                            systemLogin.IdentifiType = identificationType.IdentifiType;
                            systemLogin.Email = email.Email;
                            systemLogin.Phone = phone.Phone;
                            systemLogin.Address = address.Addres;
                        }
                    }
                }

            }
            var inactiveLogins = Loginlist.Where(login => !login.StateDelete).ToList();

            return View(inactiveLogins);
        }
        private List<Person> GetPerson()
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
    #endregion

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(SystemLoginViewModel model)
        {
            try
            {
                String data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + $"/SystemLogin/Create?userName={model.Username}&password={model.Password}&idPerson={model.IdPerson}", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "User Created";
                    return RedirectToAction("SystemLoginGet");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            try
            {
                SystemLoginViewModel SystemLogin = new SystemLoginViewModel();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/SystemLogin/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    SystemLogin = JsonConvert.DeserializeObject<SystemLoginViewModel>(data);
                }
                return View(SystemLogin);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }

        }
        [HttpPost]
        public IActionResult Update(SystemLoginViewModel model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + $"/SystemLogin/Update/{model.IdSystemLogin}?userName={model.Username}&password={model.Password}&idPerson={model.IdPerson}", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "User details updated";
                    return RedirectToAction("SystemLoginGet");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                SystemLoginViewModel SystemLogin = new SystemLoginViewModel();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/SystemLogin/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    SystemLogin = JsonConvert.DeserializeObject<SystemLoginViewModel>(data);
                }
                return View(SystemLogin);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }

        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + $"/SystemLogin/Delete/{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "User details deleted";
                    return RedirectToAction("SystemLoginGet");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
            return View("SystemLoginGet");

        }
    }
}

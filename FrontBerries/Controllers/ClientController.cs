using FrontBerries.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Sistema_de_Gestion_Moras.Models;
using System.Text;

namespace FrontBerries.Controllers
{
    public class ClientController : Controller
    {
        Uri baseAddress = new Uri("http://berriessystemmanagement.somee.com/api");
        private readonly HttpClient _client;

        public ClientController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

    #region GetClient
        [HttpGet]
        public IActionResult ClientGet()
        {
            List<ClientViewModel> Loginlist = new List<ClientViewModel>();
            HttpResponseMessage respone = _client.GetAsync(_client.BaseAddress + "/Client").Result;
            if (respone.IsSuccessStatusCode)
            {
                string data = respone.Content.ReadAsStringAsync().Result;
                Loginlist = JsonConvert.DeserializeObject<List<ClientViewModel>>(data);

                // Obtener datos adicionales
                List<Person> person = GetPerson();
                List<IdentificationType> typeIdentifications = GetTypeIdentifications();

                // Mapear datos relacionados
                foreach (var client in Loginlist)
                {
                    client.Name = person.FirstOrDefault(p => p.IdPerson == client.IdPerson)?.Name;
                    client.LastName = person.FirstOrDefault(p => p.IdPerson == client.IdPerson)?.LastName;
                   // client.IdentifiType = typeIdentifications.FirstOrDefault(ti => ti.IdIdentificationType == client.IdTypeIdentification)?.IdentifiType;
                    client.NumberIdentification = person.FirstOrDefault(ni => ni.IdPerson == client.IdPerson).NumberIdentification;

                    var personInfo = person.FirstOrDefault(p => p.IdPerson == client.IdPerson);
                    if (personInfo != null)
                    {
                        var identificationType = typeIdentifications.FirstOrDefault(ti => ti.IdIdentificationType == personInfo.IdTypeIdentification);
                        if (identificationType != null)
                        {
                            client.IdentifiType = identificationType.IdentifiType;
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
    #endregion




        [HttpGet]
        public IActionResult Update(int id)
        {
            try
            {
                ClientViewModel login = new ClientViewModel();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Client/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    login = JsonConvert.DeserializeObject<ClientViewModel>(data);
                }
                return View(login);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }

        }
        [HttpPost]
        public IActionResult Update(ClientViewModel model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + $"/Client/Update/{model.IdPerson}", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Client details updated";
                    return RedirectToAction("ClientGet");
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
                ClientViewModel login = new ClientViewModel();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Client/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    login = JsonConvert.DeserializeObject<ClientViewModel>(data);
                }
                return View(login);
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
                HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + $"/Client/Delete/{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "User details deleted";
                    return RedirectToAction("ClientGet");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
            return View("ClientGet");

        }
    }
}

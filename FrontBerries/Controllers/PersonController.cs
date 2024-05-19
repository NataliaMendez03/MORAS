using FrontBerries.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sistema_de_Gestion_Moras.Models;
using System.Text;

namespace FrontBerries.Controllers
{
    public class PersonController : Controller
    {
        Uri baseAddress = new Uri("http://berriessystemmanagement.somee.com/api");
        private readonly HttpClient _client;

        public PersonController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        [HttpGet]
        public IActionResult PersonGet()
        {
            List<PersonViewModel> Loginlist = new List<PersonViewModel>();
            HttpResponseMessage respone = _client.GetAsync(_client.BaseAddress + "/Person").Result;
            if (respone.IsSuccessStatusCode)
            {
                string data = respone.Content.ReadAsStringAsync().Result;
                Loginlist = JsonConvert.DeserializeObject<List<PersonViewModel>>(data);

                // Obtener datos adicionales
                List<Contact> contacts = GetContacts();
                List<IdentificationType> typeIdentifications = GetTypeIdentifications();
                List<Address> addresses = GetAddresses();

                // Mapear datos relacionados
                foreach (var person in Loginlist)
                {
                    person.Phone = contacts.FirstOrDefault(c => c.IdContact == person.IdContact)?.Phone;
                    person.Email = contacts.FirstOrDefault(c => c.IdContact == person.IdContact)?.Email;
                    person.IdentifiType = typeIdentifications.FirstOrDefault(ti => ti.IdIdentificationType == person.IdTypeIdentification)?.IdentifiType;
                    person.Addres = addresses.FirstOrDefault(a => a.IdAddress == person.IdAddress)?.Addres;
                }
            }
            var inactiveLogins = Loginlist.Where(login => !login.StateDelete).ToList();

            return View(inactiveLogins);
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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(PersonViewModel model)
        {
            try
            {
                String data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + $"/Person?name={model.Name}&lastName={model.LastName}&idContact={model.IdContact}&idTypeIdentification={model.IdTypeIdentification}&numberIdentification={model.NumberIdentification}&idAddress={model.IdAddress}", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Person Created";
                    return RedirectToAction("PersonGet");
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
                PersonViewModel login = new PersonViewModel();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Person/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    login = JsonConvert.DeserializeObject<PersonViewModel>(data);
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
        public IActionResult Update(PersonViewModel model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + $"/Person/Update/{model.IdPerson}?name={model.Name}&lastName={model.LastName}&idContact={model.IdContact}&idTypeIdentification={model.IdTypeIdentification}&numberIdentification={model.NumberIdentification}&idAddress={model.IdAddress}", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Person details updated";
                    return RedirectToAction("PersonGet");
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
                PersonViewModel login = new PersonViewModel();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Person/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    login = JsonConvert.DeserializeObject<PersonViewModel>(data);
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
                HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + $"/Person/Delete/{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Person details deleted";
                    return RedirectToAction("PersonGet");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
            return View("PersonGet");

        }
    }
}

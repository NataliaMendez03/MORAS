using FrontBerries.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FrontBerries.Controllers
{
    public class AddressController : Controller
    {
        Uri baseAddress = new Uri("http://berriessystemmanagement.somee.com/api");
        private readonly HttpClient _client;

        public AddressController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        [HttpGet]
        public IActionResult AddressGet()
        {
            List<AddressViewModel> Loginlist = new List<AddressViewModel>();
            HttpResponseMessage respone = _client.GetAsync(_client.BaseAddress + "/Address").Result;
            if (respone.IsSuccessStatusCode)
            {
                string data = respone.Content.ReadAsStringAsync().Result;
                Loginlist = JsonConvert.DeserializeObject<List<AddressViewModel>>(data);
            }
            var inactiveLogins = Loginlist.Where(login => !login.StateDelete).ToList();

            return View(inactiveLogins);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(AddressViewModel model)
        {
            try
            {
                String data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + $"/Address/Create?addres={model.Addres}City={model.IdCity}", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Address Created";
                    return RedirectToAction("AddressGet");
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
                AddressViewModel login = new AddressViewModel();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Address/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    login = JsonConvert.DeserializeObject<AddressViewModel>(data);
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
        public IActionResult Update(AddressViewModel model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + $"/Address/Update/{model.IdAddress}?addres={model.Addres}&idCity={model.IdCity}", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Address details updated";
                    return RedirectToAction("AddressGet");
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
                AddressViewModel login = new AddressViewModel();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Address/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    login = JsonConvert.DeserializeObject<AddressViewModel>(data);
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
                HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + $"/Address/Delete/{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "User details deleted";
                    return RedirectToAction("AddressGet");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
            return View("AddressGet");

        }
    }
}

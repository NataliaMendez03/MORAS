using FrontBerries.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sistema_de_Gestion_Moras.Models;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;


namespace FrontBerries.Controllers
{
    [Authorize]
    public class SalesDetailsController : Controller
    {
        Uri BaseAddress = new Uri("http://berriessystemmanagement.somee.com/api");
        private readonly HttpClient _client;

        public SalesDetailsController()
        {
            _client = new HttpClient();
            _client.BaseAddress = BaseAddress;
        }
        [HttpGet]
        public IActionResult SalesDetailsGet()
        {
            List<SalesDetailsViewModel> Loginlist = new List<SalesDetailsViewModel>();
            HttpResponseMessage respone = _client.GetAsync(_client.BaseAddress + "/SalesDetails").Result;
            if (respone.IsSuccessStatusCode)
            {
                string data = respone.Content.ReadAsStringAsync().Result;
                Loginlist = JsonConvert.DeserializeObject<List<SalesDetailsViewModel>>(data);
            }
            var inactiveLogins = Loginlist.Where(login => !login.StateDeleted).ToList();

            return View(inactiveLogins);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(SalesDetailsViewModel model)
        {
            try
            {
                String data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + $"/SalesDetails?amount={model.Amount}&salePrice={model.SalePrice}", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "SalesDetails Created";
                    return RedirectToAction("SalesDetailsGet");
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
                SalesDetailsViewModel login = new SalesDetailsViewModel();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/SalesDetails/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    login = JsonConvert.DeserializeObject<SalesDetailsViewModel>(data);
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
        public IActionResult Update(SalesDetailsViewModel model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + $"/SalesDetails/Update?amount={model.Amount}&salePrice={model.SalePrice}", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "SalesDetails details updated";
                    return RedirectToAction("SalesDetailsGet");
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
                SalesDetailsViewModel login = new SalesDetailsViewModel();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/SalesDetails/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    login = JsonConvert.DeserializeObject<SalesDetailsViewModel>(data);
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
                HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + $"/SalesDetails/Delete/{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "User details deleted";
                    return RedirectToAction("SalesDetailsGet");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
            return View("SalesDetailsGet");

        }
    }

}


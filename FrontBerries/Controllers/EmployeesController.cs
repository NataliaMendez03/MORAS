using FrontBerries.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FrontBerries.Controllers
{
    public class EmployeesController : Controller
    {
        Uri BaseAddress = new Uri("http://berriessystemmanagement.somee.com/api");
        private readonly HttpClient _client;

        public EmployeesController()
        {
            _client = new HttpClient();
            _client.BaseAddress = BaseAddress;
        }
        [HttpGet]
        public IActionResult EmployeesGet()
        {
            List<EmployeesViewModel> Loginlist = new List<EmployeesViewModel>();
            HttpResponseMessage respone = _client.GetAsync(_client.BaseAddress + "/Employees").Result;
            if (respone.IsSuccessStatusCode)
            {
                string data = respone.Content.ReadAsStringAsync().Result;
                Loginlist = JsonConvert.DeserializeObject<List<EmployeesViewModel>>(data);
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
        public IActionResult Create(EmployeesViewModel model)
        {
            try
            {
                String data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + $"/Employees/Create?idPost={model.IdPost}&idPerson={model.IdPerson}", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Employees Created";
                    return RedirectToAction("EmployeesGet");
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
                EmployeesViewModel login = new EmployeesViewModel();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Employees/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    login = JsonConvert.DeserializeObject<EmployeesViewModel>(data);
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
        public IActionResult Update(EmployeesViewModel model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + $"/Employees/Update/{model.IdEmployees}?idPost={model.IdPost}&idPerson={model.IdPerson}\"", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Employees details updated";
                    return RedirectToAction("EmployeesGet");
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
                EmployeesViewModel login = new EmployeesViewModel();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Employees/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    login = JsonConvert.DeserializeObject<EmployeesViewModel>(data);
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
                HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + $"/Employees/Delete/{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "User details deleted";
                    return RedirectToAction("EmployeesGet");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
            return View("EmployeesGet");

        }
    }
}

using FrontBerries.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        [HttpGet]
        public IActionResult SystemLoginGet()
        {
            List<SystemLoginViewModel> SystemLoginlist = new List<SystemLoginViewModel>();
            HttpResponseMessage respone = _client.GetAsync(_client.BaseAddress + "/SystemLogin").Result;
            if (respone.IsSuccessStatusCode)
            {
                string data = respone.Content.ReadAsStringAsync().Result;
                SystemLoginlist = JsonConvert.DeserializeObject<List<SystemLoginViewModel>>(data);
            }
            var inactiveSystemLogins = SystemLoginlist.Where(SystemLogin => !SystemLogin.StateDelete).ToList();

            return View(inactiveSystemLogins);
        }

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

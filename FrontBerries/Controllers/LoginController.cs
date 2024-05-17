using Azure;
using FrontBerries.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FrontBerries.Controllers
{
    public class LoginController : Controller
    {
        Uri baseAddress = new Uri("http://berriessystemmanagement.somee.com/api");
        private readonly HttpClient _client;

        public LoginController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        [HttpGet]
        public IActionResult LoginGet()
        {
            List<LoginViewModel> Loginlist = new List<LoginViewModel>();
            HttpResponseMessage respone = _client.GetAsync(_client.BaseAddress + "/Login").Result;
            if (respone.IsSuccessStatusCode)
                {
                    string data = respone.Content.ReadAsStringAsync().Result;
                    Loginlist = JsonConvert.DeserializeObject<List<LoginViewModel>>(data);
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
        public IActionResult Create(LoginViewModel model)
        {
            try
            {
                String data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + $"/Login/Create?userName={model.UserName}&password={model.Password}&email={model.Email}", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "User Created";
                    return RedirectToAction("LoginGet");
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
            LoginViewModel login = new LoginViewModel();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Login/" + id).Result; 
            if (response.IsSuccessStatusCode) 
            {
                string data = response.Content.ReadAsStringAsync().Result;
                login = JsonConvert.DeserializeObject<LoginViewModel>(data);
            }
            return View(login);
        }
        [HttpPost]
        public IActionResult Update(LoginViewModel model) 
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + $"/Login/Update/{model.IdLogin}?userName={model.UserName}&password={model.Password}&email={model.Email}", content).Result;
            if (response.IsSuccessStatusCode) 
            {
                return RedirectToAction();
            }
            return View();
        }
    }
}

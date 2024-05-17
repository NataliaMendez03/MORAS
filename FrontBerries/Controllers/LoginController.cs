using FrontBerries.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            if(respone.IsSuccessStatusCode)
            {
                string data = respone.Content.ReadAsStringAsync().Result;
                Loginlist = JsonConvert.DeserializeObject<List<LoginViewModel>>(data);
            }
            return View(Loginlist);
        }
    }
}

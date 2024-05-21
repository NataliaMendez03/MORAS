using FrontBerries.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;


namespace FrontBerries.Controllers
{
    [Authorize]
    public class IdentificationTypeController : Controller
    {
        Uri baseAddress = new Uri("http://berriessystemmanagement.somee.com/api");
        private readonly HttpClient _client;

        public IdentificationTypeController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        [HttpGet]
        public IActionResult IdentificationTypeGet()
        {
            List<IdentificationTypeViewModel> Loginlist = new List<IdentificationTypeViewModel>();
            HttpResponseMessage respone = _client.GetAsync(_client.BaseAddress + "/IdentificationType").Result;
            if (respone.IsSuccessStatusCode)
            {
                string data = respone.Content.ReadAsStringAsync().Result;
                Loginlist = JsonConvert.DeserializeObject<List<IdentificationTypeViewModel>>(data);
            }
            var inactiveLogins = Loginlist.Where(login => !login.StateDelete).ToList();

            return View(inactiveLogins);
        }
    }
}

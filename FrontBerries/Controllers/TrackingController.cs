using FrontBerries.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sistema_de_Gestion_Moras.Models;

namespace FrontBerries.Controllers
{
    public class TrackingController : Controller
    {
        Uri baseAddress = new Uri("http://berriessystemmanagement.somee.com/api");
        private readonly HttpClient _client;

        public TrackingController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        #region GetTracking
        [HttpGet]
        public IActionResult TrackingGet()
        {
            List<TrackingViewModel> trackinglist = new List<TrackingViewModel>();
            HttpResponseMessage respone = _client.GetAsync(_client.BaseAddress + "/Tracking").Result;
            if (respone.IsSuccessStatusCode)
            {
                string data = respone.Content.ReadAsStringAsync().Result;
                trackinglist = JsonConvert.DeserializeObject<List<TrackingViewModel>>(data);

                // Obtener datos adicionales
                List<State> State = GetState();

                // Mapear datos relacionados
                foreach (var tracking in trackinglist)
                {
                    tracking.NameState = State.FirstOrDefault(p => p.IdState == tracking.IdState)?.NameState;
                }

            }
            var inactivetrackings = trackinglist.Where(tracking => !tracking.StateDelete).ToList();

            return View(inactivetrackings);
        }
        private List<State> GetState()
        {
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/State").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<State>>(data);
            }
            return new List<State>();
        }
    #endregion
    }
}

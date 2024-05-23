using FrontBerries.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sistema_de_Gestion_Moras.Models;

namespace FrontBerries.Controllers
{
    public class MissionsController : Controller
    {
        Uri baseAddress = new Uri("http://berriessystemmanagement.somee.com/api");
        private readonly HttpClient _client;

        public MissionsController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        #region GetAchievemetsByUser
        [HttpGet]
        public IActionResult MissionsGet()
        {
            List<MissionsViewModel> Missionslist = new List<MissionsViewModel>();
            HttpResponseMessage respone = _client.GetAsync(_client.BaseAddress + $"/Missions").Result;
            if (respone.IsSuccessStatusCode)
            {
                string data = respone.Content.ReadAsStringAsync().Result;
                Missionslist = JsonConvert.DeserializeObject<List<MissionsViewModel>>(data);

                // Obtener datos adicionales
                List<Levels> levels = GetLevels();

                // Mapear datos relacionados
                foreach (var missions in Missionslist)
                {
                    missions.NameLevel = levels.FirstOrDefault(p => p.IdLevel == missions.IdLevel)?.NameLevel;
                }

            }
            var inactiveLogins = Missionslist.Where(ach => !ach.StateDelete).ToList();

            return View(inactiveLogins);
        }
        
        private List<Levels> GetLevels()
        {
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Levels").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<Levels>>(data);
            }
            return new List<Levels>();
        }

        #endregion
    }
}

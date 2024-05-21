using FrontBerries.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sistema_de_Gestion_Moras.Models;
using FrontBerries.Controllers;

namespace FrontBerries.Controllers
{
    public class AchievementsController : Controller
    {
        Uri baseAddress = new Uri("http://berriessystemmanagement.somee.com/api");
        private readonly HttpClient _client;

        public AchievementsController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        #region GetClient
        [HttpGet]
        public IActionResult ClientGet()
        {
            List<AchievementsViewModel> Loginlist = new List<AchievementsViewModel>();
            HttpResponseMessage respone = _client.GetAsync(_client.BaseAddress + "/Achievements").Result;
            if (respone.IsSuccessStatusCode)
            {
                string data = respone.Content.ReadAsStringAsync().Result;
                Loginlist = JsonConvert.DeserializeObject<List<AchievementsViewModel>>(data);

                // Obtener datos adicionales
                List<Login> login = GetLogin();
                List<Missions> missions = GetMissions();
                List<Levels> levels = GetLevels();

                // Mapear datos relacionados
                foreach (var Achievements in Loginlist)
                {
                    Achievements.UserName = login.FirstOrDefault(p => p.IdLogin == Achievements.IdLogin)?.UserName;
                    Achievements.NameMission = missions.FirstOrDefault(p => p.IdMission == Achievements.IdMission)?.NameMission;
                    Achievements.Description = missions.FirstOrDefault(ni => ni.IdMission == Achievements.IdMission).Description;
                    Achievements.NameLevel = levels.FirstOrDefault(p => p.IdLevel == Achievements.IdLevel)?.NameLevel;
                }

            }
            var inactiveLogins = Loginlist.Where(login => !login.StateDelete).ToList();

            return View(inactiveLogins);
        }
        private List<Login> GetLogin()
        {
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Login").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<Login>>(data);
            }
            return new List<Login>();
        }
        private List<Missions> GetMissions()
        {
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Missions").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<Missions>>(data);
            }
            return new List<Missions>();
        }
        private List<Levels> GetLevels()
        {
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Login").Result;
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

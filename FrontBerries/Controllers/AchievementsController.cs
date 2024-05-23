using FrontBerries.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sistema_de_Gestion_Moras.Models;
using FrontBerries.Controllers;
using FrontBerries.ViewModels;
using System;
using NuGet.Protocol.Core.Types;

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

        #region GetAchievemetsByUser
        [HttpGet]
        public IActionResult AchievementsGet()
        {
            List<AchievementsViewModel> Achievementslist = new List<AchievementsViewModel>();
            HttpResponseMessage respone = _client.GetAsync(_client.BaseAddress + $"/Achievements/ByLogin/{53}").Result;
            if (respone.IsSuccessStatusCode)
            {
                string data = respone.Content.ReadAsStringAsync().Result;
                Achievementslist = JsonConvert.DeserializeObject<List<AchievementsViewModel>>(data);

                // Obtener datos adicionales
                List<Login> login = GetLogin();
                List<Missions> missions = GetMissions();
                List<Levels> levels = GetLevels();

                // Mapear datos relacionados
                foreach (var achievements in Achievementslist)
                {
                    achievements.UserName = login.FirstOrDefault(p => p.IdLogin == achievements.IdLogin)?.UserName;
                    achievements.NameMission = missions.FirstOrDefault(p => p.IdMission == achievements.IdMission)?.NameMission;
                    achievements.Description = missions.FirstOrDefault(ni => ni.IdMission == achievements.IdMission).Description;
                    achievements.NameLevel = levels.FirstOrDefault(p => p.IdLevel == achievements.IdLevel)?.NameLevel;

                    var achInfo = missions.FirstOrDefault(m => m.IdLevel == achievements.IdLevel);
                    if (achInfo != null)
                    {
                        var level = levels.FirstOrDefault(ti => ti.IdLevel == achInfo.IdLevel);
                        if (level != null)
                        {
                            achievements.NameLevel = level.NameLevel;
                        }
                    }

                }

            }
            var inactiveLogins = Achievementslist.Where(ach => !ach.StateDelete).ToList();

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

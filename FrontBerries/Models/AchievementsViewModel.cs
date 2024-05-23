using Microsoft.AspNetCore.Mvc.Rendering;
using Sistema_de_Gestion_Moras.Models;
using System.ComponentModel;

namespace FrontBerries.Models
{
    public class AchievementsViewModel
    {
        public AchievementsViewModel()
        {
            Login = new List<SelectListItem>();
            Missions = new List<SelectListItem>();
            Levels = new List<SelectListItem>();
        }

        public int IdArchievement { get; set; }
        public int IdLogin { get; set; }
        public IEnumerable<SelectListItem> Login { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int IdMission { get; set; }
        public IEnumerable<SelectListItem> Missions { get; set; }

        [DisplayName("Mission")]
        public string NameMission { get; set; }
        public string Description { get; set; }
        public int IdLevel { get; set; }
        public IEnumerable<SelectListItem> Levels { get; set; }

        [DisplayName("Level")]
        public string NameLevel { get; set; }

        [DisplayName("Achievement date")]
        public DateTime DateAchievement { get; set; }
        public bool StateDelete { get; set; }

    }
}

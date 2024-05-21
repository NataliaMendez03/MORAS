using Microsoft.AspNetCore.Mvc.Rendering;
using Sistema_de_Gestion_Moras.Models;

namespace FrontBerries.Models
{
    public class MissionsViewModel
    {
        public MissionsViewModel()
        {
            Levels = new List<SelectListItem>();
        }
        public int IdMission { get; set; }
        public string NameMission { get; set; }
        public string Description { get; set; }
        public int IdLevel { get; set; }
        public IEnumerable<SelectListItem> Levels { get; set; }
        public string NameLevel { get; set; }

        public bool StateDelete { get; set; }

    }
}

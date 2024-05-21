using Microsoft.AspNetCore.Mvc.Rendering;

namespace FrontBerries.Models
{
    public class LevelsViewModel
    {
        public int IdLevel { get; set; }
        public string NameLevel { get; set; }
        public bool StateDelete { get; set; }

    }
}

using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace FrontBerries.Models
{
    public class LevelsViewModel
    {
        public int IdLevel { get; set; }
        [DisplayName("Level")]
        public string NameLevel { get; set; }
        public bool StateDelete { get; set; }

    }
}

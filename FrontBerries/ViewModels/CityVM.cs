using Microsoft.AspNetCore.Mvc.Rendering;

namespace FrontBerries.ViewModels
{
    public class CityVM
    {
        public IEnumerable<SelectListItem> City { get; set; }
        public int IdCity { get; set; }
        public string NameCity { get; set; }
    }
}

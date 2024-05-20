using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrontBerries.Models
{
    public class TrackingViewModel
    {
        [DisplayName("Id")]
        public int IdTracking { get; set; }

        [DisplayName("Date")]
        public DateTime DateTracking { get; set; }
        public int IdState { get; set; }
        public IEnumerable<SelectListItem> State { get; set; }

        [DisplayName("State")]
        public string NameState { get; set; }
        public bool StateDelete { get; set; }
    }
}

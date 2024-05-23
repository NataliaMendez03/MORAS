using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace FrontBerries.Models
{
    public class QualityViewModel
    {
        public int IdQuality { get; set; }

        [DisplayName("Quality")]
        public string NQuality { get; set; }
        public string Quantity { get; set; }

    }
}

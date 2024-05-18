using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FrontBerries.Models
{
    public class SuppliesViewModel
    {
        [DisplayName("Id")]
        public int IdSupplies { get; set; }
        [DisplayName("Supplies")]
        public string NameSupplies { get; set; }
        public bool StateDelete { get; set; }
    }
}

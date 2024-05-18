using System.ComponentModel.DataAnnotations.Schema;

namespace FrontBerries.Models
{
    public class AddressViewModel
    {
        public int IdAddress { get; set; }
        public string Addres { get; set; }
        public int IdCity { get; set; }
        public CityViewModel City { get; set; }
        public bool StateDelete { get; set; }
    }
}

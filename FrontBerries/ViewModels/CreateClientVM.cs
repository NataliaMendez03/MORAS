using FrontBerries.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FrontBerries.ViewModels
{
    public class CreateClientVM
    {
        public ClientVM ClientModel { get; set; }
        public PersonVM PersonModel { get; set; }
        public ContactVM ContactModel { get; set; }
        public AddressVM AddressModel { get; set; }
        public CityVM CityModel { get; set; }
        public IdentificationTypeVM IdentTypeModel { get; set; }
        public IEnumerable<SelectListItem> TypeIdentifications { get; set; }

    }
}

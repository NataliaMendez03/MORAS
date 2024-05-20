using FrontBerries.Models;

namespace FrontBerries.ViewModels
{
    public class CreateClientVM
    {
        public ClientVM ClientModel { get; set; }
        public PersonVM PersonModel { get; set; }
        public ContactVM ContactModel { get; set; }
        public AddressVM AddressModel { get; set; }
        public CityVM CityModel { get; set; }

    }
}

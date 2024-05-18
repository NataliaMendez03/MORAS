using Sistema_de_Gestion_Moras.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrontBerries.Models
{
    public class PersonViewModel
    {
        [DisplayName("Id")]
        public int IdPerson { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        [DisplayName("Contact")]
        public int IdContact { get; set; }
        [DisplayName("Type Identification")]
        public int IdTypeIdentification { get; set; }
        [DisplayName("Number Identification")]
        public int NumberIdentification { get; set; }
        [DisplayName("Adress")]
        public int IdAddress { get; set; }
        public bool StateDelete { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc.Rendering;
using Sistema_de_Gestion_Moras.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrontBerries.Models
{
    public class ClientViewModel
    {
        public ClientViewModel()
        {
            Person = new List<SelectListItem>();
            TypeIdentifications = new List<SelectListItem>();
            Contact = new List<SelectListItem>();

        }
        public int IdClient { get; set; }
        public int IdPerson { get; set; }
        public IEnumerable<SelectListItem> Person { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public int IdTypeIdentification { get; set; }
        public IEnumerable<SelectListItem> TypeIdentifications { get; set; }
        [DisplayName("Identification Type")]
        public string IdentifiType { get; set; }

        [DisplayName("Identification Number")]
        public int NumberIdentification { get; set; }

        public int IdContact { get; set; }
        public IEnumerable<SelectListItem> Contact { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }

        public bool StateDelete { get; set; }

    }
}

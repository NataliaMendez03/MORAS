using Microsoft.AspNetCore.Mvc.Rendering;
using Sistema_de_Gestion_Moras.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrontBerries.Models
{
    public class SystemLoginViewModel
    {
        public SystemLoginViewModel()
        {
            Person = new List<SelectListItem>();
            Contacts = new List<SelectListItem>();
            TypeIdentifications = new List<SelectListItem>();
            Addresses = new List<SelectListItem>();
        }
        [DisplayName("Id")]
        public int IdSystemLogin { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        [DisplayName("Person")]
        public int IdPerson { get; set; }
        public IEnumerable<SelectListItem> Person { get; set; }

        public string Name { get; set; }
        public string LastName { get; set; }
        public int IdContact { get; set; }

        public IEnumerable<SelectListItem> Contacts { get; set; }
        public string Phone { get; set; } // Propiedad para mostrar el nombre del contacto
        public string Email { get; set; } // Propiedad para mostrar el nombre del contacto
        
        [DisplayName("Type Identification")]
        public int IdTypeIdentification { get; set; }
        public IEnumerable<SelectListItem> TypeIdentifications { get; set; }
        public string IdentifiType { get; set; } // Propiedad para mostrar el nombre del tipo de identificación

        [DisplayName("Number Identification")]
        public int NumberIdentification { get; set; }

        [DisplayName("Adress")]
        public int IdAddress { get; set; }
        public string Address { get; set; } // Propiedad para mostrar el nombre de la dirección
        public IEnumerable<SelectListItem> Addresses { get; set; }

        [DisplayName("Register Date")]
        public DateTime RegisterDate { get; set; }
        public bool StateDelete { get; set; }
    }
}

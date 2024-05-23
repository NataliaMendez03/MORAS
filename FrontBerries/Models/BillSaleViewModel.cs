using Microsoft.AspNetCore.Mvc.Rendering;
using Sistema_de_Gestion_Moras.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrontBerries.Models
{
    public class BillSaleViewModel
    {
        public BillSaleViewModel()
        {
            Person = new List<SelectListItem>();
            Contacts = new List<SelectListItem>();
            TypeIdentifications = new List<SelectListItem>();
            Addresses = new List<SelectListItem>();
            Client = new List<SelectListItem>();
            SalesDetails = new List<SelectListItem>();
        }

        [DisplayName("Id")]
        public int IdBillSale { get; set; }

        [DisplayName("Client")]
        public int IdClient { get; set; }
        public IEnumerable<SelectListItem> Client { get; set; }

        [DisplayName("Person")]
        public int IdPerson { get; set; }
        public IEnumerable<SelectListItem> Person { get; set; }

        public string Name { get; set; }
        public string LastName { get; set; }
        public int IdContact { get; set; }

        public IEnumerable<SelectListItem> Contacts { get; set; }
        public string Phone { get; set; } // Propiedad para mostrar el nombre del contacto
        public string Email { get; set; } // Propiedad para mostrar el nombre del contacto

        [DisplayName("Identification Type")]
        public int IdIdentificationType { get; set; }
        public IEnumerable<SelectListItem> TypeIdentifications { get; set; }
        public string IdentifiType { get; set; } // Propiedad para mostrar el nombre del tipo de identificación

        [DisplayName("Identification Number")]
        public int NumberIdentification { get; set; }

        [DisplayName("Adress")]
        public int IdAddress { get; set; }
        public string Address { get; set; } // Propiedad para mostrar el nombre de la dirección
        public IEnumerable<SelectListItem> Addresses { get; set; }
        [DisplayName("Date")]
        public DateTime DateSale { get; set; }

        [DisplayName("Details")]
        public int IdSalesDetails { get; set; }
        public IEnumerable<SelectListItem> SalesDetails { get; set; }
        public string Amount { get; set; }

        [DisplayName("Price")]
        public string SalePrice { get; set; }

        [DisplayName("Notes")]
        public string Notes { get; set; }

        public bool StateDelete { get; set; }
    }
}

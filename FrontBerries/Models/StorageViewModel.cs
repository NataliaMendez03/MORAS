using Microsoft.AspNetCore.Mvc.Rendering;
using Sistema_de_Gestion_Moras.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrontBerries.Models
{
    public class StorageViewModel
    {
        public StorageViewModel()
        {
            Harvest = new List<SelectListItem>();
            Person = new List<SelectListItem>();
            TypeIdentifications = new List<SelectListItem>();
            Quality = new List<SelectListItem>();
            Post = new List<SelectListItem>();
            Employees = new List<SelectListItem>();

        }
        [DisplayName("Id")]
        public int IdStorage { get; set; }

        [DisplayName("Description")]
        public string StorageName { get; set; }
        public int IdHarvests { get; set; }
        public IEnumerable<SelectListItem> Harvest { get; set; }
        public DateTime HarvestDate { get; set; }
        public string HarvestAmount { get; set; }

        public int IdEmployees { get; set; }
        public IEnumerable<SelectListItem> Employees { get; set; }

        public int IdPost { get; set; }
        public IEnumerable<SelectListItem> Post { get; set; }

        [DisplayName("Post")]
        public string NamePost { get; set; }

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

        public int IdQuality { get; set; }
        public IEnumerable<SelectListItem> Quality { get; set; } 

        [DisplayName("Quality")]
        public string NQuality { get; set; }
        public string Quantity { get; set; }


        [DisplayName("Entry Date")]
        public DateTime EntryDate { get; set; }
        public string Temperature { get; set; }
        public bool StateDelete { get; set; }
    }
}

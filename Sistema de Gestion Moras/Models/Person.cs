using Microsoft.OpenApi.Models;
using Sistema_de_Gestion_Moras.Models;
using System.ComponentModel.DataAnnotations.Schema;
namespace Sistema_de_Gestion_Moras.Models
{
    public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPerson { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public int IdContact { get; set; }
        public Contact Contact { get; set; }
        public int IdTypeIdentification { get; set; }
        public IdentificationType TypeIdentification { get; set; }
        public int NumberIdentification { get; set; }
        public int IdAddress { get; set; }
        public Address Address { get; set; }
        public bool? StateDelete { get; set; }

    }
}

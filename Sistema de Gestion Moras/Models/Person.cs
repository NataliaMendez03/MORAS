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
        public required int IdContact { get; set; }
        public required Contact Contact { get; set; }
        public required int IdTypeIdentification { get; set; }
        public required IdentificationType TypeIdentification { get; set; }
        public int NumberIdentification { get; set; }
        public required int IdAddress { get; set; }
        public required Address Address { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_de_Gestion_Moras.Models
{
    public class Address
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAddress { get; set; }
        public string? Addres { get; set; }
        public required int IdCity { get; set; }
        public required City City { get; set; }
    }
}

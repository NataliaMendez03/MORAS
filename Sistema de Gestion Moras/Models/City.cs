using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_de_Gestion_Moras.Models
{
    public class City
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCity { get; set; }
        public string? NameCity { get; set; }
        public bool? StateDelete { get; set; }

    }
}

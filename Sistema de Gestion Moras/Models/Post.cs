using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_de_Gestion_Moras.Models
{
    public class Post //CARGO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPost { get; set; }
        public string? NamePost { get; set; }
    }
}

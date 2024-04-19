using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_de_Gestion_Moras.Models
{
    public class Quality
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdQuality { get; set; }
        public string? NQuality { get; set; }
        public string? Quantity { get; set; }
        public bool? StateDelete { get; set; }

    }
}

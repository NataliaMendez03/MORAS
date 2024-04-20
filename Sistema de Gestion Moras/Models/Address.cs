using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_de_Gestion_Moras.Models
{
    public class Address
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAddress { get; set; }
        public string Addres { get; set; }
        public int IdCity { get; set; }
        [NotMapped]
        public City City { get; set; }
        public bool StateDelete { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}

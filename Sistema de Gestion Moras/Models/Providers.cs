using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_de_Gestion_Moras.Models
{
    public class Providers
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProviders { get; set; }
        public int IdPerson { get; set; }
        [NotMapped]
        public Person Person { get; set; }
        public bool StateDelete { get; set; }
        public DateTime? ModifyDate { get; set; }

    }
}

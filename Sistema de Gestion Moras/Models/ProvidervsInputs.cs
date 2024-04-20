using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_de_Gestion_Moras.Models
{
    public class ProvidervsInputs
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProvsInp { get; set; }
        public int IdProviders { get; set; }
        [NotMapped]
        public Providers Providers { get; set; }
        public int IdSupplies { get; set; }
        [NotMapped]
        public Supplies Supplies { get; set; }
        public bool StateDelete { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}

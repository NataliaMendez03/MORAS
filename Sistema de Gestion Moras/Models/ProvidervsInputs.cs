using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_de_Gestion_Moras.Models
{
    public class ProvidervsInputs
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProvsInp { get; set; }
        public int? IdProviders { get; set; }
        public Providers Providers { get; set; }
        public int? IdSupplies { get; set; }
        public Supplies Supplies { get; set; }
        public bool? StateDelete { get; set; }
    }
}

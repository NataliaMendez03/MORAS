using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_de_Gestion_Moras.Models
{
    public class ProvidervsInputs
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProvsInp { get; set; }
        public required int IdProviders { get; set; }
        public required Providers Providers { get; set; }
        public required int IdSupplies { get; set; }
        public required Supplies Supplies { get; set; }
    }
}

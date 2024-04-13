using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_de_Gestion_Moras.Models
{
    public class Purchase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPurchase { get; set; }
        public required int IdProviders { get; set; }
        public required Providers Providers { get; set; }
        public DateTime DateProviders { get; set; }
        public required int IdPurchaseDetail { get; set; }
        public required PurchaseDetail PurchaseDetail { get; set; }
    }
}

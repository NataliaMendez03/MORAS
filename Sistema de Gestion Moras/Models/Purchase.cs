using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_de_Gestion_Moras.Models
{
    public class Purchase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPurchase { get; set; }
        public int IdProviders { get; set; }
        public Providers Providers { get; set; }
        public DateTime DateProviders { get; set; }
        public int IdPurchaseDetail { get; set; }
        public PurchaseDetail PurchaseDetail { get; set; }
        public bool StateDelete { get; set; }
        public DateTime? CreatedDate { get; set; }

    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_de_Gestion_Moras.Models
{
    public class BillSale
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdBillSale { get; set; }
        public int? IdClient { get; set; }
        public Client Client { get; set; }
        public DateTime? DateSale { get; set; }
        public int? IdSalesDetails { get; set; }
        public SalesDetails? SalesDetails { get; set; }
        public string? Notes { get; set; }
        public bool? StateDelete { get; set; }

    }
}

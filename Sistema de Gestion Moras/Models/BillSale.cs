using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_de_Gestion_Moras.Models
{
    public class BillSale
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdBillSale { get; set; }
        public required int IdClient { get; set; }
        public required Client Client { get; set; }
        public DateTime DateSale { get; set; }
        public required int IdSalesDetails { get; set; }
        public required SalesDetails SalesDetails { get; set; }
        public string? Notes { get; set; }
    }
}

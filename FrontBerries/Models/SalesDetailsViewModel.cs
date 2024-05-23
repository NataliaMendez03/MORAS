using System.ComponentModel;

namespace FrontBerries.Models
{
    public class SalesDetailsViewModel
    {
        public int IdSalesDetails { get; set; }
        public int Amount { get; set; }

        [DisplayName("Price")]
        public decimal SalePrice { get; set; }
        public bool StateDelete { get; set; }
    }
}

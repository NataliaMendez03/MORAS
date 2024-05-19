using Microsoft.AspNetCore.Mvc.Rendering;
using Sistema_de_Gestion_Moras.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrontBerries.Models
{
    public class BillSaleViewModel
    {
        public BillSaleViewModel()
        {
            Client = new List<SelectListItem>();
            SalesDetails = new List<SelectListItem>();
        }

        [DisplayName("Id")]
        public int IdBillSale { get; set; }

        [DisplayName("Client")]
        public int IdClient { get; set; }
        public string ClientName { get; set; }
        public IEnumerable<SelectListItem> Client { get; set; }

        [DisplayName("Date Sale")]
        public DateTime DateSale { get; set; }

        [DisplayName("Details")]
        public int IdSalesDetails { get; set; }
        public IEnumerable<SelectListItem> SalesDetails { get; set; }
        public int Amount { get; set; }
        public decimal SalePrice { get; set; }

        [DisplayName("Notes")]
        public string Notes { get; set; }

        public bool StateDeleted { get; set; }
    }
}

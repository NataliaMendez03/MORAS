using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Sistema_de_Gestion_Moras.Models
{
    public class SalesDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSalesDetails { get; set; }
        public string? Amount { get; set; }
        public string? SalePrice { get; set; }
        public bool? StateDelete { get; set; }

    }
}


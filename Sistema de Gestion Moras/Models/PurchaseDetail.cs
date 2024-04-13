﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_de_Gestion_Moras.Models
{
    public class PurchaseDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPurchaseDetail { get; set; }
        public required int? IdSupplies { get; set; }
        public required Supplies Supplies { get; set; }
        public int? Quantity { get; set; }
        public string? PurchasePrice { get; set; }
        public string? Notes { get; set; }
    }
}

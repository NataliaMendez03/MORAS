using Microsoft.Net.Http.Headers;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Sistema_de_Gestion_Moras.Models
{
    public class Harvests
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdHarvests { get; set; }
        public DateTime? HarvestDate { get; set; }
        public string? HarvestAmount { get; set; }
        public required int? Idemployees { get; set; }
        public required Employees Employees { get; set; }
        public required int? IdQuality { get; set; }
        public required Quality Quality { get; set; }

    }
}


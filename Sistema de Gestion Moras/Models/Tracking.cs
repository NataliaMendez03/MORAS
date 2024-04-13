using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
namespace Sistema_de_Gestion_Moras.Models
{
    public class Tracking
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTracking { get; set; }
        public DateTime DateTracking { get; set; }
        public required int IdState { get; set; }
        public required State State { get; set; }
    }
}


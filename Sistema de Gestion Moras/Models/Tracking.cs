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
        public int IdState { get; set; }
        [NotMapped]
        public State State { get; set; }
        public bool StateDelete { get; set; }
        public DateTime? ModifyDate { get; set; }

    }
}


using Sistema_de_Gestion_Moras.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_de_Gestion_Moras.Models
{
    public class Dispatch
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDispatch {  get; set; }
        public required int? IdEmployees { get; set; }
        public required Employees Employee { get; set; }
        public required int? IdSalesDetails { get; set; }
        public required SalesDetails SalesDetails { get; set; }

        public DateTime Date {  get; set; }
        public required int? IdTracking { get; set; }
        public required Tracking Tracking { get; set; }

    }
}

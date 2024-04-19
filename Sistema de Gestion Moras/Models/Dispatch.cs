using Sistema_de_Gestion_Moras.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_de_Gestion_Moras.Models
{
    public class Dispatch
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDispatch {  get; set; }
        public int? IdEmployees { get; set; }
        public Employees Employees { get; set; }
        public int? IdSalesDetails { get; set; }
        public SalesDetails SalesDetails { get; set; }
        public DateTime? Date {  get; set; }
        public int? IdTracking { get; set; }
        public Tracking Tracking { get; set; }
        public bool? StateDelete { get; set; }

    }
}

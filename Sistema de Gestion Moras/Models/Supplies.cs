using Sistema_de_Gestion_Moras.Models;
using System.ComponentModel.DataAnnotations.Schema;
namespace Sistema_de_Gestion_Moras.Models
{
    public class Supplies
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSupplies { get; set; }
        public string NameSupplies { get; set;}
        public bool StateDelete { get; set; }
        public DateTime? ModifyDate { get; set; }

    }
}

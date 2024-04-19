using Sistema_de_Gestion_Moras.Models;
using System.ComponentModel.DataAnnotations.Schema;
namespace Sistema_de_Gestion_Moras.Models
{
    public class Client
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdClient { get; set; }

        public int IdPerson { get; set; }
        public Person Person { get; set; }
        public bool StateDelete { get; set; }
        public DateTime? CreatedDate { get; set; }

    }
}

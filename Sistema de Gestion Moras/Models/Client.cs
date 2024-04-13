using Sistema_de_Gestion_Moras.Models;
using System.ComponentModel.DataAnnotations.Schema;
namespace Sistema_de_Gestion_Moras.Models
{
    public class Client
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdClient { get; set; }

        public required int IdPerson { get; set; }
        public required Person Person { get; set; }
    }
}

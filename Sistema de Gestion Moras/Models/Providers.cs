using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_de_Gestion_Moras.Models
{
    public class Providers
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProviders { get; set; }
        public required int IdPerson { get; set; }
        public required Person Person { get; set; }
    }
}

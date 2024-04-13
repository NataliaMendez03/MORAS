using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_de_Gestion_Moras.Models
{
    public class Employees
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEmployees { get; set; }
        public required int? IdPost { get; set; }
        public required Post Post { get; set; }
        public required int? IdPerson { get; set; }
        public required Person Person { get; set; }
    }
}

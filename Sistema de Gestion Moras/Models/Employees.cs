using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_de_Gestion_Moras.Models
{
    public class Employees
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEmployees { get; set; }
        public int IdPost { get; set; }
        public Post Post { get; set; }
        public int IdPerson { get; set; }
        public Person Person { get; set; }
        public bool StateDelete { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}

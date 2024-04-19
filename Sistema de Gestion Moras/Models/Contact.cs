using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_de_Gestion_Moras.Models
{
    public class Contact
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdContact { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool StateDelete { get; set; }
        public DateTime? CreatedDate { get; set; }

    }
}

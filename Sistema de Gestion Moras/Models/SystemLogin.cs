using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_de_Gestion_Moras.Models
{
    public class SystemLogin
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSystemLogin { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int IdPerson { get; set; }
        [NotMapped]
        public Person Person { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool? Verified { get; set; }
        public bool StateDelete { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}

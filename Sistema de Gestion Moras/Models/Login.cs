using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_de_Gestion_Moras.Models
{
    public class Login
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdLogin { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime RegisterDate {  get; set; }
        public bool StateDelete { get; set; }
        public DateTime? ModifyDate { get; set; }


    }
}

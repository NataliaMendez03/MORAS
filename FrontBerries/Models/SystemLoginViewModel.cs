using Sistema_de_Gestion_Moras.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrontBerries.Models
{
    public class SystemLoginViewModel
    {
        [DisplayName("Id")]

        public int IdSystemLogin { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int IdPerson { get; set; }

        [DisplayName("Register Date")]
        public DateTime RegisterDate { get; set; }
        public bool StateDelete { get; set; }
    }
}

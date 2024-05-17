using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FrontBerries.Models
{
    public class LoginViewModel
    {
        [DisplayName("Id")]
        public int IdLogin { get; set; }
        [DisplayName("User Name")]
        public string UserName { get; set; }
        public string Email { get; set; }

        [DisplayName("Register Date")]
        public DateTime RegisterDate { get; set; }
    }
}

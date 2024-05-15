using System.ComponentModel.DataAnnotations.Schema;

namespace FrontBerries.ViewModels
{
    public class UsuarioVM
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public string ConfirmPassword { get; set; }
        public DateTime RegisterDate { get; set; }

    }
}

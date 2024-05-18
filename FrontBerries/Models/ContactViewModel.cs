using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FrontBerries.Models
{
    public class ContactViewModel
    {
        [DisplayName("Id")]
        public int IdContact { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool StateDelete { get; set; }
    }
}

using Sistema_de_Gestion_Moras.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrontBerries.ViewModels
{
    public class SystemLoginVM
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public DateTime RegisterDate { get; set; }

        public int IdPerson { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Email { get; set; }
        public int Phone { get; set; }
        public int TypeIdentification { get; set; }
        public int NumberIdentification { get; set; }
        public int Address { get; set; }
        public int City { get; set; }

    }
}

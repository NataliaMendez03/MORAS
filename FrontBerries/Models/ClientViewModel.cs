using Sistema_de_Gestion_Moras.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrontBerries.Models
{
    public class ClientViewModel
    {
        public int IdClient { get; set; }

        public bool StateDelete { get; set; }

    }
}

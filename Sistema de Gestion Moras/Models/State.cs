using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_de_Gestion_Moras.Models
{
    public class State
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdState { get; set; }
        public string NameState { get; set; }
        public bool StateDelete { get; set; }
        public DateTime? CreatedDate { get; set; }

    }
}

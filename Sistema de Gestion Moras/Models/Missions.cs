using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_de_Gestion_Moras.Models
{
    public class Missions
    {
        public int IdMission {  get; set; }
        public string NameMission { get; set; }
        public string Description { get; set; }
        public int IdLevel { get; set; }
        [NotMapped]
        public Levels Levels { get; set; }

    }
}

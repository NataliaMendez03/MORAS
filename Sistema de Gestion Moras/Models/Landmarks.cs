using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_de_Gestion_Moras.Models
{
    public class Landmarks
    {
        public int IdLandmarks { get; set; }
        public int IdLevel {  get; set; }
        [NotMapped]
        public Levels Levels { get; set; }
        public int IdHarvests { get; set; }
        [NotMapped]
        public Harvests Harvests { get; set; }
        public DateTime DateLandmark { get; set; }

    }
}

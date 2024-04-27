using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_de_Gestion_Moras.Models
{
    public class Achievements
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdArchievement {  get; set; }
        public int IdLogin { get; set; }
        [NotMapped]
        public Login Login { get; set; }
        public int IdMission { get; set; }
        [NotMapped]
        public Missions Mission {  get; set; }
        public DateTime DateAchievement { get; set; }

    }
}

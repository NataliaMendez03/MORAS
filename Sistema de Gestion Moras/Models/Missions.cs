namespace Sistema_de_Gestion_Moras.Models
{
    public class Missions
    {
        public int IdMission {  get; set; }
        public string NameMission { get; set; }
        public string Description { get; set; }
        public bool StateDelete { get; set; }
        public DateTime? ModifyDate { get; set; }

    }
}

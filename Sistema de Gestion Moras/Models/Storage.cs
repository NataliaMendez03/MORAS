using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_de_Gestion_Moras.Models
{
    public class Storage
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdStorage { get; set; }
        public string? StorageName { get; set; }
        public required int? IdHarvests { get; set; }
        public required Harvests Harvests { get; set; }
        public DateTime? EntryDate { get; set; }
        public string? Temperature { get; set; }

    }
}

using System.ComponentModel;

namespace FrontBerries.Models
{
    public class IdentificationTypeViewModel
    {
        public int IdIdentificationType { get; set; }
        [DisplayName("Type Identification")]
        public string IdentifiType { get; set; }
        public bool StateDelete { get; set; }
    }
}

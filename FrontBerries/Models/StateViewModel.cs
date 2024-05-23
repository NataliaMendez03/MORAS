using System.ComponentModel;

namespace FrontBerries.Models
{
    public class StateViewModel
    {
        public int IdState { get; set; }
        [DisplayName("State")]
        public string NameState { get; set; }
        public bool StateDelete { get; set; }
    }
}

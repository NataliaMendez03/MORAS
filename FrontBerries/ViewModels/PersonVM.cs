using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace FrontBerries.ViewModels
{
    public class PersonVM
    {
        public int IdPerson { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public int IdContact { get; set; }
        public int IdTypeIdentification { get; set; }

        public int NumberIdentification { get; set; }

        public int IdAddress { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMI.Shared.DTOs
{
    public class PersonaReligionDTO
    {
        public int id_Persona { get; set; }

        public int? id_Religion { get; set; }

        public string? nombreReligion { get; set; }
    }
}

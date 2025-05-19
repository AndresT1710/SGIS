using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMI.Shared.DTOs
{
    public class PersonaSeguroMedicoDTO
    {
        public int id { get; set; }

        public int? id_Persona { get; set; }

        public int? id_SeguroMedico { get; set; }
    }
}

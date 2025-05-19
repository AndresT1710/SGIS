using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMI.Shared.Models
{
    public class User
    {
        public string? Correo { get; set; }
        public string? Clave { get; set; }
        public bool? Activo { get; set; } = true;
    }
}

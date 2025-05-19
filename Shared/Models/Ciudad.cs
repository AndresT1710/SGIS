using System;
using System.Collections.Generic;

namespace SMI.Shared.Models;

public partial class Ciudad
{
    public int id { get; set; }

    public int? id_Provincia { get; set; }

    public string? nombre { get; set; }

    public virtual Provincia? IdProvinciaNavigation { get; set; }

    public virtual ICollection<PersonaLugarResidencia> PersonaLugarResidencia { get; set; } = new List<PersonaLugarResidencia>();
}

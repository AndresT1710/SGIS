using System;
using System.Collections.Generic;

namespace SMI.Shared.Models;

public partial class PersonaLugarResidencia
{
    public int id_Persona { get; set; }

    public int? id_Ciudad { get; set; }

    public virtual Ciudad? IdCiudadNavigation { get; set; }

    public virtual Persona IdPersonaNavigation { get; set; } = null!;
}

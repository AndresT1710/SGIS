using System;
using System.Collections.Generic;

namespace SMI.Shared.Models;

public partial class PersonaLateralidad
{
    public int id_Persona { get; set; }

    public int? id_Lateralidad { get; set; }

    public virtual Lateralidad? IdLateralidadNavigation { get; set; }

    public virtual Persona IdPersonaNavigation { get; set; } = null!;
}

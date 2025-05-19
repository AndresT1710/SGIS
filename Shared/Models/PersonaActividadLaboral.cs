using System;
using System.Collections.Generic;

namespace SMI.Shared.Models;

public partial class PersonaActividadLaboral
{
    public int IdPersona { get; set; }

    public int? IdActividadLaboral { get; set; }

    public virtual ActividadLaboral? IdActividadLaboralNavigation { get; set; }

    public virtual Persona IdPersonaNavigation { get; set; } = null!;
}

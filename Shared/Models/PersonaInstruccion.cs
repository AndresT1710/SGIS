using System;
using System.Collections.Generic;

namespace SMI.Shared.Models;

public partial class PersonaInstruccion
{
    public int IdPersona { get; set; }

    public int? IdNivelInstruccion { get; set; }

    public virtual NivelInstruccion? IdNivelInstruccionNavigation { get; set; }

    public virtual Persona IdPersonaNavigation { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace SMI.Shared.Models;

public partial class NivelInstruccion
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<PersonaInstruccion> PersonaInstruccions { get; set; } = new List<PersonaInstruccion>();
}
